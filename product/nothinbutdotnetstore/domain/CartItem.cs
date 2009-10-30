using System;

namespace nothinbutdotnetstore.domain
{
    public class CartItem
    {
        public  int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual void increment_quantity_by(int quantity)
        {
            Quantity += quantity;
        }

        public virtual bool is_item_for(Product product)
        {
            return ProductId == product.ProductId;
        }

        public virtual void change_quantity_to(int new_quantity)
        {
            Quantity = new_quantity;
        }

        public virtual decimal calculate_total_cost()
        {
            return Price*Quantity;
        }
    }
}