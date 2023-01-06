using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LinkShortener.ViewModels
{
    public class AccountViewModel
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
        [DataType(DataType.EmailAddress, ErrorMessage = "فرمت ایمیل اشتباه است")]
        public string Email { get; set; }


        [Required(ErrorMessage = "وارد کردن رمز عبور الزامی است")]
        [MaxLength(12, ErrorMessage = "رمز عبور نمی تواند بیشتر از 12 کاراکتر باشد")]
        [MinLength(5, ErrorMessage = "رمز عبور نمی تواند کمتر از 5 کاراکتر باشد")]
        [DisplayName("رمز عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "وارد کردن رمز عبور الزامی است")]
        [MaxLength(12, ErrorMessage = "رمز عبور نمی تواند بیشتر از 12 کاراکتر باشد")]
        [MinLength(5, ErrorMessage = "رمز عبور نمی تواند کمتر از 5 کاراکتر باشد")]
        [DisplayName("تکرار رمز عبور")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "با رمز عبور وارد شده برابر نیست")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "وارد کردن شماره موبایل الزامی است")]
        [DisplayName("شماره موبایل")]
        [MaxLength(11, ErrorMessage = "شماره موبایل نمی تواند بیشتر از 11 کاراکتر باشد")]
        [MinLength(11, ErrorMessage = "شماره موبایل نمی تواند کمتر از 11 کاراکتر باشد")]
        public string NumberPhone { get; set; }


    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "وارد کردن ایمیل الزامی است")]
        [DisplayName("ایمیل")]
        [MaxLength(100, ErrorMessage = "ایمیل نمی تواند بیشتر از 50 کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "فرمت ایمیل اشتباه است")]
        public string Email { get; set; }

        [Required(ErrorMessage = "وارد کردن رمز عبور الزامی است")]
        [MaxLength(12, ErrorMessage = "رمز عبور نمی تواند بیشتر از 12 کاراکتر باشد")]
        [MinLength(5, ErrorMessage = "رمز عبور نمی تواند کمتر از 5 کاراکتر باشد")]
        [DisplayName("رمز عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DisplayName("مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
