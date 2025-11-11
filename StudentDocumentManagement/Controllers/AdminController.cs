using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentDocumentManagement.Data;
using StudentDocumentManagement.Models;
using StudentDocumentManagement.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDocumentManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Pending));
        }

        public async Task<IActionResult> Pending()
        {
            var pendingRequests = await _context.DocumentRequests
                .Where(r => r.Status == RequestStatus.Pending)
                .Include(r => r.Student)
                .ToListAsync();

            var viewModel = new PendingViewModel
            {
                DocumentRequests = pendingRequests
            };

            return View(viewModel);
        }
    }
}
