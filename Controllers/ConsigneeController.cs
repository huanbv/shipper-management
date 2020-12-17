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
    public class ConsigneeController : Controller
    {
        // GET: /<controller>/

        private IConsigneeRepo _consigneeRepo;

        public ConsigneeController(IConsigneeRepo consigneeRepo)
        {
            _consigneeRepo = consigneeRepo;
        }

        public IActionResult Index()
        {
            var model = _consigneeRepo.GetAllConsignee();
            return View(model);
        }


        #region CREATE CUSTOMER
        [HttpGet]
        public IActionResult CreateConsignee()
        {
            return View(new Consignee());
        }


        [HttpPost]
        public IActionResult CreateConsignee(Consignee model)
        {
            if (ModelState.IsValid)
            {
                _consigneeRepo.SaveConsignee(model);
                return Redirect(nameof(Index)); // chèn xong thì chuyển hướng lại trang Index
            }

            // khi còn nhập thiếu input
            return View(model);
        }
        #endregion

        #region DELETE CUSTOMER INFO
        public IActionResult DeleteConsigneeInfo(int Id)
        {
            var consignee = _consigneeRepo.GetAllConsignee().FirstOrDefault(csn => csn.Id == Id);
            if (consignee == null)
            {
                TempData["message"] = $"Không tồn tại Consignee với Id: {Id}";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var deleteConsignee = _consigneeRepo.Delete(Id);
                if (deleteConsignee != null)
                {
                    TempData["message"] = $"Đã xoá Consignee: {deleteConsignee.Id}";
                    return RedirectToAction(nameof(Index));
                }

                TempData["message"] = "Xoá thất bại";
                return RedirectToAction(nameof(Index));
            }
        }
        #endregion

        [HttpGet]
        public IActionResult EditConsignee(int Id)
        {
            var consignee = _consigneeRepo.GetAllConsignee().FirstOrDefault(csn => csn.Id == Id);
            if (consignee == null)
            {
                TempData["message"] = $"Không tồn tại Consignee với Id: {Id}";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(consignee);
            }
        }

        [HttpPost]
        public IActionResult EditConsignee(Consignee model)
        {
            if (ModelState.IsValid)
            {
                var consignee = _consigneeRepo.GetAllConsignee().FirstOrDefault(csn => csn.Id == model.Id);
                if (consignee == null)
                {
                    TempData["message"] = $"Không tồn tại Consignee với Id: {model.Id}";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _consigneeRepo.SaveConsignee(model);
                    TempData["message"] = $"Đã cập nhật thành công Consignee";
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
