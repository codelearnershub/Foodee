using FOODEE.Interface;
using FOODEE.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly IOrderItemService _orderItemService;
        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }
        public IActionResult Index()
        {
            return View(_orderItemService.GetAll());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItem = _orderItemService.FindById(id.Value);
            if (orderItem == null)
            {
                return NotFound();
            }

            return View(orderItem);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                _orderItemService.Add(orderItem);
                return RedirectToAction(nameof(Index));
            }
            return View(orderItem);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItem = _orderItemService.FindById(id.Value);
            if (orderItem == null)
            {
                return NotFound();
            }
            return View(orderItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, OrderItem orderItem)
        {
            if (id != orderItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _orderItemService.Update(orderItem);
                return RedirectToAction(nameof(Index));
            }
            return View(orderItem);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItem = _orderItemService.FindById(id.Value);
            if (orderItem == null)
            {
                return NotFound();
            }

            return View(orderItem);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _orderItemService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
