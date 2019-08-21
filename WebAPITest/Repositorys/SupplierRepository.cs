using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPITest.Repositorys
{
    public class SupplierRepository : ISupplierRepository
    {
        private MockDBContext _mockDBContext;
        public SupplierRepository(MockDBContext dbContext)
        {
            this._mockDBContext = dbContext;
        }

        public Guid Get()
        {
            return _mockDBContext.GetID();
        }
    }
}