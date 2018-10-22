using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchSystem.BLL
{
    public partial class WebSchNewShowV
    {
        private readonly SchSystem.DAL.WebSchNewShowV dal = new SchSystem.DAL.WebSchNewShowV();
        public WebSchNewShowV()
        {

        }
        public DataSet GetList(string cols, string strWhere)
        {
            return dal.GetList(cols, strWhere);
        }
    }
}
