using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderControlMgmt.Class
{
    public class PEZA8105Details
    {
        public string ControlNo { get; set; }

        public DateTime DateCreated { get; set; }

        public string SINo { get; set; }

        public string DRNo { get; set; }

        public string DescriptionOfCom { get; set; }

        public int Quantity { get; set; }

        public string Measurement { get; set; }

        public string FinalQty { get; set; }

        public decimal Weight { get; set; }

        public string Measurement_W { get; set; }

        public string FinalWeight { get; set; }

        public string Currency { get; set; }

        public decimal Value { get; set; }

        public string Supplier { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string Carrier { get; set; }

        public string No8106Ref { get; set; }

        public string Custom { get; set; }

        public string DelClass { get; set; }
    }
}
