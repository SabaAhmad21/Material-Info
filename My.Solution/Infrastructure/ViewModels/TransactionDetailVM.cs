using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Infrastructure.ViewModels
{
    public class TransactionDetailVM
    {

        public int TransDetailsId { get; set; }

        public int Quantity { get; set; }

        public int NoOfItems { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public string Material { get; set; }

        public string Supplier { get; set; }

        public string Transaction { get; set; }
    }

    public class TransactionDetailCreateVM
    {
        public TransactionDetailCreateVM()
        {

            Suppliers = new List<SupplierVM>();
            RawMaterials = new List<RawMaterialVM>();
            Transactions = new List<TransactionVM>();

        }

        public int Quantity { get; set; }

        public int NoOfItems { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }

        [Required(ErrorMessage = "Please Select")]
        [Range(1, int.MaxValue)]
        public int? TransactionId { get; set; }

        [Required(ErrorMessage = "Please Select")]
        [Range(1, int.MaxValue)]
        public int? MaterialId { get; set; }

        [Required(ErrorMessage = "Please Select")]
        [Range(1, int.MaxValue)]
        public int? SupplierId { get; set; }

        public IEnumerable<TransactionVM> Transactions { get; set; }

        public IEnumerable<RawMaterialVM> RawMaterials { get; set; }

        public IEnumerable<SupplierVM> Suppliers { get; set; }
        public Domain.Transaction transaction { get; set; }

    }
    public class TransactionDetailUpdateVM
    {
        public TransactionDetailUpdateVM()
        {

            Suppliers = new List<SupplierVM>();
            RawMaterials = new List<RawMaterialVM>();
            Transactions = new List<TransactionVM>();

        }
        public int TransDetailsId { get; set; }
        public int Quantity { get; set; }

        public int NoOfItems { get; set; }

        public decimal Price { get; set; }

        public DateTime UpdateDate { get; set; }

        [Required(ErrorMessage = "Please Select")]
        [Range(1,int.MaxValue)]
        public int? TransactionId { get; set; }

        [Required(ErrorMessage = "Please Select")]
        [Range(1, int.MaxValue)]
        public int? MaterialId { get; set; }

        [Required(ErrorMessage = "Please Select")]
        [Range(1, int.MaxValue)]
        public int? SupplierId { get; set; }

        public IEnumerable<TransactionVM> Transactions { get; set; }

        public IEnumerable<RawMaterialVM> RawMaterials { get; set; }

        public IEnumerable<SupplierVM> Suppliers { get; set; }
    }
}

