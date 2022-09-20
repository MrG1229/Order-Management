using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderControlMgmt.Class
{
    public class PODetails
    {
        //public bool Check { get; set; }

        //public string Status { get; set; }

        public int No { get; set; }

        public string PPONo { get; set; }
        public string PaperPONo { get; set; }
        public string PODetailNo { get; set; }
        public string InHouseNo { get; set; }
        public string PartNo { get; set; }
        public string PartName { get; set; }
        public string Rev { get; set; }
        public string CustNickName { get; set; }
        public DateTime PODate { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ReqDate { get; set; }
        public int POQty { get; set; }
        public string UOM { get; set; }      
        public decimal ItemUnitPrice { get; set; }
        public decimal POTotalAmount { get; set; }
        public string Currency { get; set; }
        public string Remarks { get; set; }
        public string PDSNo { get; set; }
        public string LotNo { get; set; }
        public string POStatus { get; set; }
        
    }
}
