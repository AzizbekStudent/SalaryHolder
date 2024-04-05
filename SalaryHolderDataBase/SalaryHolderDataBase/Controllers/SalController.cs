using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalaryHolderDataBase.DAL.Interface;
using SalaryHolderDataBase.DAL.Models;

namespace SalaryHolderDataBase.Controllers
{
    public class SalController : Controller
    {
        private readonly IRepository<Bogcha> _bogchaRepository;
        private readonly IRepository<SalTable> _SalRepository;

        private int UserNumber = 1;

        public SalController(IRepository<Bogcha> bogchaRepository, IRepository<SalTable> SalRepository)
        {
            _bogchaRepository = bogchaRepository;
            _SalRepository = SalRepository;
        }

        // Get all
        public async Task<IActionResult> Index()
        {
            try
            {
                var salaryList = await _SalRepository.GetAllAsync(UserNumber);

                if (salaryList != null)
                {
                    foreach(var sal in salaryList)
                    {
                        sal.Bogcha_ = await _bogchaRepository.GetByIdAsync(UserNumber, (int)sal.BogCha_ID);
                    }
                    return View(salaryList);
                }
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
                var salary = await _SalRepository.GetByIdAsync(UserNumber, id);

                if (salary != null)
                {
                    salary.Bogcha_ = await _bogchaRepository.GetByIdAsync(UserNumber, (int)salary.BogCha_ID);
                    return View(salary);
                } 
            }
            catch (Exception err)
            {
                return StatusCode(500, $"Server error {err.Message}");
            }
            return NotFound();
        }

        // Create
        public async Task<IActionResult> Create()
        {
            try
            {
                var bogchaOptions = await _bogchaRepository.GetAllAsync(UserNumber);

                if (bogchaOptions == null)
                {
                    bogchaOptions = new List<Bogcha>();
                }

                ViewBag.BogchaOptions = bogchaOptions.Select(m => new SelectListItem
                {
                    Value = m.BogCha_ID.ToString(),
                    Text = $"{m.Title} - Zaved: {m.ZavName}"
                }).ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        // Create method
        [HttpPost]
        public async Task<IActionResult> Create(SalTable salary)
        {
            try
            {
                int id = await _SalRepository.CreateAsync(UserNumber, salary);

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(salary);
        }

        // Update
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _SalRepository.GetByIdAsync(UserNumber, id);
            if (user == null)
            {
                return NotFound();
            }
            try
            {
                var bogchaOptions = await _bogchaRepository.GetAllAsync(UserNumber);

                if (bogchaOptions == null)
                {
                    bogchaOptions = new List<Bogcha>();
                }

                ViewBag.BogchaOptions = bogchaOptions.Select(m => new SelectListItem
                {
                    Value = m.BogCha_ID.ToString(),
                    Text = $"{m.Title} - Zaved: {m.ZavName}"
                }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SalTable salary)
        {
            if (id != salary.Sal_ID)
            {
                return NotFound();
            }

            try
            {
                var success = await _SalRepository.UpdateAsync(UserNumber, salary);

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
                return View(salary);
            }
        }
    }
}
