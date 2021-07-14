using System;
using System.Diagnostics;
using System.Threading.Tasks;
using EriaTest.Data.Entities;
using EriaTest.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EriaTest.Models;
using EriaTest.Services;
using Vereyon.Web;

namespace EriaTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AssigmentService _assigmentService;
        private readonly AssigmentRepository _assigmentRepository;
        private readonly AssigmentTypeRepository _assigmentTypeRepository;
        private readonly IFlashMessage _flashMessage;

        public HomeController(
            ILogger<HomeController> logger,
            AssigmentService assigmentService,
            AssigmentRepository assigmentRepository,
            AssigmentTypeRepository assigmentTypeRepository,
            IFlashMessage flashMessage
            )
        {
            _logger = logger;
            _assigmentService = assigmentService;
            _assigmentRepository = assigmentRepository;
            _assigmentTypeRepository = assigmentTypeRepository;
            _flashMessage = flashMessage;
        }

        private void PopulateModel(AssigmentViewModel vm)
        {
            vm.Assigments = _assigmentRepository.GetDataSourceAsNoTracking();
            vm.AssigmentTypes = _assigmentTypeRepository.GetAll();
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var vm = new AssigmentViewModel();
            
            PopulateModel(vm);

            return View(vm);
        }
        
        [HttpPost]
        public async Task<IActionResult> Index(AssigmentViewModel vm)
        {
            PopulateModel(vm);
            
            ModelState.Clear();
            TryValidateModel(vm);

            if (ModelState.IsValid == false)
            {
                return View(vm);
            }
            
            var entity = new Assigment();

            try
            {
                _assigmentService.Map(vm, entity);
                await _assigmentRepository.Save(entity);
                _flashMessage.Confirmation("Assigment was saved.");
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e.Message, e);
                _flashMessage.Danger("There was an unknown error. Try again.");
            }
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = _assigmentRepository.GetById(id);

            if (entity == null)
            {
                return NotFound();
            }
            
            try
            {
                await _assigmentRepository.Delete(entity);
                _flashMessage.Confirmation("Assigment was deleted.");
            }
            catch (Exception e)
            {
                _flashMessage.Danger("Save went wrong. Try again please.");
                _logger.LogError(e.Message, e);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
