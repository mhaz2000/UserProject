using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class User
    {
        public User()
        {
        }
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public Guid UserID { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name="نام")]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name="نام خانوادگی")]
        public string Family { get; set; }
        [Required]
        [MaxLength(11)]
        [Display(Name="شماره تلفن")]
        public string Phone { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name="کد ملی")]
        public string NationalCode { get; set; }
        [Display(Name="زمان ورود")]
        public DateTime? ArrivalTime { get; set; }
        [Display(Name="زمان خروج")]
        public DateTime? ExitTime { get; set; }

        [Display(Name="مدت زمان کار")]
        public string WorkingTime { get; set; }

        [Display(Name="ساعت ورود")]
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string ArrivalHour { get; set; }

        [Display(Name="تاریخ ورود")]
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string ArrivalDate { get; set; }

        [Display(Name="ساعت خروج")]
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string ExitHour { get; set; }

        [Display(Name="تاریخ خروج")]
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string ExitDate { get; set; }
    }
}
