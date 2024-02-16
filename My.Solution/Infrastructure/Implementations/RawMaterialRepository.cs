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
    public class RawMaterialRepository :IRawMaterialRepository
    {
        private MaterialInfoDbContext _context;

        public RawMaterialRepository(MaterialInfoDbContext context) 
        {
        
            _context = context;
        
        }

        public async Task<IEnumerable<RawMaterialVM>> MaterialGetAll()
        {
            var rawMaterial = new List<RawMaterialVM>();
            var RawMaterials = await _context.RawMaterials.ToListAsync();
            if(RawMaterials != null && RawMaterials.Count()>0)
            {
                foreach(var rawMaterialVM in RawMaterials)
                {
                    rawMaterial.Add(new RawMaterialVM()
                    {
                        MaterialName = rawMaterialVM.MaterialName,
                        MaterialId = rawMaterialVM.MaterialId,
                    });
                }

                return rawMaterial;
            }
            //return new List<RawMaterialVM>();
            return rawMaterial;

        }


    }
}
