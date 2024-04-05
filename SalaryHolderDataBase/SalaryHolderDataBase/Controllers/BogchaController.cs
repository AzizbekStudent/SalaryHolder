using Microsoft.AspNetCore.Mvc;
using SalaryHolderDataBase.DAL.Interface;
using SalaryHolderDataBase.DAL.Models;

namespace SalaryHolderDataBase.Controllers
{
    public class BogchaController : Controller
    {
        private readonly IRepository<Bogcha> _bogchaRepository;

        private int UserNumber = 1;

        public BogchaController(IRepository<Bogcha> bogchaRepository)
        {
            _bogchaRepository = bogchaRepository;
        }

        // Get all
        public async Task<IActionResult> Index()
        {
            try
            {
                var bogcha = await _bogchaRepository.GetAllAsync(UserNumber);

                if (bogcha != null)
                    return View(bogcha);
            }
            catch (Exception err)
            {
                return StatusCode(500, $"Server error {err.Message}");
                throw;
            }
            return View();
        }


        // Get by id
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var bogcha = await _bogchaRepository.GetByIdAsync(UserNumber,id);

                if (bogcha != null) return View(bogcha);
            }
            catch (Exception err)
            {
                return StatusCode(500, $"Server error {err.Message}");
            }
            return NotFound();
        }

        // Create
        public IActionResult Create()
        {
            return View();
        }

        // Create method
        [HttpPost]
        public async Task<IActionResult> Create(Bogcha bogcha)
        {
            try
            {
                int id = await _bogchaRepository.CreateAsync(UserNumber, bogcha);

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(bogcha);
        }

        // Update
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _bogchaRepository.GetByIdAsync(UserNumber, id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Bogcha bogcha)
        {
            if (id != bogcha.BogCha_ID)
            {
                return NotFound();
            }

            try
            {
                var success = await _bogchaRepository.UpdateAsync(UserNumber, bogcha);

                if (success > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return BadRequest("Employee update failed.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(bogcha);
            }
        }
    }
}
