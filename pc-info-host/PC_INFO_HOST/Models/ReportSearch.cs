using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PC_INFO_HOST.Models
{
    public class ReportSearch
    {

        public List<string> GetReports()
        {
            List<string> filesReport = new List<string> { };
            string filePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string targetDirectory = System.IO.Path.GetDirectoryName(filePath);
            //string netcoreapp = System.IO.Directory.GetParent(filePath).FullName;
            //string debugDirectory = System.IO.Directory.GetParent(netcoreapp).FullName;
            //string binDirectory = System.IO.Directory.GetParent(debugDirectory).FullName;
            //string targetDirectory = System.IO.Directory.GetParent(binDirectory).FullName;
            string[] paths = { targetDirectory, "wwwroot" };
            string wwwrootPath = Path.Combine(paths);
            string[] otherPaths = { wwwrootPath, "Reports" };
            string reportsPath = Path.Combine(otherPaths);
            if (!Directory.Exists(reportsPath))
            {
                Directory.CreateDirectory(reportsPath);
            }
            string[] subdirectoryEntries = Directory.GetFiles(reportsPath);
            foreach (string file in subdirectoryEntries)
            {
                string correctPath = "~/Reports/" + Path.GetFileName(file);
                filesReport.Add(correctPath);
            }
            return filesReport;
        }

    }
}
