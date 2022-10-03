using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceAPI.Models
{
    public class InsuranceDetail
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        public string Coverage { get; set; }

        [Required]
        [Column(TypeName = "varchar(8)")] // DD/MM/YY
        public string ValidityTime { get; set; }

        [Required]
        [Column(TypeName = "varchar(3)")]
        public string CoverageTime { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Price { get; set; }

        [Required]
        [Column(TypeName = "varchar(15)")]
        public string Risk { get; set; }
    }
}
