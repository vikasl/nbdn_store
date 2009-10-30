 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.domain;

namespace nothinbutdotnetstore.tests.domain
 {   
     public class CartItemSpecs
     {
         public abstract class concern : observations_for_a_sut_without_a_contract<CartItem>
         {
        
         }

         [Concern(typeof(CartItem))]
         public class when_incrementing_the_quantity : concern
         {
             context c = () =>
             {

            
             };

             because b = () =>
             {
                  sut.increment_quantity_by(inc_value);
             };

        
             it should_incerement_the_quantity_by_passed_value= () =>
             {
                 sut.Quantity.should_be_equal_to(inc_value);
            
             };

             private static int inc_value = 10;
         }

         [Concern(typeof(CartItem))]
         public class when_changing_the_quantity : concern
         {
  

             because b = () =>
             {
                 sut.change_quantity_to( inc_value);
             };


             it should_change_the_quantity_to_passed_value = () =>
             {
                 sut.Quantity.should_be_equal_to(inc_value);

             };

             private static int inc_value = 10;
         }


         [Concern(typeof(CartItem))]
         public class when_calculating_total : concern
         {

             after_the_sut_has_been_created d = () =>
             {
                 sut.Price = 18.33m;
                 sut.Quantity = 10;
             };

             because b = () =>
             {
                 result = sut.calculate_total_cost();
             };


             it should_give_the_total_cost = () =>
             {
                 result.should_be_equal_to(total_cost);

             };

             private static decimal total_cost = 183.30m;
             private static decimal result;
         }

         [Concern(typeof(CartItem))]
         public class when_verifying_given_item_is_item_for_a_product : concern
         {
             context c = () =>
             {
                  product = new Product() { ProductId = 1 };

             };

             after_the_sut_has_been_created d = () =>
             {
                 sut.ProductId = 1;
                 
             };

             because b = () =>
             {
                 result = sut.is_item_for(product);
             };


             it should_should_true = () =>
             {
                 result.should_be_equal_to(true);

             };

            
             private static bool result;
             private static Product product;
         }
     }

 }
