using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Commands;
using BusinessLogic.DTO;
using BusinessLogic.Exceptions;
using BusinessLogic.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly IGetManufacturersCommand _getManufacturers;
        private readonly IGetManufacturerCommand _getManufacturer;
        private readonly IAddManufacturerCommand _addManufacturer;
        private readonly IEditManufacturerCommand _editManufacturer;
        private readonly IDeleteManufacturerCommand _deleteManufacturer;

        public ManufacturerController(IGetManufacturersCommand getManufacturers, IGetManufacturerCommand getManufacturer, IAddManufacturerCommand addManufacturer, IEditManufacturerCommand editManufacturer, IDeleteManufacturerCommand deleteManufacturer)
        {
            _getManufacturers = getManufacturers;
            _getManufacturer = getManufacturer;
            _addManufacturer = addManufacturer;
            _editManufacturer = editManufacturer;
            _deleteManufacturer = deleteManufacturer;
        }

        // GET: Manufacturer
        public ActionResult Index(ManufacturerQuery request)
        {
            return View(_getManufacturers.Execute(request));
        }

        // GET: Manufacturer/Details/5
        public ActionResult Details(int id)
        {
            return View(_getManufacturer.Execute(id));
        }

        // GET: Manufacturer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manufacturer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddManufacturerDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Ooops, something went wrong.";
                RedirectToAction(nameof(Index));
            }
            try
            {
                // TODO: Add insert logic here
                _addManufacturer.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException)
            {
                TempData["error"] = "Manufacturer with that name already exists.";
            }
            catch (Exception)
            {
                TempData["error"] = "An error has occurred.";
            }
            return View();
        }

        // GET: Manufacturer/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_getManufacturer.Execute(id));
        }

        // POST: Manufacturer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GetManufacturerDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                // TODO: Add update logic here
                _editManufacturer.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException)
            {
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException)
            {
                TempData["error"] = "Manufacturer with that name already exists, try a different one.";
                return View(dto);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Manufacturer/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(_getManufacturer.Execute(id));
            }
            catch (EntityNotFoundException)
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Manufacturer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _deleteManufacturer.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}