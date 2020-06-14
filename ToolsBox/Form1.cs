using FontAwesome.Sharp;
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
using System.Configuration;
using System.IO;
using System.Drawing.Imaging;

namespace ToolsBox
{
    public partial class Form1 : Form
    {
        string Url = ConfigurationManager.AppSettings["台灣雲端書庫網址"];
        string f = "jpg";
        string r = "150";
        string preferWidth = "757";
        string preferHeight = "1600";
        
        WebClient webClient=new WebClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string[] paramsData = new string[] { "f=" + f, r, "preferWidth=" + preferWidth, "preferHeight=" + preferHeight, "bookToken=" + txtBookToken.Text, "token=" + txtToken.Text, "bookId=" + txtBookID.Text };
            string queryString = string.Join("&", paramsData);
            for (int i = (int)txtMin.Value; i <= (int)txtMax.Value; i++)
            {
                byte[] data = webClient.DownloadData(Url + i + "&" + queryString);
                MemoryStream ms = new MemoryStream(data);
                Image img = Image.FromStream(ms);
                img.Save($@"D:\{txtBookName.Text.Trim()}\" + i + ".jpg");
            }
            MessageBox.Show("完成");
        }
    }
}
