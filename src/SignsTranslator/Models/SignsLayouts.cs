using System.ComponentModel.DataAnnotations.Schema;

namespace SignsTranslator.Models
{
    public class SignsLayouts
    {
        [ForeignKey("SignId")]
        public int SignId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string LayoutId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string PDFDefinition { get; set; }


        [Column(TypeName = "nvarchar(250)")]
        public string ImageThumbnail { get; set; }
    }
}