using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.domain
{
    public class ShoppingCart {
        private Dictionary<Product,int> list_of_products;
        private CostCalculator cost_calculator;

        protected  ShoppingCart()
        {
        }

        public ShoppingCart( CostCalculator calculator)
        {
            list_of_products = new Dictionary<Product, int>();
            cost_calculator = calculator;
        }

        public virtual void add(Product product_to_add, int quantity_of_product)
        {
            if( list_of_products.ContainsKey(product_to_add))
            {
                list_of_products[product_to_add] += quantity_of_product;
            }
            else
            {
                list_of_products.Add(product_to_add,quantity_of_product);
            }
        }

        public virtual void modify(Product modified, int quantity)
        {
            Console.WriteLine("quantity" + quantity );
            if( quantity == 0)
                remove(modified);
        }

        public virtual void remove(Product product_to_remove)
        {
            list_of_products.Remove(product_to_remove);
        }

        public virtual IEnumerable<Product> getListOfProducts()
        {
            foreach (var product in list_of_products.Keys)
            {
                 yield return product;
            }
        }

        public virtual void  clear()
        {
            list_of_products = new Dictionary<Product, int>();
        }

        public virtual decimal  get_total_cost()
        {
            return cost_calculator.GetTotalCost(list_of_products);

        }
    }

    public  interface CostCalculator
    {
        decimal GetTotalCost(Dictionary<Product, int> dictionary);
    }
}