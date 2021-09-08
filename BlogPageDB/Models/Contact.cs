using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageDB.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }

        public Users Users { get; set; }

    }
}
