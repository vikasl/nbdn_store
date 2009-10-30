using nothinbutdotnetstore.dto;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.infrastructure;

namespace nothinbutdotnetstore.web.application
{
    public class AddToCart :ApplicationCommand<ShoppingCartTask> {

        public AddToCart(ResponseEngine response_engine, ShoppingCartTask service)
            : base(response_engine, service)
        {
        }

        public override void process(Request request)
        {
            service.modify_quantity_for_a_products(request.map<LineItem>());
        }
    }
}