using System;
using System.Collections.Generic;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.tasks
{
    public class DefaultShoppingCartTask : ShoppingCartTask
    {
        CartCorral cart_corral;
        Catalog catalog;

        public DefaultShoppingCartTask(CartCorral cart_corral, Catalog catalog)
        {
            this.cart_corral = cart_corral;
            this.catalog = catalog;
        }

        public void add_product_to_cart(LineItem line_item)
        {
            cart_corral.get_cart().add(catalog.get_product(line_item.product_id), line_item.quantity);
        }

        public IEnumerable<Product> get_products_in_cart()
        {
           // return cart_corral.get_cart().getListOfProducts();
            return null;
        }

        public void clear()
        {
           // cart_corral.get_cart().clear();
        }

        public decimal get_total_cost()
        {
           // return cart_corral.get_cart().get_total_cost();
            throw new NotImplementedException();
        }

        public void modify_quantity_for_a_products(LineItem line_item)
        {
           // cart_corral.get_cart().modify(catalog.get_product(line_item.product_id), line_item.quantity);
        }

        public void delete_product_in_cart(Product product)
        {
            cart_corral.get_cart().remove( product);
        }


    }
}