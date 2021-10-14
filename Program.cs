using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Net.WebSockets;
using System.Net;
using System.Threading.Tasks;

namespace webscraper
{
    class Program
    {

        
        static void Main(string[] args)
        {
            FileStream fs;
            Console.WriteLine("Please give a path to a .txt doc");
            Console.WriteLine("");
            Console.WriteLine("");
            string path = Console.ReadLine().ToString();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Now please where the file should end up and what the name is(do not end with format eg. .jpeg, .png etc.)");
            Console.WriteLine("exsample: C:\\User\\downloads\\[namehere]");
            string endpath = Console.ReadLine().ToString();

            fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            int i = 0;
            int error=0;
            int succ = 0;



            while (sr.Peek() !=-1)
            {
                try
                {
                    if (sr.ReadLine() == "0" || sr.ReadLine() == "")
                    {
                        i++;
                        continue;
                    }
                    else
                    {
                        using (WebClient webClient = new WebClient())
                        {
                            Console.WriteLine("Downloading image " + i.ToString());
                            webClient.DownloadFile(sr.ReadLine(), endpath + i.ToString() + ".jpeg");
                            i++;
                            succ++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("An error has occured on file "+i.ToString());
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                    i++;
                    error++;
                    continue;
                }
                
                
            }
            sr.Close();
            fs.Close();
            Console.WriteLine("");
            Console.WriteLine("Out of " + i.ToString() + " Files " + succ.ToString()+" Were downloaded and "+error.ToString()+" gave back an error");
            Console.WriteLine("");
            Console.WriteLine("Download Is done, press any key to close");
            Console.ReadKey();
        }
    }
}
