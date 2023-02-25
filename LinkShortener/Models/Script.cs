using System;
using System.ComponentModel;
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
        [Display(Name = "نام")]
        public string Customer { get; set; }

        [DisplayName("شماره موبایل")]
        [MaxLength(11, ErrorMessage = "شماره موبایل نمی تواند بیشتر از 11 کاراکتر باشد")]
        [MinLength(11, ErrorMessage = "شماره موبایل نمی تواند کمتر از 11 کاراکتر باشد")]
        [DataType(DataType.PhoneNumber)]
        public string NumberPhone { get; set; }

        public string ShortLink { get; set; }

        public int Visit { get; set; }

        [Required]
        [DisplayName("تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [DisplayName("تاریخ انقضا")]
        public DateTime ExpiryDate { get; set; }
       
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [DisplayName("تاریخ انقضا")]
        public int ExpiryDateNum { get; set; }

        [Display(Name = "فعال باشد؟")]
        public bool IsActive { get; set; }

        public User User { get; set; }

    }
}
