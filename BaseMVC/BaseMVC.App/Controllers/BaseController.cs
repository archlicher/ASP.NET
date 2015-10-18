namespace BaseMVC.App.Controllers
{
    using Model;
    using System;
    using System.Linq;
    using Data.UnitOfWork;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class BaseController : Controller
    {
        public BaseController(IBaseMVCData data)
        {
            this.Data = data;
        }

        public BaseController(IBaseMVCData data, ApplicationUser user)
            : this(data)
        {
            this.UserProfile = user;
        }

        public IBaseMVCData Data { get; private set; }

        public ApplicationUser UserProfile { get; set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.Users.All().FirstOrDefault(u => u.UserName == username);
                this.UserProfile = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}