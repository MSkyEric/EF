using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EF6.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Porduct/
        //public ActionResult Index()
        //{
        //    using (DAL.EFDbContext db = new DAL.EFDbContext())
        //    {
                
        //        var m = db.Products.ToList<Product>();
        //        return View(m);
        //    }

        //}

        public ActionResult Index(int? page)
        {
            int pageIndex = page ?? 1;
            int pageSize = 5;
            int totalCount = 0;
            var product = GetProduct(pageIndex, pageSize, ref totalCount);
            var productAsIPagedList = new StaticPagedList<Product>(product, pageIndex, pageSize, totalCount);

            return View(productAsIPagedList);
        }

        private List<Product> GetProduct(int pageIndex, int pageSize, ref int totalCount)
        {
            using (DAL.EFDbContext db = new DAL.EFDbContext())
            {
                var m = db.Products.OrderBy(p=>p.ID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                totalCount = db.Products.Count();
                return m.ToList();
                //var persons = (from p in db.TestDataDBS orderby p.ID descending select p).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                //totalCount = db.TestDataDBS.Count();
                //return persons.ToList();
            }
        }




        public ActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public async Task<ActionResult> Add(Product model)
        {
            if (ModelState.IsValid)
            {
                await AddProduct(model);
                //using (DAL.EFDbContext db = new DAL.EFDbContext())
                //{
                //    var m = db.Products.Add(model);
                //    //db.SaveChanges();
                //    await db.SaveChangesAsync();
                //}
            }
            return RedirectToAction("index");
        }

        private async Task<int> AddProduct(Product model)
        {
            using (DAL.EFDbContext db = new DAL.EFDbContext())
            {
                new Func<int, bool>((a) => { if (a > 10)return true; return false; }).Invoke(10);

                Func<int, bool> aa = (b) => { if (b > 0)return true; return false; };
                bool flag = aa(10);

                var m = db.Products.Add(model);
                //db.SaveChanges();
                return await db.SaveChangesAsync();

            }
        }

        private int Test<T1, T2>(Func<T1, T2, int> func, T1 a, T2 b)
        {
            T1 t1 = default(T1);

            return func(a, b);
        }

        [HttpPost]
        public ActionResult Edit(Product model)
        {
            using (DAL.EFDbContext db = new DAL.EFDbContext())
            {
                var m = db.Products.Where(p => p.ID == model.ID).FirstOrDefault();
                m.Name = model.Name;
                m.Price = model.Price;
                m.Quantity = model.Quantity;
                db.SaveChanges();
                //db.SaveChangesAsync();
                
            }
            return RedirectToAction("index", new { page = 2 });
        }

        public ActionResult Edit(int ID)
        {
            Product Model = new Product();

            using (DAL.EFDbContext db = new DAL.EFDbContext())
            {
                Model = db.Products.Where(p => p.ID == ID).FirstOrDefault();
               
            }
            return View("Edit", Model);
        }
        
        public ActionResult Delete(int ID)
        {
            using (DAL.EFDbContext db = new DAL.EFDbContext())
            {
                var m = db.Products.Where(p => p.ID == ID).FirstOrDefault();
                db.Products.Remove(m);
                db.SaveChanges();

                return RedirectToAction("index");
            }
        }

	}

    class Singleton<T> where T : class, new()
    {
        private static T singleton;
        private static readonly object o = new object();
        private  Singleton() { }
        
        public static T GetInstance()
        {
            if (singleton == null)
            {
                lock (o)
                {
                    if (singleton == null)
                    {
                        var tmp = Activator.CreateInstance<T>();
                        System.Threading.Interlocked.Exchange(ref singleton, tmp);
                    }
                }
            }
            return singleton;
        }

    }

    public static class MyFindWords
    {
        private static Regex sp = new Regex(@"\W");
        public static string[] Find(string parentWords, string childWords)
        {
            var parentWordList = sp.Split(parentWords);
            var childWordList = sp.Split(childWords);
            return parentWordList.Where(p => !string.IsNullOrEmpty(p) && !childWordList.Any(p2 => p2.ToLower() == p.ToLower())).ToArray();
        }

        private static Regex rg = new Regex(@"\W", RegexOptions.IgnoreCase);
        private static string[] GetNotInString(string str1, string str2)
        {
            string[] returnArr;

            string[] arr1 = rg.Split(str1);
            string[] arr2 = rg.Split(str2);

            returnArr = arr1.Where(p => string.IsNullOrEmpty(p) && !arr2.Any(q => q.ToLower() == p.ToLower())).ToArray();

            return returnArr;
        }
    }

   

}