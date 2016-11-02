using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text;

namespace FPSNas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var fileName = Path.GetFileName(@"C:\jajal.jpg");
            var request = (FtpWebRequest)WebRequest.Create("ftp://167.205.66.69/coba/" + fileName);

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("admin", "lumen");
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            using (var fileStream = File.OpenRead(@"C:\jajal.jpg"))
            {
                using (var requestStream = request.GetRequestStream())
                {
                    fileStream.CopyTo(requestStream);
                    requestStream.Close();
                }
            }

            var response = (FtpWebResponse)request.GetResponse();
            Console.WriteLine("Upload done: {0}", response.StatusDescription);
            response.Close();
        }
    }
}
