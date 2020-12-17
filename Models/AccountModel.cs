using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace App.Models
{
    public class Account : IdentityUser
    {
        public override string UserName => this.Email;

        [Required(ErrorMessage = "Mời nhập họ và tên")]
        [Display(Name = "Tên của bạn: ")]
        public string First_Name { set; get; }

        [Required(ErrorMessage = "Mời nhập Họ")]
        [Display(Name = "Họ của bạn: ")]
        public string Last_Name { set; get; }

        [Required(ErrorMessage = "Mời nhập Email")]
        [Display(Name = "Email của bạn: ")]
        public override string Email { set; get; }


        [NotMapped]
        [Required(ErrorMessage = "Mời nhập Mật khẩu")]
        [Display(Name = "Mật khẩu của bạn: ")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Mời nhập số điện thoại")]
        [Display(Name = "Số điện thoại: ")]
        public override string PhoneNumber { set; get; }

        [Required(ErrorMessage = "Mời nhập ngày tháng năm sinh")]
        [Display(Name = "Ngày, tháng, năm sinh: ")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime? Date_Of_Birth { set; get; }

        [Required(ErrorMessage = "Mời nhập địa chỉ")]
        [Display(Name = "Địa chỉ: ")]
        public string Address { set; get; }

        [Required(ErrorMessage = "Mời nhập thành phố")]
        [Display(Name = "Thành phố ")]
        public string City { set; get; }

        [Required(ErrorMessage = "Mời nhập tỉnh thành")]
        [Display(Name = "Tỉnh: ")]
        public string State { set; get; }

        [Required(ErrorMessage = "Mời nhập giới tính")]
        [Display(Name = "Giới tính: ")]
        public string Gender { set; get; }
    }
}
