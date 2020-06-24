using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SignsTranslator.Models
{
    public class DashBoard
    {
        [Key]
        public int ID { get; set; }

        public  string AdminName { get; set; }

        public  string Password { get; set; }
    }
}
