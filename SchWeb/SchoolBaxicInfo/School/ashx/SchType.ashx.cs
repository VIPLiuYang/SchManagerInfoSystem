using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace SchWeb.SchoolBaxicInfo.School.ashx
{
    /// <summary>
    /// SchType 的摘要说明
    /// </summary>
    public class SchType : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string Action = context.Request.Form["Action"];
            if (Action == "Add")
            {
                int resulte;
                try
                {
                    SchSystem.Model.SchType st = new SchSystem.Model.SchType();
                    st.SchTypeCode = int.Parse(context.Request.Form["SchTypeCode"]);
                    st.SchTypeName = context.Request.Form["SchTypeName"];
                    st.Stat = Convert.ToInt32(context.Request.Form["Stat"]);
                    st.NOTE = context.Request.Form["NOTE"];

                    SchSystem.Bll.SchTypeBll stBll = new SchSystem.Bll.SchTypeBll();
                    resulte = stBll.Add(st);
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    throw e;
                }
                context.Response.Write(resulte);
            }
            else if (Action == "List")
            {
                SchSystem.Bll.SchTypeBll stBll = new SchSystem.Bll.SchTypeBll();
                //stBll.GetAllList();
                context.Response.Write(DatasetToJson(stBll.GetAllList()));
            }
        }

        /// <summary> 
        /// DataSet转换成Json格式 
        /// </summary> 
        /// <paramname="ds">DataSet</param> 
        ///<returns></returns> 
        public static string DatasetToJson(DataSet ds, int total = -1)
        {
            StringBuilder json = new StringBuilder();

            foreach (DataTable dt in ds.Tables)
            {
                //{"total":5,"rows":[ 
                json.Append("{\"total\":");
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
                json.Append("]}");
            }
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
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}