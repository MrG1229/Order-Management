using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderControlMgmt.Class
{
    public class SalesInvoiceDetails
    {
        public Boolean CHK { get; set; }

        public string DR_no { get; set; }

        public string SDSNo { get; set; }

        public string PPONo { get; set; }

        public string PaperPONo { get; set; }

        public string PODetailNo { get; set; }

        public string InHouseNo { get; set; }

        public string PartNo { get; set; }

        public string PartName { get; set; }

        public int DelQty { get; set; }

        public string UOM { get; set; }

        public decimal ItemUnitPrice { get; set; }

        public decimal TotalAmount { get; set; }

        public string Currency { get; set; }

        //public string Rev { get; set; }



        //public DateTime OrderDate { get; set; }

        

        public string CustNickName { get; set; }

        public DateTime Delivery_date { get; set; }

        public string SINo { get; set; }

        public string CustomerName { get; set; }

        public DateTime DateCreated { get; set; }

        public int Terms { get; set; }

    }
}
