using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Repositories.Interfaces;
using App.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace App.Controllers
{
    [Authorize]
    public class EntryController : Controller
    {
        // GET: /<controller>/

        private IEntryRepo _entryRepo;
        private IDriverRepo _driverRepo;
        private IConsigneeRepo _consigneeRepo;
        private ICustomerRepo _customerRepo;
        private IShipperRepo _shipperRepo;

        public EntryController(IEntryRepo entryRepo, IDriverRepo driverRepo,
            IConsigneeRepo consigneeRepo, ICustomerRepo customerRepo, IShipperRepo shipperRepo)
        {
            _entryRepo = entryRepo;
            _driverRepo = driverRepo;
            _consigneeRepo = consigneeRepo;
            _customerRepo = customerRepo;
            _shipperRepo = shipperRepo;
        }


        public IActionResult Index()
        {
            var model = _entryRepo.GetAllEntry();
            return View(model);
        }


        #region CREATE ENTRY
        [HttpGet]
        public IActionResult CreateEntry()
        {
            return View(new CreateEntryViewModel {
                Drivers = _driverRepo.GetAllDrivers(),
                Shippers = _shipperRepo.GetAllShippers(),
                Customers = _customerRepo.GetAllCustomer(),
                Consignees = _consigneeRepo.GetAllConsignee()
            });
        }


        [HttpPost]
        public IActionResult CreateEntry(CreateEntryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _entryRepo.SaveEntry(viewModel);
                return Redirect(nameof(Index)); // chèn xong thì chuyển hướng lại trang Index
            }

            // khi còn nhập thiếu input
            viewModel.Drivers = _driverRepo.GetAllDrivers();
            viewModel.Shippers = _shipperRepo.GetAllShippers();
            viewModel.Customers = _customerRepo.GetAllCustomer();
            viewModel.Consignees = _consigneeRepo.GetAllConsignee();

            return View(viewModel);
        }
        #endregion

        #region DELETE ENTRY INFO
        public IActionResult DeleteEntryInfo(int Id)
        {
            var entry = _entryRepo.GetAllEntry().FirstOrDefault(ord => ord.Id == Id);
            if (entry == null)
            {
                TempData["message"] = $"Không tồn tại Order với Id: {Id}";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var deleteEntry = _entryRepo.Delete(Id);
                if (deleteEntry != null)
                {
                    TempData["message"] = $"Đã xoá Order: {deleteEntry.Id}";
                    return RedirectToAction(nameof(Index));
                }

                TempData["message"] = "Xoá thất bại";
                return RedirectToAction(nameof(Index));
            }
        }
        #endregion

        [HttpGet]
        public IActionResult EditEntry(int Id)
        {
            var entry = _entryRepo.GetAllEntry().FirstOrDefault(ord => ord.Id == Id);
            if (entry == null)
            {
                TempData["message"] = $"Không tồn tại Order với Id: {Id}";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(entry);
            }
        }

        [HttpPost]
        public IActionResult EditOrder(Entry model)
        {
            if (ModelState.IsValid)
            {
                var entry = _entryRepo.GetAllEntry().FirstOrDefault(ord => ord.Id == model.Id);
                if (entry == null)
                {
                    TempData["message"] = $"Không tồn tại order với Id: {model.Id}";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _entryRepo.SaveEntry(model);
                    TempData["message"] = $"Đã cập nhật thành công Order";
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
