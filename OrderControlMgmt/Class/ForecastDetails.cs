using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderControlMgmt.Class
{
    public class ForecastDetails
    {
        //public bool Check { get; set; }

        //public string Status { get; set; }

        public int No { get; set; }

        public string FCNo { get; set; }       
        public string InHouseNo { get; set; }
        public string PartNo { get; set; }
        public string PartName { get; set; }
        public string Rev { get; set; }        
        //public DateTime DateCreated { get; set; }
        //public DateTime DateRequired { get; set; }
        public int Qty { get; set; }
        public string UOM { get; set; }           
        public string Remarks { get; set; }
        public string PDSNo { get; set; }
        public string LotNo { get; set; }
        public string POStatus { get; set; }
        public DateTime Date { get; set; }
    }
}
