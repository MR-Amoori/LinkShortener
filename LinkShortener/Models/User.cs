using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "وارد کردن نام کاربری الزامی است")]
        [DisplayName("نام کاربری")]
        [MaxLength(100, ErrorMessage = "نام کاربری نمی تواند بیشتر از 100 کاراکتر باشد")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "وارد کردن ایمیل الزامی است")]
        [DisplayName("ایمیل")]
        [MaxLength(100, ErrorMessage = "ایمیل نمی تواند بیشتر از 100 کاراکتر باشد")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "وارد کردن رمز عبور الزامی است")]
        [MaxLength(15, ErrorMessage = "رمز عبور نمی تواند بیشتر از 15 کاراکتر باشد")]
        [MinLength(5, ErrorMessage = "رمز عبور نمی تواند کمتر از 5 کاراکتر باشد")]
        [DisplayName("رمز عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "وارد کردن شماره موبایل الزامی است")]
        [DisplayName("شماره موبایل")]
        [MaxLength(11, ErrorMessage = "شماره موبایل نمی تواند بیشتر از 11 کاراکتر باشد")]
        [MinLength(11, ErrorMessage = "شماره موبایل نمی تواند کمتر از 11 کاراکتر باشد")]
        [DataType(DataType.PhoneNumber)]
        public string NumberPhone { get; set; }

        [DisplayName("ادمین")]
        public bool IsAdmin { get; set; }

        [Display(Name ="فعال")]
        public bool IsActive { get; set; }


        public List<ShortUrl> ShortUrls { get; set; }
        public List<Script> Scripts { get; set; }
    }
}
