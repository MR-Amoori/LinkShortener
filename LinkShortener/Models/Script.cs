using System;
using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Models
{
    public class Script
    {
        [Key]
        public int ScriptId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [Display(Name = "اسکریپت")]
        public string script { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [Display(Name = "مشتری")]
        public string Customer { get; set; }

        public string ShortLink { get; set; }

        public int Visit { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Display(Name = "فعال باشد؟")]
        public bool IsActive { get; set; }

        public User User { get; set; }

    }
}
