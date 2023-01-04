using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Auto_Delete_File_App
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create 2 Variabel for Folder Path and Time Line

            var path = ConfigurationManager.AppSettings["path"];
            var time_line = ConfigurationManager.AppSettings["time_line"];            
            

            string[] files = Directory.GetFiles(@path);

            foreach(string file in files)
            {   
                FileInfo fi = new FileInfo(file);
                DateTime Cr_date = fi.CreationTime;

                if (Cr_date < DateTime.Now.AddMinutes(Convert.ToInt32(time_line)))
                    fi.Delete();
                Console.WriteLine($"File  Creation date: {Cr_date}");

            }
            Console.WriteLine($"Files Deleted older then {time_line} days..");
            Console.ReadKey();
        }
    }
}




