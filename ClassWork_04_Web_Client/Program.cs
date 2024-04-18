using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ClassWork_04_Web_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Uri uri = new Uri("http://mail.ru");
            Uri uri = new Uri("https://news.mail.ru/incident/");
            HttpWebRequest web = (HttpWebRequest)HttpWebRequest.Create(uri);
            HttpWebResponse resp = (HttpWebResponse)web.GetResponse();


            web.Method = "GET";

            //web.Method = "POST";
            //StreamWriter sw = new StreamWriter(web.GetRequestStream());
            //sw.WriteLine($"fommail = 1");

            //web.Headers;

            Console.WriteLine("Status code: " + resp.StatusCode);

            Console.WriteLine("\nRequest headers");
            foreach (string key in web.Headers.Keys)
            {   // key : value
                string val = web.Headers[key];
                Console.WriteLine($"{key} : {val}");
            }
            //web.GetRequestStream();

            

            Console.WriteLine("\nResponse headers");
            foreach (string key in resp.Headers.Keys)
            {   // key : value
                string val = resp.Headers[key];
                Console.WriteLine($"{key} : {val}");
            }

            Console.WriteLine("\n----------------\n");
            StreamReader sr = new StreamReader(resp.GetResponseStream());

            Console.WriteLine(sr.ReadToEnd());

            sr.Close();

            Console.WriteLine("Main good bye...");
            Console.ReadLine();
        }
    }
}
