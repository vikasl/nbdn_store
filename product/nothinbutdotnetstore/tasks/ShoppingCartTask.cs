using System.Collections.Generic;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.tasks
{
    public interface ShoppingCartTask {

        void modify_quantity_for_a_products(LineItem line_item);
        void delete_product_in_cart(Product remove);
        void add_product_to_cart(LineItem item);
        IEnumerable<Product> get_products_in_cart();
        void  clear();
        decimal  get_total_cost();
    }
}