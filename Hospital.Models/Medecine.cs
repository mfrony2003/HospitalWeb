using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Medecine
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public MedecineCategory MedecineCategory { get; set; }


    }
}