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
using System.Security.Policy;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace ClassWork_Task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            Uri uri = new Uri("https://www.gutenberg.org/cache/epub/2265/pg2265.txt");
            HttpWebRequest web = (HttpWebRequest)HttpWebRequest.Create(uri);
            HttpWebResponse resp = (HttpWebResponse)web.GetResponse();

            foreach (string key in resp.Headers.Keys)
            {   // key : value
                string val = resp.Headers[key];
                this.richTxtH.Text += key + ": " + val + "\n";
            }

            StreamReader sr = new StreamReader(resp.GetResponseStream());

            this.richTxt.Text = sr.ReadToEnd();

            sr.Close();
        }

        private void btnStart2_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; ++i)
            {
                // https://gnikdroy.pythonanywhere.com/api/book
                Uri uri = new Uri($"https://gnikdroy.pythonanywhere.com/api/book/?page={i}");
                HttpWebRequest web = (HttpWebRequest)HttpWebRequest.Create(uri);
                HttpWebResponse resp = (HttpWebResponse)web.GetResponse();

                StreamReader sr = new StreamReader(resp.GetResponseStream());
                string jsonResponse = sr.ReadToEnd();
                sr.Close();

                JObject jsonObject = JObject.Parse(jsonResponse);

                JArray resultsArray = (JArray)jsonObject["results"];

                foreach (JObject book in resultsArray)
                {
                    string title = book["title"].ToString();
                    this.richTxtTop.Text += title + "\n";
                }
            }
        }


    }
}
