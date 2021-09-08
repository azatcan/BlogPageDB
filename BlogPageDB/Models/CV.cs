using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageDB.Models
{
    public class CV
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Summary { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }

        public Users Users { get; set; }
    }
}
