using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace SchWebAdmin.Web.SchInfo
{
    /// <summary>
    /// UploadFile 的摘要说明
    /// </summary>
    public class UploadFile : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string url = HttpContext.Current.Request.Url.Host;
            int port = HttpContext.Current.Request.Url.Port;

            HttpFileCollection files = HttpContext.Current.Request.Files;
            SchManagerInfoSystem.Common.UploadFile uploadf = new SchManagerInfoSystem.Common.UploadFile();

            uploadf.Path = "../../UploadFileDir";//设置上传文件路径
            uploadf.FileType = "jpg|gif|bmp|jpeg|png";//设置上传文件格式
            //uploadf.Sizes = 2000;//设置上传文件的大小,默认200KB

            string msg = string.Empty;
            string error = string.Empty;
            string fileNewName = string.Empty;
            string result = string.Empty;
            bool resBool = false;
            if (files.Count > 0)
            {
                fileNewName = uploadf.SaveAs(files);//保存上传文件到服务器
                if (fileNewName == "0")
                {
                    error = "文件上传失败！";
                    result = "{ error:'上传的图片不能大于2M',status:'success01'}";
                }
                else if (fileNewName == "1")
                {
                    error = "文件上传失败！";
                    result = "{ error:'出现未知错误',status:'success02'}";
                }
                else
                {
                    //SchSystem.BLL.SchUserInfo suiBll = new SchSystem.BLL.SchUserInfo();
                    StringBuilder sbRes = new StringBuilder();
                    //try
                    //{
                    //    resBool = suiBll.UploadPicture(int.Parse(Com.Session.usertid), int.Parse(Com.Session.schid), fileNewName);
                    //    Com.Session.imgurl = fileNewName;
                    //}
                    //catch (Exception e)
                    //{
                    //    error = e.Message;
                    //}
                        msg = "文件上传成功！";
                        result = sbRes.Append("{msg:\"" + msg + "\",filenewname:\"" + fileNewName.Replace("\\", "/").Replace("../../", "/") + "\"}").ToString();
                    
                }
            }
            else
            {
                error = "文件上传失败！";
                result = "{ error:'" + error + "'}";
            }
            context.Response.Write(result);
            context.Response.End();
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