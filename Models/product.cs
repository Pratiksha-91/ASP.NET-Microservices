using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace servicefirst.Models
{

    [Table("product")]
    public class product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("pid")]
        public int pid { get; set; }

        [Column("pname")]
        public string? pname { get; set; }
    }
}
