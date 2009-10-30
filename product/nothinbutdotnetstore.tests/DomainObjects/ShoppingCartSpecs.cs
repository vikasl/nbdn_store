 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdd.mocking.rhino;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.domain;
 using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.tests.DomainObjects
 {   
     public class ShoppingCartSpecs
     {
         public abstract class concern : observations_for_a_sut_without_a_contract<ShoppingCart>
         {
        
         }

         [Concern(typeof(ShoppingCart))]
         public class when_request_is_made_to_calculate_total_cost : concern
         {
             context c = () =>
             {
                 product = an<Product>();
                 costcalculator = the_dependency<CostCalculator>();

                 //cart  = new ShoppingCart();

                 cart.add(product, 4);
             };

             because b = () =>
             {
                  sut.modify(product, 0);
             };

        
             it should_return_the_total_cost_of_products= () =>
             {
                // costcalculator.received(costcalculator => costcalculator.GetTotalCost());
             };

             private static Product product;
             private static LineItem line_item_to_modify;
             private static ShoppingCart cart;
             private static CostCalculator costcalculator;
         }
     }
 }
