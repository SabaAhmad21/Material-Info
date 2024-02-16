using Domain;
using Infrastructure.Interfaces;
using Infrastructure.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementations
{
    public class SupplierRepository :ISupplierRepository
    {
        private MaterialInfoDbContext _context;

        public SupplierRepository(MaterialInfoDbContext context) 
        { 
         _context = context;
        }

        public async Task<IEnumerable<SupplierVM>> SupplierGetAll()
        {
            var supplier = new List<SupplierVM>();
            var Suppliers = await _context.Suppliers.ToListAsync();

            if(Suppliers != null && Suppliers.Count()>0)
            {
                foreach(var SupplierVM in Suppliers)
                {
                    supplier.Add(new SupplierVM()
                    {

                        SupplierId = SupplierVM.SupplierId,
                        SupplierName = SupplierVM.SupplierName,
                    });
                }
                return supplier;

            }
            //return new List<SupplierVM>();
            return supplier;
        }
    }
}
