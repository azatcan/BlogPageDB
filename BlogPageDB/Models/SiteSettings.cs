using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageDB.Models
{
    public class SiteSettings
    {
        public int Id { get; set; }

        public bool Maintenance { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Keywords { get; set; }

        public bool IsDarkMode { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Instagram { get; set; }

        public string Youtube { get; set; }

    }
}
