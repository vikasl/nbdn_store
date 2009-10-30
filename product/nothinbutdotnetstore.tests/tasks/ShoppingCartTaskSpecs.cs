using System.Collections;
using System.Collections.Generic;
using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.tasks
 {   
     public class ShoppingCartTaskSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ShoppingCartTask,
             DefaultShoppingCartTask>
         {
        
         }

         [Concern(typeof(DefaultShoppingCartTask))]
         public class when_an_item_is_added_to_the_shopping_cart : concern
         {
             context c = () =>
             {
                 
                 shopping_cart = an<ShoppingCart>();

                 cart_corral = the_dependency<CartCorral>();
                 catalog = the_dependency<Catalog>();

                 product_to_be_added = an<Product>();
                 line_item_to_add = new LineItem
                 {
                     product_id = 1,
                     quantity = 5
                 };

                 cart_corral.Stub(corral => corral.get_cart()).Return(shopping_cart);
                 catalog.Stub(cat => cat.get_product(line_item_to_add.product_id)).Return(product_to_be_added);
            
             };

             because b = () =>
             {
                sut.add_product_to_cart(line_item_to_add);
             };

        
             it should_add_a_product_and_quantity_to_the_shopping_cart = () =>
             {
                 shopping_cart.received(cart => cart.add(product_to_be_added, line_item_to_add.quantity));
             };

             private static ShoppingCart shopping_cart;
             private static Product product_to_be_added;
             private static LineItem line_item_to_add;
             private static Catalog catalog;
             static CartCorral cart_corral;
         }

     //    [Concern(typeof(DefaultShoppingCartTask))]
     //    public class when_an_item_quantity_is_modified : concern
     //    {
     //        context c = () =>
     //        {
     //            shopping_cart = an<ShoppingCart>();
     //            cart_corral = the_dependency<CartCorral>();
     //            catalog = the_dependency<Catalog>();

     //            product_to_be_modified = an<Product>();


     //            line_item_to_modify = new LineItem
     //            {
     //                product_id = 1,
     //                quantity = 5
     //            };

     //            cart_corral.Stub(corral => corral.get_cart()).Return(shopping_cart);
     //            catalog.Stub(cat => cat.get_product(line_item_to_modify.product_id)).Return(product_to_be_modified);

     //        };

     //        because b = () =>
     //        {
     //            sut.modify_quantity_for_a_products(line_item_to_modify);
     //        };

     //        it should_change_the_quantity_in_the_cart_for_that_item = () =>
     //        {
     //            shopping_cart.received(cart => cart.modify(product_to_be_modified, line_item_to_modify.quantity));
     //        };



     //        private static ShoppingCart shopping_cart;
     //        private static Product product_to_be_modified;
     //        private static LineItem line_item_to_modify;
     //        private static Catalog catalog;
     //        static CartCorral cart_corral;
     //        private static Product product_to_be_removed;
     //    }

     //    [Concern(typeof(DefaultShoppingCartTask))]
     //    public class when_and_item_is_removed_from_cart : concern
     //    {
     //        context c = () =>
     //        {
     //            shopping_cart = an<ShoppingCart>();
     //            cart_corral = the_dependency<CartCorral>();
     //            catalog = the_dependency<Catalog>();
     //            product_to_be_removed = an<Product>();
     //            cart_corral.Stub(corral => corral.get_cart()).Return(shopping_cart);
               

     //        };

     //        because b = () =>
     //        {
     //            sut.delete_product_in_cart(product_to_be_removed);
     //        };



     //        private it should_remove_the_item_from_the_cart = () =>
     //        {
     //            shopping_cart.received(cart => cart.remove(product_to_be_removed));
     //        };

     //        private static ShoppingCart shopping_cart;
      
             
     //        private static Catalog catalog;
     //        static CartCorral cart_corral;
     //        private static Product product_to_be_removed;
     //    }

     //    [Concern(typeof(DefaultShoppingCartTask))]
     //    public class when_a_request_is_made_go_get_list_of_items_in_cart : concern
     //    {
     //        context c = () =>
     //        {
     //            shopping_cart = an<ShoppingCart>();
     //            cart_corral = the_dependency<CartCorral>();
     //            catalog = the_dependency<Catalog>();
     //            list_of_products = new List<Product>();
     //            cart_corral.Stub(corral => corral.get_cart()).Return(shopping_cart);
     //            shopping_cart.Stub(cart => cart.getListOfProducts()).Return(list_of_products);

     //        };

     //        because b = () =>
     //        {
     //            result = sut.get_products_in_cart();
     //        };


     //        private it should_return_the_list_of_products = () =>
     //        {
     //            result.should_be_equal_to(list_of_products);
     //        };

     //        private static ShoppingCart shopping_cart;


     //        private static Catalog catalog;
     //        static CartCorral cart_corral;
     //        private static Product product_to_be_removed;
     //        private static IEnumerable<Product>  result;
     //        private static IEnumerable<Product> list_of_products;
     //    }

     //    [Concern(typeof(DefaultShoppingCartTask))]
     //    public class when_a_request_is_made_to_empty_the_cart : concern
     //    {
     //        context c = () =>
     //        {
     //            shopping_cart = an<ShoppingCart>();
     //            cart_corral = the_dependency<CartCorral>();
     //            catalog = the_dependency<Catalog>();
     //            list_of_products = new List<Product>();
     //            cart_corral.Stub(corral => corral.get_cart()).Return(shopping_cart);
     //            shopping_cart.Stub(cart => cart.getListOfProducts()).Return(list_of_products);

     //        };

     //        because b = () =>
     //        {
     //            sut.clear();
     //        };


     //        private it should_remove_all_the_products_in_the_cart = () =>
     //        {
     //            shopping_cart.received(cart => cart.clear());
     //        };

     //        private static ShoppingCart shopping_cart;


     //        private static Catalog catalog;
     //        static CartCorral cart_corral;
     //        private static Product product_to_be_removed;
     //        private static IEnumerable<Product> result;
     //        private static IEnumerable<Product> list_of_products;
     //    }

     //    [Concern(typeof(DefaultShoppingCartTask))]
     //    public class when_a_request_is_made_to_get_total_cost_of_producs_in_cart : concern
     //    {
     //        context c = () =>
     //        {
     //            shopping_cart = an<ShoppingCart>();
     //            cart_corral = the_dependency<CartCorral>();
     //            catalog = the_dependency<Catalog>();
     //            list_of_products = new List<Product>();
     //            cart_corral.Stub(corral => corral.get_cart()).Return(shopping_cart);

     //        };

     //        because b = () =>
     //        {
     //            sut.get_total_cost();
     //        };


     //        private it should_return_total_cost_of_products = () =>
     //        {
     //            shopping_cart.received(cart => cart.get_total_cost());
     //        };

     //        private static ShoppingCart shopping_cart;


     //        private static Catalog catalog;
     //        static CartCorral cart_corral;
     //        private static Product product_to_be_removed;
     //        private static IEnumerable<Product> result;
     //        private static IEnumerable<Product> list_of_products;
     //    }

     }


 }
