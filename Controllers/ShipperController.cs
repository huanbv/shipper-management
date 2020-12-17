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
    public class ShipperController : Controller
    {
        // GET: /<controller>/

        private IShipperRepo _shipperRepo;

        public ShipperController(IShipperRepo shipperRepo)
        {
            _shipperRepo = shipperRepo;
        }

        public IActionResult Index()
        {
            var model = _shipperRepo.GetAllShippers();
            return View(model);
        }

        #region CREATE SHIPPER
        [HttpGet]
        public IActionResult CreateShipper()
        {
            return View(new Shipper());
        }


        [HttpPost]
        public IActionResult CreateShipper(Shipper model)
        {
            if (ModelState.IsValid)
            {
                _shipperRepo.SaveShipper(model);
                return Redirect(nameof(Index)); // chèn xong thì chuyển hướng lại trang Index
            }

            // khi còn nhập thiếu input
            return View(model);
        }
        #endregion

        #region DELETE SHIPPER
        public IActionResult DeleteShipperInfo(int Id)
        {
            var shipper = _shipperRepo.GetAllShippers().FirstOrDefault(shp => shp.Id == Id);
            if (shipper == null)
            {
                TempData["message"] = $"Không tồn tại Shipper với Id: {Id}";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var deleteShipper = _shipperRepo.Delete(Id);
                if (deleteShipper != null)
                {
                    TempData["message"] = $"Đã xoá Shipper: {deleteShipper.Id}";
                    return RedirectToAction(nameof(Index));
                }

                TempData["message"] = "Xoá thất bại";
                return RedirectToAction(nameof(Index));
            }
        }
        #endregion

        [HttpGet]
        public IActionResult EditShipper(int Id)
        {
            var shipper = _shipperRepo.GetAllShippers().FirstOrDefault(shp => shp.Id == Id);
            if (shipper == null)
            {
                TempData["message"] = $"Không tồn tại Shipper với Id: {Id}";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(shipper);
            }
        }

        [HttpPost]
        public IActionResult EditShipper(Shipper model)
        {
            if (ModelState.IsValid)
            {
                var shipper = _shipperRepo.GetAllShippers().FirstOrDefault(shp => shp.Id == model.Id);
                if (shipper == null)
                {
                    TempData["message"] = $"Không tồn tại Shipper với Id: {model.Id}";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _shipperRepo.SaveShipper(model);
                    TempData["message"] = $"Đã cập nhật thành công Shipper";
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
