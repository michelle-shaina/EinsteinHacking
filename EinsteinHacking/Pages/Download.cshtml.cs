using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EinsteinHacking.Pages
{
    public class DownloadModel : PageModel
    {
        private readonly IWebHostEnvironment _env;

        public DownloadModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult OnGet()
        {
            var filePath = Path.Combine(_env.WebRootPath, "img", "Hacking.jpg");

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, "application/force-download", "Hacking.jpg");
        }
    }
}
