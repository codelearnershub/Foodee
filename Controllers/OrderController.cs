using FOODEE.Interface;
using FOODEE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FOODEE.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            return View(_orderService.GetAll());
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _orderService.FindById(id.Value);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Order order)
        {
            if (ModelState.IsValid)
            {
                _orderService.Add(order);

            }
            return RedirectToAction("Confirmation", "Order");

        }
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _orderService.FindById(id.Value);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
        //[Authorize(Roles = "Customer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _orderService.Update(order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }
        //[Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _orderService.FindById(id.Value);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _orderService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Confirmation()
        {
            return View();
        }
        public IActionResult CheckOut()
        {
            if(User.Identity.IsAuthenticated)
            {
                return View();
            }

            return RedirectToAction("Login","User");
        }


        [HttpPost]
        public IActionResult Menu(IEnumerable<Menu> orders, string deliveryAddress)
        {
            var customerId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var response = _orderService.Menu(customerId, orders, deliveryAddress);
            return View("Confirmation", response);
        }
    }
}
