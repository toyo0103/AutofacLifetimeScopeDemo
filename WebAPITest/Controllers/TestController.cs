using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Autofac;
using WebAPITest.App_Start;
using WebAPITest.Services;

namespace WebAPITest.Controllers
{
    public class TestController : ApiController
    {
        ISupplierApiProfileService SupplierApiProfileService;
        IComponentContext ComponentContext;
        public TestController(
            ISupplierApiProfileService supplierApiProfileService,
            IComponentContext componentContext)
        {
            this.SupplierApiProfileService = supplierApiProfileService;
            this.ComponentContext = componentContext;
        }

        // GET api/<controller>
        public HttpResponseMessage Get()
        {

            //IComponentContext
            var Service = AutofacConfig.Container.Resolve<ISupplierApiProfileService>();
            var containerToken = Service.GetToken();


            //IComponentContext
            var cService = ComponentContext.Resolve<ISupplierApiProfileService>();
            var componentContextToken = cService.GetToken();

            //ISupplierApiProfileService
            var supplierApiProfileServiceToken = SupplierApiProfileService.GetToken();


            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                Handler = new
                {
                    RootContainerToken = Request.Properties["containerToken"],
                    ComponentContextToken = Request.Properties["componentContextToken"],
                    SupplierApiProfileServiceToken = Request.Properties["supplierApiProfileServiceToken"],
                    NewLifetimeScope = Request.Properties["newLifetimeScopeToken"],
                },
                Action = new 
                {
                    RootContainerToken = containerToken,
                    ComponentContextToken = componentContextToken,
                    SupplierApiProfileServiceToken = supplierApiProfileServiceToken
                }
            }); 
        }
    }
}









































