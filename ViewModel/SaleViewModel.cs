using AppCRUDOp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCRUDOp.ViewModel
{
    public class SaleViewModel
    {
        public DateTime SaleDate { get; set; }

        public List<Item> Items { get; set; }

        public string StoreLocation { get; set; }

        public Customer Customer { get; set; }

        public bool CouponUsed { get; set; }

        public string PurchaseMethod { get; set; }
    }
}
