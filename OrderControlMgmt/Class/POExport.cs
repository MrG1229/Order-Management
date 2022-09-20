using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderControlMgmt.Class
{
    public class POExport
    {

        private void copyAlltoClipboard(DataGridView dataview)
        {
            dataview.SelectAll();
            DataObject dataObj = dataview.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        public void ExportToExcelWithFormat(DataGridView dataGridView_show)
        {
            int rownum = 1;
            copyAlltoClipboard(dataGridView_show);
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            for (int colCount = 0; colCount < dataGridView_show.Columns.Count - 5; colCount++)
            {
                Microsoft.Office.Interop.Excel.Range xlRange = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[rownum, colCount + 2];

                xlRange.Value2 = dataGridView_show.Columns[colCount].Name;
                xlRange.Font.Bold = 1;
                xlRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                //object clr = xlRange.Interior.Color;
                //clr = System.Drawing.ColorTranslator.ToOle(Color.LightGreen);
                //xlRange.EntireRow.Interior.Color = clr;
                //xlRange.Range


            }

            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            Microsoft.Office.Interop.Excel.Range rng = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.get_Range("A1", "M" + (dataGridView_show.Rows.Count + 1).ToString());
            //rng.Columns.ColumnWidth = 20; // You can define the columnwith by yoursetf or 
            rng.Columns.AutoFit(); // Use Autofit.
            rng.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            rng.Borders.Weight = 2d;
        }

    }
}
