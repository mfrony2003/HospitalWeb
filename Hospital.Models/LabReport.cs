using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class LabReport
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public LabReportCategory LabReportCategory { get; set; }




    }
}