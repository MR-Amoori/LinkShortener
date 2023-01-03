using System;
using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Models
{
    public class ShortUrl
    {
        [Key]
        public int LinkId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required(ErrorMessage = "وارد کردن لینک اجباری است")]
        [Display(Name = "لینک ورودی")]
        [DataType(DataType.Url, ErrorMessage = "لطفا فرمت لینک کامل باشد")]
        public string Link { get; set; }

        public string ShortLink { get; set; }

        public int Visit { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public User User { get; set; }
    }


    public class Script
    {
        [Key]
        public int ScriptId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [Display(Name = "اسکریپت")]
        public string script { get; set; }

        public string ShortLink { get; set; }

        public int Visit { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
    
        public User User { get; set; }

    }
}
