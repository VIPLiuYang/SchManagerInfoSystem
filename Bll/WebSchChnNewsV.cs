using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchSystem.BLL
{
    public partial class WebSchChnNewsV
    {
        private readonly SchSystem.DAL.WebSchChnNewsV dal = new SchSystem.DAL.WebSchChnNewsV();
        public WebSchChnNewsV()
        {

        }
        public SchSystem.Model.WebSchChnNewsV GetModel(int NewsId)
        {

            return dal.GetModel(NewsId);
        }
        public DataSet GetList(string cols, string strWhere)
        {
            return dal.GetList(cols, strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListCols(string cols, string strWhere, string ordercols, string orderby, int PageIndex, int PageSize, ref int RowCount, ref int PageCount)
        {
            return dal.GetListCols(cols, strWhere, ordercols, orderby, PageIndex, PageSize, ref RowCount, ref PageCount);
        }
    }
}
