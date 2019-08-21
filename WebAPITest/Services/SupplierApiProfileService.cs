using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPITest.Repositorys;

namespace WebAPITest.Services
{
    public class SupplierApiProfileService: ISupplierApiProfileService
    {
        ISupplierRepository _supplierRepository;
        public SupplierApiProfileService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public Guid GetToken()
        {
            return _supplierRepository.Get();
        }
    }
}