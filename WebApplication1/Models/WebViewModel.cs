using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class WebViewModel
    {
        [Required]
        [Url]
        public string Url { get; set; }
        public List<string> Images { get; set; }
        public int TotalWordCount { get; set; }
        public List<KeyValuePair<string, int>> TopTenWords { get; set; }
    }
}