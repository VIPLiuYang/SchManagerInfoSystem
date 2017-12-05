using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchManagerInfoSystem.Common
{
    public class Function
    {
        public static string DatSetToJSON2(DataSet ds,string key)
        {
            StringBuilder json = new StringBuilder();
            foreach (DataTable dt in ds.Tables)
            {
                json.Append("\"");
                json.Append(key);
                json.Append("\"");
                json.Append(":[");
                json.Append(DataTableToJson(dt));
                json.Append("]");
            }
            return json.ToString();
        }
        /// <summary> 
        /// DataSet转换成Json格式 
        /// </summary> 
        /// <paramname="ds">DataSet</param> 
        ///<returns></returns> 
        public static string DatasetToJson(DataSet ds, int total = -1, string pages = "", int PageCount = 0, int RowCount = 0, int PageIndex = 0)
        {
            StringBuilder json = new StringBuilder();

            json.Append("{");

            foreach (DataTable dt in ds.Tables)
            {
                //{"total":5,"rows":[ 
                json.Append("\"total\":");
                if (total == -1)
                {
                    json.Append(dt.Rows.Count);
                }
                else
                {
                    json.Append(total);
                }
                json.Append(",\"rows\":[");
                json.Append(DataTableToJson(dt));
                json.Append("]");
            }
            if (pages != "")
            {
                json.Append(",\"pages\":\"");
                json.Append(pages);
                json.Append("\"");
            }
            if (PageCount != 0)
            {
                json.Append(",\"PageCount\":\"");
                json.Append(PageCount);
                json.Append("\"");
            }
            if (RowCount != 0)
            {
                json.Append(",\"RowCount\":\"");
                json.Append(RowCount);
                json.Append("\"");
            }
            if (PageIndex != 0)
            {
                json.Append(",\"PageIndex\":\"");
                json.Append(PageIndex);
                json.Append("\"");
            }
            json.Append("}");
            return json.ToString();
        }
        /// <summary> 
        /// dataTable转换成Json格式 
        /// </summary> 
        /// <paramname="dt"></param> 
        ///<returns></returns> 
        public static string DataTableToJson(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                if (dt.Columns.Count > 0)
                {
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                }
                jsonBuilder.Append("},");
            }
            if (dt.Rows.Count > 0)
            {
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            }

            return jsonBuilder.ToString();
        }
    }
}
