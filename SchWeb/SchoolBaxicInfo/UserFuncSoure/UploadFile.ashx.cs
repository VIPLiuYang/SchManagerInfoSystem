using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace SchWeb.SchoolBaxicInfo.UserFuncSoure
{
    /// <summary>
    /// UploadFile1 的摘要说明
    /// </summary>
    public class UploadFile1 : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string msg = string.Empty;
            string error = string.Empty;
            string fileNewName = string.Empty;
            string result = string.Empty;
            bool resBool = false;
            Com.DataPack.DataRsp<Com.DataPack.UserInfo> rsp = Com.Public.UserFuncSoure(Com.SoureSession.jsid, Com.SoureSession.jstoken);
            if (rsp.code == "ERROR_TOKEN")
            {
                error = "登录失效！";
                result = "{ error:'登录失效',status:'error'}";
            }
            else
            {
                context.Response.ContentType = "text/plain";
                HttpFileCollection files = HttpContext.Current.Request.Files;
                SchManagerInfoSystem.Common.UploadFile uploadf = new SchManagerInfoSystem.Common.UploadFile();

                uploadf.Path = "UploadFileDir\\Users";//设置上传文件路径
                uploadf.FileType = "jpg|gif|bmp|jpeg|png";//设置上传文件格式
                uploadf.Sizes = 100;//设置上传文件的大小,默认100KB


                if (files.Count > 0)
                {
                    fileNewName = uploadf.SaveAs(files);//保存上传文件到服务器
                    if (fileNewName == "0")
                    {
                        error = "文件上传失败！";
                        result = "{ error:'上传的图片不能大于100KB',status:'success01'}";
                    }
                    else if (fileNewName == "1")
                    {
                        error = "文件上传失败！";
                        result = "{ error:'出现未知错误',status:'success02'}";
                    }
                    else
                    {
                        SchSystem.BLL.SchUserInfo suiBll = new SchSystem.BLL.SchUserInfo();
                        try
                        {
                            resBool = suiBll.UploadPicture(int.Parse(Com.SoureSession.Soureusertid), int.Parse(Com.SoureSession.Soureschid), fileNewName);
                            Com.SoureSession.Soureimgurl = fileNewName;
                        }
                        catch (Exception e)
                        {
                            error = e.Message;
                        }
                        if (resBool)
                        {
                            msg = "文件上传成功！";
                            result = "{msg:\"" + msg + "\",filenewname:\"" + fileNewName.Replace("\\", "/") + "\"}";
                        }
                        else
                        {
                            error = "文件上传失败！";
                            result = "{ error:'" + error + "'}";
                        }
                    }
                }
                else
                {
                    error = "文件上传失败！";
                    result = "{ error:'" + error + "'}";
                }
              
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