using System;
using System.Collections.Generic;

namespace Domain;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public string Name { get; set; } = null!;

    public int TotalPrice { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime TransactionDate { get; set; }

    public int SupplierId { get; set; }

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual ICollection<TransactionDetail> TransactionDetails { get; set; } = new List<TransactionDetail>();
}
