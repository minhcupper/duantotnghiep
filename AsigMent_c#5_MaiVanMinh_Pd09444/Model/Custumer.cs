using System.ComponentModel.DataAnnotations;

namespace AsigMent_c_5_MaiVanMinh_Pd09444
{
    public class CustuMer
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string diachi { get; set; }
        [Required]
        public int sdt { get; set; }
    }
}
