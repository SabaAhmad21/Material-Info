using System;
using System.Collections.Generic;

namespace Domain;

public partial class TransactionDetail
{
    public int TransDetailsId { get; set; }

    public int Quantity { get; set; }

    public int NoOfItems { get; set; }

    public decimal Price { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public int? TransactionId { get; set; }

    public int? MaterialId { get; set; }

    public int? SupplierId { get; set; }

    public virtual RawMaterial? Material { get; set; }

    public virtual Supplier? Supplier { get; set; }

    public virtual Transaction? Transaction { get; set; }
}
