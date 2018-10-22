using SchManagerInfoSystem.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchSystem.DAL
{
    public partial class WebSchNewShowV
    {
        public WebSchNewShowV()
        {

        }
        public DataSet GetList(string cols, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (cols.Trim() != "")
            {
                strSql.Append(cols);
            }
            strSql.Append(" FROM WebSchNewShowV ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
