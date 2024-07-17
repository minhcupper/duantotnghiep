using System.ComponentModel.DataAnnotations;

namespace AsigMent_c_5_MaiVanMinh_Pd09444.Model
{
    public class food
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string anh { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string thểloại { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int comboid { get; set; }
       //public virtual Combo Combo { get; set; }

    }
}
