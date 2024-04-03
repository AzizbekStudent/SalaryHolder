using Microsoft.AspNetCore.Mvc;
using SalaryHolderDataBase.DAL.Interface;
using SalaryHolderDataBase.DAL.Models;

namespace SalaryHolderDataBase.Controllers
{
    public class UserController : Controller
    {
        private readonly I_User_Repo _userRepo;

        public UserController(I_User_Repo userRepo)
        {
            _userRepo = userRepo;
        }

        // Get all
        public async Task<IActionResult> Index()
        {
            try
            {
                var users = await _userRepo.GetAllAsync();

                if (users != null)
                    return View(users);
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
                var user = await _userRepo.GetByIdAsync(id);

                if (user != null) return View(user);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserList user)
        {
            try
            {
                int id = await _userRepo.CreateAsync(user);

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(user);
        }

        // Update
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserList user)
        {
            if (id != user.UserID)
            {
                return NotFound();
            }

            try
            {
                var success = await _userRepo.UpdateAsync(user);

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
                return View(user);
            }
        }

        // Delete
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _userRepo.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var employee = await _userRepo.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            try
            {
                await _userRepo.DeleteAsync(employee);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error {ex.Message}");
            }
        }

    }
}
