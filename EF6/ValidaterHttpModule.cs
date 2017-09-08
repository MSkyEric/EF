using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF6
{
    public class ValidaterHttpModule : IHttpModule
    {
        public void Dispose()
        { }
        /// <summary>
        /// 验证HttpModule事件机制
        /// </summary>
        /// <param name="application"></param>
        public void Init(HttpApplication application)
        {
            application.BeginRequest += new EventHandler(application_BeginRequest);
            application.EndRequest += new EventHandler(application_EndRequest);
            application.AcquireRequestState += new EventHandler(application_AcquireRequestState);
            application.AuthenticateRequest += new EventHandler(application_AuthenticateRequest);
            application.AuthorizeRequest += new EventHandler(application_AuthorizeRequest);
            application.PreRequestHandlerExecute += new EventHandler(application_PreRequestHandlerExecute);
            application.PostRequestHandlerExecute += new EventHandler(application_PostRequestHandlerExecute);
            application.ReleaseRequestState += new EventHandler(application_ReleaseRequestState);
            application.ResolveRequestCache += new EventHandler(application_ResolveRequestCache);
            application.PreSendRequestHeaders += new EventHandler(application_PreSendRequestHeaders);
            application.PreSendRequestContent += new EventHandler(application_PreSendRequestContent);
        }
        private void application_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            application.Context.Response.Write("application_BeginRequest<br/>");
        }
        private void application_EndRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            application.Context.Response.Write("application_EndRequest<br/>");
        }
        private void application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            application.Context.Response.Write("application_PreRequestHandlerExecute<br/>");
        }
        private void application_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            application.Context.Response.Write("application_PostRequestHandlerExecute<br/>");
        }
        private void application_ReleaseRequestState(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            application.Context.Response.Write("application_ReleaseRequestState<br/>");
        }
        private void application_AcquireRequestState(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            application.Context.Response.Write("application_AcquireRequestState<br/>");
        }
        private void application_PreSendRequestContent(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            application.Context.Response.Write("application_PreSendRequestContent<br/>");
        }
        private void application_PreSendRequestHeaders(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            application.Context.Response.Write("application_PreSendRequestHeaders<br/>");
        }
        private void application_ResolveRequestCache(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            application.Context.Response.Write("application_ResolveRequestCache<br/>");
        }
        private void application_AuthorizeRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            application.Context.Response.Write("application_AuthorizeRequest<br/>");
        }
        private void application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            application.Context.Response.Write("application_AuthenticateRequest<br/>");
        }
    }
}