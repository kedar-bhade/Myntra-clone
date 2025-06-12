using System.Collections.Generic;
using System.Linq;
using MyntraCloneBackend.Models;

namespace MyntraCloneBackend.Services
{
    public class CartService
    {
        private readonly List<CartItem> _items = new();

        public void AddItem(int productId)
        {
            var item = _items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                _items.Add(new CartItem { ProductId = productId, Quantity = 1 });
            }
        }

        public IEnumerable<CartItem> GetItems()
        {
            return _items;
        }
    }
}
