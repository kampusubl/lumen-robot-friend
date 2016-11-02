using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text;

namespace FPSNas
{
    class koneksi
    {
        public static void uploadFTP(string srcFilePath, string ftpUserName, string ftpPassword, string targetFilePath)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(srcFilePath);
            request.Credentials = new NetworkCredential(
            ftpUserName, ftpPassword);
            request.Proxy = null;
            request.UseBinary = false;
            request.UsePassive = true;
            request.Method = WebRequestMethods.Ftp.UploadFile;
            StreamReader sourceStream = new StreamReader(targetFilePath);
            byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            response.Close();
        }
    }

   
}
