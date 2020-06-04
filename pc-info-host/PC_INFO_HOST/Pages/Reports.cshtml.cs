using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PC_INFO_HOST.Models;

namespace PC_INFO_HOST.Pages
{
    public class ReportsModel : PageModel
    {
        ReportSearch rs = new ReportSearch();
        public List<string> Path { get; private set; }

        public void OnGet()
        {
            Path = rs.GetReports();
        }
    }
}