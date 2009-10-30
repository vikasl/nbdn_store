using System;
using System.Collections.Generic;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubShoppingCartTask : ShoppingCartTask {
        public void modify_quantity_for_a_products(LineItem line_item)
        {
            throw new NotImplementedException();
        }

        public void delete_product_in_cart(Product remove)
        {
            throw new NotImplementedException();
        }

        public void add_product_to_cart(LineItem item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> get_products_in_cart()
        {
            throw new NotImplementedException();
        }

        public void clear()
        {
            throw new NotImplementedException();
        }

        public decimal get_total_cost()
        {
            throw new NotImplementedException();
        }
    }
}