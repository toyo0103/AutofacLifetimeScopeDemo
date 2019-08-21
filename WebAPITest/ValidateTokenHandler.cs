using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Autofac;
using WebAPITest.App_Start;
using WebAPITest.Services;

namespace WebAPITest
{
    public class ValidateTokenHandler : DelegatingHandler
    {
        ISupplierApiProfileService _supplierApiProfileService;
        IComponentContext _componentContext;
        ILifetimeScope _lifetimeScope;
        public ValidateTokenHandler(
            ISupplierApiProfileService supplierApiProfileService,
            IComponentContext componentContext,
            ILifetimeScope lifetimeScope)
        {
            this._supplierApiProfileService = supplierApiProfileService;
            this._componentContext = componentContext;
            this._lifetimeScope = lifetimeScope;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var Service = AutofacConfig.Container.Resolve<ISupplierApiProfileService>();
            var containerToken = Service.GetToken();
            request.Properties.Add("containerToken", containerToken);

            //Construct Injection Service 
            var SupplierApiProfileServiceToken = _supplierApiProfileService.GetToken();
            request.Properties.Add("supplierApiProfileServiceToken", SupplierApiProfileServiceToken);

            //ComponentContext
            var cService = _componentContext.Resolve<ISupplierApiProfileService>();
            var ComponentContextToken = cService.GetToken();
            request.Properties.Add("componentContextToken", ComponentContextToken);

            //LifeTimeScope
            using (var scope = _lifetimeScope.BeginLifetimeScope())
            {
                var NewScopeService = scope.Resolve<ISupplierApiProfileService>();
                var NewLifetimeScopeToken = NewScopeService.GetToken();
                request.Properties.Add("newLifetimeScopeToken", NewLifetimeScopeToken);
            }


            return base.SendAsync(request, cancellationToken);
        }
    }
}

































//LifeTimeScope
//using (var scope = _lifetimeScope.BeginLifetimeScope())
//{
//    var NewScopeService = scope.Resolve<ISupplierApiProfileService>();
//    var NewLifetimeScopeToken = NewScopeService.GetToken();
//    request.Properties.Add("newLifetimeScopeToken", NewLifetimeScopeToken);
//}
