using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;

namespace SignsTranslator.Models
{
    public class Signs
    {
        [Key]
        public int SignId { get; set; }
        
      

        [Column(TypeName = "nvarchar(250)")]

        public int LanguageID { get; set; }
        public string Text { get; set; }
        public ICollection<SignsLayouts> SignsLayouts { get; set; }

        public int ApproverID { get; set; }



        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("Svenska")]
        public string Swedish { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("English")]
        public string English { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("русский")]
        public string Russian { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("العريبة")]
        public string Arabic { get; set; }
    }
}
