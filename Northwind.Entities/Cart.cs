using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities
{
    public class Cart
    {
        List<CartLine> _lines = new List<CartLine>();

        public void AddToCart(Product product, int quantity)
        {
            //Sepette böyle bir ürün var mı?
            CartLine cartLine = _lines.FirstOrDefault(c=>c.Product.ProductID==product.ProductID);

            //Yoksa
            if (cartLine == null)
            {
                _lines.Add(new CartLine { Product=product,Quantity=quantity});
            }else//varsa
            {
                //Alınan kadar adetini arttır.
                cartLine.Quantity += quantity;
            }

        }

        public void RemoveFromCart(Product product)
        {
            //ürünü listeden kaldır
            _lines.RemoveAll(p=>p.Product.ProductID == product.ProductID);
        }

        public decimal Total
        {   //Ürün başına Toplam tutar
            get { return _lines.Sum(c => c.Product.UnitPrice * c.Quantity); }
        }

        public void Clear()
        {
            //Sepeti temizle
            _lines.Clear();
        }

        public List<CartLine> Lines
        {
            get { return _lines; }
        }

    }

    public class CartLine
    {
        public Product Product { get; internal set; }
        public int Quantity { get; internal set; }
    }
}
