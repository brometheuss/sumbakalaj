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
    public class ModelController : Controller
    {
        private readonly IGetModelsCommand _getModels;
        private readonly IGetModelCommand _getModel;
        private readonly IAddModelCommand _addModel;
        private readonly IEditModelCommand _editModel;
        private readonly IDeleteModelCommand _deleteModel;

        public ModelController(IGetModelsCommand getModels, IGetModelCommand getModel, IAddModelCommand addModel, IEditModelCommand editModel, IDeleteModelCommand deleteModel)
        {
            _getModels = getModels;
            _getModel = getModel;
            _addModel = addModel;
            _editModel = editModel;
            _deleteModel = deleteModel;
        }



        // GET: Model
        public ActionResult Index(ModelQuery query)
        {
            return View(_getModels.Execute(query));
        }

        // GET: Model/Details/5
        public ActionResult Details(int id)
        {
            return View(_getModel.Execute(id));
        }

        // GET: Model/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Model/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddModelDto dto)
        {
            try
            {
                // TODO: Add insert logic here
                _addModel.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException e)
            {
                TempData["error"] = e.Message;
            }
            return View();
        }

        // GET: Model/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_getModel.Execute(id));
        }

        // POST: Model/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AddModelDto dto)
        {
            try
            {
                // TODO: Add update logic here
                _editModel.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException)
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Model/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_getModel.Execute(id));
        }

        // POST: Model/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _deleteModel.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}