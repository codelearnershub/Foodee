using FOODEE.Interface;
using FOODEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOODEE.Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMenuItemService _menuItemService;

        public CartService(ICartRepository cartRepository, ICartItemRepository cartItemRepository, IMenuItemService menuItemService)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _menuItemService = menuItemService;
        }

        public Cart FindById(int id)
        {
            return _cartRepository.FindById(id);
        }

        public Cart RemoveItemFromCart(int menuItemId, int userId)
        {
            var activeCart = GetActiveCart(userId);

            //if (!activeCart.CartItems.Exists(c => c.MenuItemId == menuItemId)) return activeCart;

            activeCart.CartItems.RemoveAll(c => c.MenuItemId == menuItemId);

            return _cartRepository.Update(activeCart);
        }

        public Cart GetActiveCart(int userId)
        {
            return _cartRepository.GetActiveCart(userId);
        }

        public Cart EmptyCart(int userId)
        {
            var activeCart = GetActiveCart(userId);
            activeCart.CartItems.Clear();
            return _cartRepository.Update(activeCart);
        }

        public int GetNumberOfCartItems(int userId)
        {
            return _cartRepository.GetNumberOfCartItems(userId);
        }

        public Cart AddItemToCart(int menuItemId, int userId, int count =1)
        {
            var userCart = GetActiveCart(userId);
            var menuItem = _menuItemService.FindById(menuItemId);
            
            if (userCart == null)
            {
                Cart newCart = new Cart
                {
                    userId = userId,
                    CreatedAt = DateTime.Now,
                    IsCheckedOut = false,
                };
                userCart = _cartRepository.Add(newCart);
            }

          var newCartItems = new List<CartItem>();
            
            for (var i = 0; i < count; i++)
            {
                newCartItems.Add(
                    new CartItem
                    {
                        CartId = userCart.Id,
                        MenuItem = menuItem
                    });
            }
            var cartItems = _cartItemRepository.AddMany(newCartItems);
            userCart.CartItems.AddRange(cartItems);
            return _cartRepository.Update(userCart);
        }

        public Cart Add(Cart cart)
        {
            return _cartRepository.Add(cart);
        }

        public Cart Update(Cart cart)
        {
            return _cartRepository.Update(cart);
        }

        public void Delete(int id)
        {
            _cartRepository.Delete(id);
        }

        public List<Cart> GetAll()
        {
            return _cartRepository.GetAll();

        }
        public IEnumerable<Cart> GetCartsByUserId(int id)
        {
            return _cartRepository.GetCartsByUserId(id);
        }
    }
}
