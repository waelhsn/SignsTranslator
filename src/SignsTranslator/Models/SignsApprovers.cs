using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SignsTranslator.Models
{
    public class SignsApprovers
    {
        [Key]
        public  int ApproverID { get; set; }

        [Column(TypeName = "nvarchar(250)")]

        public string ApproverName { get; set; }
        public  string Password { get; set; }
    }
}
