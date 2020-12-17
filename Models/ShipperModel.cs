using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Shipper
    {
        public Shipper()
        {
            this.Entries = new HashSet<Entry>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Mời nhập họ và tên")]
        [Display(Name = "Tên của bạn: ")]
        public string First_Name { set; get; }

        [Required(ErrorMessage = "Mời nhập Họ")]
        [Display(Name = "Họ của bạn: ")]
        public string Last_Name { set; get; }

        [Required(ErrorMessage = "Mời nhập Email")]
        [Display(Name = "Email của bạn: ")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Mời nhập số điện thoại")]
        [Display(Name = "Số điện thoại: ")]
        public string PhoneNumber { set; get; }

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

        [Display(Name = "Ghi chú: ")]
        public string Notes { set; get; }

        public virtual ICollection<Entry> Entries { get; set; }
    }
}
