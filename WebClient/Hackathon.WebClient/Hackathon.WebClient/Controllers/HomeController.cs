using Grpc.Net.Client;
using Hackathon.BLL.Service;
using Hackathon.DAL.Concrete.Repositories;
using Hackathon.Entities.Concrete;
using Hackathon.WebClient.Models;
using Hackathon.WebClient.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.WsFed;
using Service;
using System.Diagnostics;
using System.Security.Claims;

namespace Hackathon.WebClient.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly ITransactionService _transactionService;
        private readonly IRecyclerService _recyclerService;
        private readonly SessionRepository _sessionRepository;
        public HomeController(UserRepository userRepository, ITransactionService transactionService, IRecyclerService recyclerService, SessionRepository sessionRepository)
        {
            _userRepository = userRepository;
            _transactionService = transactionService;
            _recyclerService = recyclerService;
            _sessionRepository = sessionRepository;
        }

        public IActionResult Index()
        {
            var sessions = _sessionRepository.GetAll();
            return View(sessions);
        }

        public async Task<IActionResult> Transactions()
        {
            var userId = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var user = _userRepository.GetUserById(userId);

            ViewBag.User = user;
            ViewBag.Balance = await RecycleCoinCalculatorService.GetRecycleCoinValue(user.Balance);

            return View(new Transaction());
        }
        [HttpPost]
        public IActionResult Transactions(Transaction transaction)
        {
            var userId = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var user = _userRepository.GetUserById(userId);
            ViewBag.User = user;
            

            _transactionService.InterUserTransaction(user.Profile.IdentityNumber, transaction.RecipientTCKN, transaction.Amount);

            if (!ModelState.IsValid)
                return View(transaction);

            return RedirectToAction("Transactions");
        }

        public IActionResult Recycle()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Recycle([FromBody] MaterialsViewModel viewModel)
        {
            var userId = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            _recyclerService.AddRecyclerItems(viewModel.Materials, userId);
            return Json(new { });
        }


    }
}