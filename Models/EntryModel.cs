using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    public class Entry
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Mời nhập tên đơn hàng")]
        [Display(Name = "Tên đơn hàng: ")]
        public string Order_Name { set; get; }

        [Required(ErrorMessage = "Nhập vào ngày tạo đơn")]
        [Display(Name = "Ngày tạo đơn: ")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime? Order_Date { set; get; }

        [Required(ErrorMessage = "Nhập vào ngày đơn hàng đi")]
        [Display(Name = "Ngày đơn hàng đi: ")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime? Pick_Up_Date { set; get; }

        [Required(ErrorMessage = "Nhập vào ngày giao hàng")]
        [Display(Name = "Ngày giao hàng: ")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime? Delivery_Date { set; get; }

        [Required(ErrorMessage = "Mời nhập vào đơn giá")]
        [Display(Name = "Đơn giá: ")]
        public string Order_Price { set; get; }

        [Required(ErrorMessage = "Mời nhập địa chỉ")]
        [Display(Name = "Địa chỉ: ")]
        public string Address { set; get; }

        [Required(ErrorMessage = "Mời nhập thành phố")]
        [Display(Name = "Thành phố ")]
        public string City { set; get; }

        [Required(ErrorMessage = "Mời nhập tỉnh thành")]
        [Display(Name = "Tỉnh: ")]
        public string State { set; get; }

        [Required(ErrorMessage = "Mời nhập cân nặng")]
        [Display(Name = "Cân nặng: ")]
        public string Weight { set; get; }

        [Required(ErrorMessage = "Mời nhập số lượng")]
        [Display(Name = "Số lượng: ")]
        public string Quantity { set; get; }

        [Required(ErrorMessage = "Mời nhập vào trạng thái")]
        [Display(Name = "Trạng thái: ")]
        public string Order_Status { set; get; }

        [Display(Name = "Ghi chú: ")]
        public string Notes { set; get; }



        [ForeignKey (nameof(Driver))]
        public int? DriverId { get; set; }
        public Driver Driver { get; set; }

        [ForeignKey(nameof(Shipper))]
        public int? ShipperId { get; set; }
        public Shipper Shipper { get; set; }

        [ForeignKey(nameof(Consignee))]
        [Required(ErrorMessage = "Mời chọn người nhận hàng")]
        public int? ConsigneeId { get; set; }
        public Consignee Consignee { get; set; }

        [ForeignKey(nameof(Customer))]
        [Required(ErrorMessage = "Mời chọn người gửi")]
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
