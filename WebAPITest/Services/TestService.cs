using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using WebAPITest.Repositorys;

namespace WebAPITest.Services
{
    public class TestService : ITestService
    {
        ISupplierRepository _supplierRepository;
        IComponentContext _componentContext;
        ISupplierApiProfileService _supplierApiProfileService;
        public TestService(ISupplierRepository supplierRepository , IComponentContext componentContext,ISupplierApiProfileService supplierApiProfileService)
        {
            _supplierRepository = supplierRepository;
            _componentContext = componentContext;
            _supplierApiProfileService = supplierApiProfileService;
        }

        public Guid GetToken()
        {
            return _supplierRepository.Get();
        }

        public Guid GetToken2()
        {
            var token1 = _componentContext.Resolve<ISupplierApiProfileService>().GetToken();

            var token2 = _supplierApiProfileService.GetToken();
            return token1;
        }
    }
}