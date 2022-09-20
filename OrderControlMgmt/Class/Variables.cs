using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace OrderControlMgmt
{
    public class Variables
    {
        public string connString = "Data source = 192.168.1.97,1433; User ID = sa; password = sinag_13; Connect Timeout=500; Pooling=False";
        public string ConnString = "Data Source = 192.168.1.97,1433; Initial Catalog =peza_db1; Persist Security Info=True;User ID = sa; Password=sinag_13";
        public string ConnStringpcs = "Data Source = 192.168.1.97,1433; Initial Catalog =pcs_db; Persist Security Info=True;User ID = sa; Password=sinag_13";
        public SqlConnection conn;
        public SqlCommand sqlCommand;
        public string query;
        public SqlDataReader reader;
        public SqlDataAdapter adap;
        public DataTable dt;
        public BindingSource bs;
        public DataSet ds;
        public DataView dv;

        public string PartNo;
        public string InHouseNo;
        public string PartName;
        public string Revision;
        public string CustNickName;
        public string CustID;
        public string CustName;
        public string UOM;
        public string Currency;

        public double UnitPrice;
        public decimal Amount;

        public int SN;

        public string TextBoxPath;
        public string PPONo;
        public string FCNo;
        public DateTime PODate;

        public DateTime ReqDate;

        /////
        public int Qty;
        public int Qty_2;
        public int Remainder = 1;
        public int TQty;
        public int TForecastQty;
        public DateTime DateCreated;
        public string ForeNo;

        //User Variable
        public string CreatedBy;
     
    }
}
