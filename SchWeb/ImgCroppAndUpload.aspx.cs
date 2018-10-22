using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchWeb
{
    public partial class ImgCroppAndUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 將Base64位碼保存成圖片
        /// </summary>
        /// <param name="SendBase64ImgStr">Base64位碼</param>
        /// <returns></returns>
        [WebMethod]
        public static DataRsp<string> SendBaseImg(string SendBaseImgStr)
        {
            DataRsp<string> rsp = new DataRsp<string>();
            //在配置文件中設置圖片路徑（本案例中暫時沒有使用）
            //string filePath = HttpContext.Current.Server.MapPath("~/" + @System.Configuration.ConfigurationManager.AppSettings["ImagePath"]);
            
            try
            {
                //設置圖片保存路徑
                string fileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString();//年月
                string rootPath = HttpContext.Current.Server.MapPath("~/");
                string ImageFilePath = rootPath + "UploadFileDir/Teacher/" + fileName;
                //判斷路徑是否存在，否則，創建文件夾
                if (System.IO.Directory.Exists(ImageFilePath) == false)
                {
                    System.IO.Directory.CreateDirectory(ImageFilePath);
                }
                
                string base64str = SendBaseImgStr.Substring(SendBaseImgStr.IndexOf(",") + 1);      //将‘，’以前的多余字符串删除
                byte[] bt = Convert.FromBase64String(base64str);//獲取圖片base64
                
                string ImagePath = ImageFilePath+"/" + System.DateTime.Now.ToString("yyyyHHddHHmmss");//定義圖片名稱
                File.WriteAllBytes(ImagePath + ".png", bt); //保存圖片到服務器，然後獲取路徑
                rsp.code = "ImgUpload";
                rsp.msg = "圖片上傳成功";
                rsp.RspData = ImagePath + ".png";//獲取保存后的路徑
                
            }
            catch (Exception e)
            {
                rsp.code = "ExcepExit";
                rsp.msg = e.Message;
            }
            
            return rsp;
        }
        /// <summary>
        /// Resp包
        /// </summary>
        [Serializable]
        public class DataRsp<T>
        {
            /// <summary>
            /// 返回状态码
            /// </summary>
            public string code = "0000";//返回代码
            /// <summary>
            /// 返回说明
            /// </summary>
            public string msg = "正常";//返回代码提示
            /// <summary>
            /// 返回数据包
            /// </summary>
            public T RspData;//数据包
        }


        

    }
}