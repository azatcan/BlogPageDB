using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageDB.Models
{
    public class Users
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public string ProfileImageURL { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Instagram { get; set; }

        public string Youtube { get; set; }

        public string Profession { get; set; }

        public string School { get; set; }

        public string Description { get; set; }

        public string Summary { get; set; }
        
        
        public CV CV { get; set; }
        
        public Contact Contact { get; set; }
        
       
    }
}
