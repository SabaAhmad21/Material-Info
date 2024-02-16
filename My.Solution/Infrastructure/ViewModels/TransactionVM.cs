using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModels
{
    public class TransactionVM
    {
        public int TransactionId { get; set; }

        public string Name { get; set; } = null!;

        public int TotalPrice { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime TransactionDate { get; set; }

        public string  Supplier { get; set; }
    }

    public class TransactionCreateVM
    {
       
        public TransactionCreateVM() 
        
        {
            Suppliers = new List<SupplierVM>();
        
        }
        [Required(ErrorMessage ="Name Required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "TotalPrice Required")]
        public int TotalPrice { get; set; }

        [Required(ErrorMessage = "CreatedDate Required")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "TransactionDate Required")]
        public DateTime TransactionDate { get; set; }

        [Required(ErrorMessage = "Select")]
        [Range(1, int.MaxValue)]
        public int SupplierId { get; set; }

        public IEnumerable<SupplierVM> Suppliers { get; set; }
    }

    public class TransactionUpdateVM
    {

        public TransactionUpdateVM()

        {
            Suppliers = new List<SupplierVM>();

        }

        [Range(1, int.MaxValue)]
        [Required]
        public int TransactionId { get; set; }

        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "TotalPrice Required")]
        public int TotalPrice { get; set; }

        [Required(ErrorMessage = "CreatedDate Required")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "TransactionDat Required")]
        public DateTime TransactionDate { get; set; }

        [Required(ErrorMessage = "Supplier Name Required")]
        public string Supplier { get; set; }

        [Required(ErrorMessage = "Name Required")]
        [Range(1, int.MaxValue)]
        public int SupplierId { get; set; }

        public IEnumerable<SupplierVM> Suppliers { get; set; }
    }
}
