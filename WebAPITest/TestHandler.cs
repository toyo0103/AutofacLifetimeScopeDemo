using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Autofac;
using WebAPITest.App_Start;
using WebAPITest.Services;

namespace WebAPITest
{
    public class TestHandler: DelegatingHandler
    {
        ISupplierApiProfileService _supplierApiProfileService;
        IComponentContext _componentContext;
        ITestService _testService;
        public TestHandler(
            ISupplierApiProfileService supplierApiProfileService,
            ITestService testService,
            IComponentContext componentContext)
        {
            this._supplierApiProfileService = supplierApiProfileService;
            this._componentContext = componentContext;
            this._testService = testService;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //LifeTimeScope
            //using (var scope = AutofacConfig.Container.BeginLifetimeScope())
            //{
            //    var Service = scope.Resolve<ISupplierApiProfileService>();
            //    token = Service.GetToken();
            //}


            var Service = AutofacConfig.Container.Resolve<ISupplierApiProfileService>();
            var containerToken = Service.GetToken();

            //Construct Injection Service 
            var SupplierApiProfileServiceToken = _supplierApiProfileService.GetToken();

            //ComponentContext
            var cService = _componentContext.Resolve<ISupplierApiProfileService>();
            var ComponentContextToken = cService.GetToken();


            //TestService
            var TestServiceToken = _testService.GetToken();

            return base.SendAsync(request, cancellationToken);
        }
    }
}