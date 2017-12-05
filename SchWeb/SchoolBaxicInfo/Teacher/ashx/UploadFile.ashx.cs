using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SchWeb.SchoolBaxicInfo.Teacher.ashx
{
    /// <summary>
    /// UploadFile 的摘要说明
    /// </summary>
    public class UploadFile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            #region 上传附件，并返回附件的路径！
            if (action == "upload")
            {
                HttpPostedFile file = context.Request.Files["Filedata"];
                string folder = context.Request["folder"],
                    id = context.Request["id"],
                    value = context.Request["id"];
                string uploadPath = HttpContext.Current.Server.MapPath("../../UploadFileDir/Teacher/") + "\\";

                if (file != null)
                {
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }
                    //对文件进行重命名，防止文件重复
                    string name = file.FileName;//获取上传的文件名 
                    string ext = System.IO.Path.GetExtension(name);// 获取文件的扩展名，比如 .gif    
                    Random rnd = new Random();
                    string newname = DateTime.Now.ToString("yyyyMMddHHmmssffff") + rnd.Next(1000, 9999) + ext;//利用时间生成新文件名后再加扩展名生成完整名字  
                    string path = uploadPath + newname;//保存的路径，注意一定要有load目录，不然会错     
                    file.SaveAs(path);
                    //下面这句代码缺少的话，上传成功后上传队列的显示不会自动消失
                    context.Response.Write("{ \"id\": \"" + id + "\", \"status\": true, \"message\": \"上传成功!\", \"value\": \"" + value + "\", \"url\": \"" + path.Replace("\\", ",") + "\" }");
                }
                else
                {
                    context.Response.Write("{ \"id\": null, \"status\": false, \"message\": \"上传失败!\", \"value\": null, \"url\": null }");
                }
            }
            #endregion


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