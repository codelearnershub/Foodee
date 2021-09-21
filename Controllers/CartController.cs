using FOODEE.Interface;
using FOODEE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FOODEE.DTO;
using FOODEE.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Foodee.DTO;

namespace FOODEE.Controllers
{
   
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ICustomerService _customerService;

        public CartController(ICartService cartService, ICustomerService customerService)
        {
            _cartService = cartService;
            _customerService = customerService;
        }

        public IActionResult ViewCart()
        {
            

            if (!User.Identity.IsAuthenticated)
            {
                return View(new Cart());
            }

            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var cart = _cartService.GetActiveCart(userId);
            return View(cart);
        }

        public JsonResult AddToCart(int id, int? count)
        {
            if (!User.Identity.IsAuthenticated)
                return Json(
                    new
                    {
                        data = "Unauthorized"
                    });

            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var cartItemComparer = new CartVM.CartItemComparer();

            int numberOfItem = count ?? 1;

            var addedCart = _cartService.AddItemToCart(id, userId, numberOfItem);

            var userCart = _cartService.GetActiveCart(userId);

            var responseDto = new CartDto.ItemAdded
            {
                Id = userCart.Id,
                IsCheckedOut = userCart.IsCheckedOut,
                userId = userId,
                NumberOfItem = userCart.CartItems.Distinct(cartItemComparer).Count(),
                CartItems = userCart.CartItems.Select(ci => new CartDto.CartItem
                {
                    Id = ci.Id,
                    Name = ci.MenuItem.Name,
                    Description = ci.MenuItem.Description,
                    Image = ci.MenuItem.Image,
                    Price = ci.MenuItem.Price
                }).ToList()
            };

            return Json(responseDto);
        }

        [Authorize]
        public IActionResult RemoveFromCart(int id)
        {
            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            _cartService.RemoveItemFromCart(id, userId);

            return RedirectToAction(nameof(ViewCart));
        }


        [Authorize]
        public IActionResult CheckOut()
        {
            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var customer = _customerService.GetByUserId(userId);
            var activeCart = _cartService.GetActiveCart(userId);

            var viewModel = new CartVM.CheckOut
            {
                Cart = activeCart,
                CustomerAddress = customer.User.Address,
                CustomerEmail = customer.User.Email,
                CustomerName = $"{customer.User.FirstName} {customer.User.LastName.Substring(0, 1)}.",
                PhoneNumber = customer.User.PhoneNumber
            };

            return View(viewModel);
        }

        [Authorize]
        public IActionResult EmptyCart()
        {
            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            _cartService.EmptyCart(userId);

            return RedirectToAction(nameof(CheckOut));
        }

        public IActionResult SaveFromLocalStorage(string cart)
        {

            var jcart = JsonConvert.DeserializeObject<List<LSCartDto>>(cart);

            return RedirectToAction(nameof(CheckOut));
            
        }
    }
}