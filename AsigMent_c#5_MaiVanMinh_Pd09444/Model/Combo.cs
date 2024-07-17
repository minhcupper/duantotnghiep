using System.ComponentModel.DataAnnotations;

namespace AsigMent_c_5_MaiVanMinh_Pd09444.Model
{
    public class Combo
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string anh { get; set; }
        [Required]
        public string namecombo { get;set; }
        [Required]
        public double price { get; set; }
       // public ICollection<food> foods { get; set; }
    }
}
