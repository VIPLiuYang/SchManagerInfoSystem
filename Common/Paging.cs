using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace Common
{
    public class Paging
    {
        private string pagedNum;  //定义分页条，输出到前台    
        private int pageSize;     // 定义每页有多少条数据量.    
        private string url;       //获取当前页
        private int countNum;    //总条数
        private int PageIndex;//当前页

        public Paging(int pageSize, int countNum, string url, int PageIndex)
        {
            this.pageSize = pageSize;
            //this.url = HttpContext.Current.Request.Url.LocalPath;
            this.countNum = countNum;
            this.url = url;
            this.PageIndex = PageIndex;
        }
        //定义样式a标签第一个样式    
        private readonly string csstagA = @"<a href='{0}?page={1}' >{2}</a>";            //{0}{1}{2}代表url和参数名，参数值，页码值    
        //定义样式a标签第二个样式    
        //private readonly string csstagA1 = "<a style='font-size:13px;font-weight:bold;margin:0 4px 0 4px'>{0}</a>";
        private readonly string csstagA1 = "<span class='pc'>{0}</span>";


        public delegate int GetDelegate();


        /// <summary>    
        /// 生成分页条    
        /// </summary>    
        /// <param name="pageIndex">当前页</param>    
        /// <param name="del">获得数据条数的方法</param>    
        /// <returns></returns>    
        public string GetPageing()
        {
            pagedNum = GetPagegNum(PageIndex, GetPageCount(PageIndex, countNum));
            return pagedNum;
        }

        private int GetPageCount(int pageIndex, int countPage)     //获得总页数    
        {
            int Count = 0;
            Count = countPage;
            double c = Count * 1.0 / pageSize;
            return (int)Math.Ceiling(c);
        }


        private string GetPagegNum(int pageIndex, int pageCount)           //类似   < 1 ... 7 8 9 ⑩ 11 12 13 14 >  ⑩是当前选中页    
        {
            StringBuilder sb = new StringBuilder();
            List<int> ns = new List<int>();              //用于接收当前页范围内的数字    
            string[] numList = new string[12];           //12个字符串数组，存放分页条数据    
            numList[0] = "";       //“上一页”位置    
            numList[11] = "";      //“下一页”位置        
            if (pageIndex > 1)                                         //判断当前页    
            {
                numList[0] = string.Format(csstagA, url, (pageIndex - 1), "<");//上一页
            }
            if (pageIndex < pageCount)
            {
                numList[11] = string.Format(csstagA, url, (pageIndex + 1), ">");//下一页
            }
            if (pageIndex >= 10)    //当前页大于10页的状态    
            {
                //主要的    
                numList[1] = string.Format(csstagA, url, 1, 1);
                numList[2] = "...";
                //int index = 0;    
                if (pageIndex + 4 >= pageCount)    //如果当前页加4页小于总页数    
                {
                    for (int i = pageCount - 7; i < pageCount + 1; i++)
                    {
                        //index = i;    
                        ns.Add(i);
                    }
                    for (int j = 0; j <= 7; j++)    //遍历ns页码值填充到分页条    
                    {
                        if (ns[j] == pageIndex)     //判断是否为当前页码，来使用不同css样式    
                        {
                            numList[j + 3] = string.Format(csstagA1, ns[j]);  //因为字符串数组前3位分别为“上一页”，“1”，“...”,所以从第四位填充7个    
                        }
                        numList[j + 3] = string.Format(csstagA, url, ns[j], ns[j]);
                    }
                }
                for (int i = pageIndex - 3; i <= pageIndex + 4; i++)
                {
                    //index = i;    
                    ns.Add(i);
                }
                for (int j = 0; j <= 7; j++)
                {
                    if (ns[j] == pageIndex)
                    {
                        numList[j + 3] = string.Format(csstagA1, ns[j]);
                    }
                    else
                    {
                        numList[j + 3] = string.Format(csstagA, url, ns[j], ns[j]);
                    }
                }
            }
            else   //10页以下的状态    
            {
                if (pageCount >= 10)               //页数大于等于10    
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        if (i == pageIndex)
                        {
                            numList[i] = string.Format(csstagA1, i);
                        }
                        else
                        {
                            numList[i] = string.Format(csstagA, url, i, i);
                        }
                    }
                }
                else            //页数小于10    
                {
                    for (int i = 1; i <= pageCount; i++)
                    {
                        if (i == pageIndex)
                        {
                            numList[i] = string.Format(csstagA1, i);
                        }
                        else
                        {
                            numList[i] = string.Format(csstagA, url, i, i);
                        }
                    }
                }
            }
            sb.Append("<li class='page'>");
            for (int i = 0; i < numList.Length; i++)   //将字符串数组填入StringBulider中    
            {
                sb.Append(numList[i]);
            }

            //sb.AppendFormat(" 共{0}/{1}条", pageIndex, pageCount);
            sb.Append("</li>");
            return sb.ToString();   //返回，并在前台 <span id="pagedspan"><%=pagedNum %></span>    
        }
        
    }
}
