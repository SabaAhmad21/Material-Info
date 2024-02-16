using System;
using System.Collections.Generic;

namespace Domain;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public virtual ICollection<TransactionDetail> TransactionDetails { get; set; } = new List<TransactionDetail>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
