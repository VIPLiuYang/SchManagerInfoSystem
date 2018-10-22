using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SchWebAdmin
{
    /// <summary>
    /// UpUserImg 的摘要说明
    /// </summary>
    public class UpUserImg : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string userid = context.Request.Params["userid"].ToString();
            SchWebAdmin.UserApi.DataRsp rsp = new SchWebAdmin.UserApi.DataRsp();
            if (string.IsNullOrEmpty(userid))
            {
                context.Response.Write("非法链接!");
                context.Response.End();
            }
            try
            {
                HttpPostedFile file = context.Request.Files[0];
                if (file != null)
                {
                    string oldFileName = file.FileName;//原文件名                    
                    int size = file.ContentLength;//附件大小
                    string extenstion = oldFileName.Substring(oldFileName.LastIndexOf(".") + 1).ToLower();//后缀名
                    //根据后缀名判断文件类型,并控制文件大小
                    if (size > 1024 * 1024 * 2)
                    {
                        rsp.RspCode = "0011";
                        rsp.RspTxt = "文件不能大于2M";
                    }
                    else
                    {
                        if (extenstion.IndexOf("jpg") > -1 || extenstion.IndexOf("jpeg") > -1 || extenstion.IndexOf("png") > -1 || extenstion.IndexOf("gif") > -1)
                        {
                            string newFileName = GetNewFileName(oldFileName, userid);//生成新文件名
                            //LogTextHelper.Info(newFileName);
                            #region 上传到远程服务器
                            //FileServerManage fsw = new FileServerManage();
                            //string uploadFilePath = "/" + newFileName;
                            //if (!string.IsNullOrEmpty(folder))
                            //{
                            //    uploadFilePath = string.Format("/{0}/{1}", folder, newFileName);
                            //}
                            //bool uploaded = fsw.UploadFile(file.InputStream, "/" + folder + "/" + newFileName); 
                            #endregion
                            #region 本地服务器上传
                            //AppConfig config = new AppConfig();
                            string uploadFiles = "";// config.AppConfigGet("uploadFiles");
                            if (string.IsNullOrEmpty(uploadFiles))
                            {
                                uploadFiles = "UploadFileDir";
                            }
                            string uploadPath = Path.Combine(HttpContext.Current.Server.MapPath("~/"), uploadFiles, userid);
                            if (!Directory.Exists(uploadPath))
                            {
                                Directory.CreateDirectory(uploadPath);
                            }
                            ;
                            string fileurl = context.Request.Url.Authority + context.Request.ApplicationPath + "/" + uploadFiles + "/" + userid + "/" + newFileName;
                            string newFilePath = Path.Combine(uploadPath, newFileName);
                            //LogTextHelper.Info(newFilePath);
                            file.SaveAs(newFilePath);
                            bool uploaded = File.Exists(newFilePath);
                            #endregion
                            if (uploaded)
                            {
                                SchSystem.BLL.SchUserInfo suiBll = new SchSystem.BLL.SchUserInfo();
                                suiBll.UploadPicture(int.Parse(userid), Path.Combine(uploadFiles, userid, newFileName));
                                rsp.RspData = fileurl;

                                #region 文件保存成功后，写入附件的数据库记录

                                #endregion
                            }
                        }
                        else
                        {
                            rsp.RspCode = "0011";
                            rsp.RspTxt = "文件格式不符合要求,请上传jpg,jpeg,png,gif文件";
                        }
                    }

                    
                }
                else
                {
                    rsp.RspCode = "0011";
                    rsp.RspTxt = "上传文件失败";
                    //LogTextHelper.Error("上传文件失败");
                }
            }
            catch (Exception ex)
            {
                rsp.RspCode = "0011";
                rsp.RspTxt = "上传文件失败:" + ex.Message;
            }
            finally
            {
                context.Response.Write(JsonConvert.SerializeObject(rsp));
            }
        }
        public static string GetNewFileName(string fileName,string userid)
        {
            if (string.IsNullOrEmpty(fileName))
                return string.Empty;
            //文件后缀名
            string extenstion = fileName.Substring(fileName.LastIndexOf(".") + 1);
            string name = userid + DateTime.Now.ToString("yyyyMMddhhmmssfff");// fileName.Substring(0, fileName.LastIndexOf(".")) + "(" + DateTime.Now.ToFileTime() + ")";
            string newFileName = name + "." + extenstion;
            return newFileName;
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