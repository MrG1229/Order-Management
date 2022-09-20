using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
//
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace OrderControlMgmt
{   
    public class GetData
    {
        Variables v = new Variables();
        //frmOrderCtrl orderCtrl = new frmOrderCtrl();

        public string GetFilePath(string Value)
        {
            v.TextBoxPath = Value;

            return v.TextBoxPath;
        }
    }
}
