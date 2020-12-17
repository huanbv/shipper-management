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
    public class DriverController : Controller
    {
        // GET: /<controller>/

        private IDriverRepo _driverRepo;

        public DriverController(IDriverRepo driverRepo)
        {
            _driverRepo = driverRepo;
        }


        public IActionResult Index()
        {
            var model = _driverRepo.GetAllDrivers();
            return View(model);
        }
        

        #region CREATE DIVER
        [HttpGet]
        public IActionResult CreateDriver()
        {
            return View(new Driver());
        }


        [HttpPost]
        public IActionResult CreateDriver(Driver model)
        {
            if (ModelState.IsValid)
            {
                _driverRepo.SaveDriver(model);
                return Redirect(nameof(Index)); // chèn xong thì chuyển hướng lại trang Index
            }

            // khi còn nhập thiếu input
            return View(model);
        }
        #endregion

        #region DELETE DRIVER
        public IActionResult DeleteDriverInfo(int Id)
        {
            var driver = _driverRepo.GetAllDrivers().FirstOrDefault(drv => drv.Id == Id);
            if(driver == null)
            {
                TempData["message"] = $"Không tồn tại Driver với Id: {Id}";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var deletedDriver = _driverRepo.Delete(Id);
                if (deletedDriver != null)
                {
                    TempData["message"] = $"Đã xoá Driver: {deletedDriver.Id}";
                    return RedirectToAction(nameof(Index));
                }

                TempData["message"] = "Xoá thất bại";
                return RedirectToAction(nameof(Index));
            }
        }
        #endregion

        [HttpGet]
        public IActionResult EditDriver (int Id)
        {
            var driver = _driverRepo.GetAllDrivers().FirstOrDefault(drv => drv.Id == Id);
            if (driver == null)
            {
                TempData["message"] = $"Không tồn tại Driver với Id: {Id}";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(driver);
            }
        }

        [HttpPost]
        public IActionResult EditDriver (Driver model)
        {
            if (ModelState.IsValid)
            {
                var driver = _driverRepo.GetAllDrivers().FirstOrDefault(drv => drv.Id == model.Id);
                if (driver == null)
                {
                    TempData["message"] = $"Không tồn tại Driver với Id: {model.Id}";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _driverRepo.SaveDriver(model);
                    TempData["message"] = $"Đã cập nhật thành công Driver";
                    return RedirectToAction(nameof(Index));
                }
            }
            else {
                TempData["message"] = $"Vui lòng nhập vào các trường còn thiếu";
                return View(model);
            }
        }
    }
}
