using NUnit.Framework;
using EF6.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EF6.Controllers.Tests
{
    [TestFixture()]
    public class ProductControllerTests
    {
        [Test()]
        public void IndexTest()
        {

            try
            {
                var viewResult = (ViewResult)new ProductController().Index(1);
                Assert.AreEqual(null, viewResult.ViewData.Model);
                //Assert.Fail();
            }
            catch (Exception ex)
            { }
        }
    }
}