using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace App.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: /<controller>/

        private ICustomerRepo _customerRepo;

        public CustomerController(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public IActionResult Index()
        {
            var model = _customerRepo.GetAllCustomer();
            return View(model);
        }


        #region CREATE CUSTOMER
        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View(new Customer());
        }


        [HttpPost]
        public IActionResult CreateCustomer(Customer model)
        {
            if (ModelState.IsValid)
            {
                _customerRepo.SaveCustomer(model);
                return Redirect(nameof(Index)); // chèn xong thì chuyển hướng lại trang Index
            }

            // khi còn nhập thiếu input
            return View(model);
        }
        #endregion

        #region DELETE CUSTOMER INFO
        public IActionResult DeleteCustomerInfo(int Id)
        {
            var customer = _customerRepo.GetAllCustomer().FirstOrDefault(ctm => ctm.Id == Id);
            if (customer == null)
            {
                TempData["message"] = $"Không tồn tại Customer với Id: {Id}";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var deleteCustomer = _customerRepo.Delete(Id);
                if (deleteCustomer != null)
                {
                    TempData["message"] = $"Đã xoá Customer: {deleteCustomer.Id}";
                    return RedirectToAction(nameof(Index));
                }

                TempData["message"] = "Xoá thất bại";
                return RedirectToAction(nameof(Index));
            }
        }
        #endregion

        [HttpGet]
        public IActionResult EditCustomer(int Id)
        {
            var customer = _customerRepo.GetAllCustomer().FirstOrDefault(ctm => ctm.Id == Id);
            if (customer == null)
            {
                TempData["message"] = $"Không tồn tại Customer với Id: {Id}";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(customer);
            }
        }

        [HttpPost]
        public IActionResult EditCustomer(Customer model)
        {
            if (ModelState.IsValid)
            {
                var customer = _customerRepo.GetAllCustomer().FirstOrDefault(ctm => ctm.Id == model.Id);
                if (customer == null)
                {
                    TempData["message"] = $"Không tồn tại Customer với Id: {model.Id}";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _customerRepo.SaveCustomer(model);
                    TempData["message"] = $"Đã cập nhật thành công Customer";
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                TempData["message"] = $"Vui lòng nhập vào các trường còn thiếu";
                return View(model);
            }
        }
    }
}
