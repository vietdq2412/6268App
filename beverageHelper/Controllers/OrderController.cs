using _6262App.Business.Services;
using _6282App.core.Models;
using Microsoft.AspNetCore.Mvc;

namespace beverageHelper.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductService productService;
        private readonly IOrderService orderService;
        private readonly IOrderDetailService orderDetailService;

        public OrderController(
            IOrderService _orderService,
            IOrderDetailService _orderDetailService,
            IProductService productService)
        {
            this.orderService = _orderService;
            this.orderDetailService = _orderDetailService;
            this.productService = productService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cart()
        {
            List<OrderDetail> orderDetails = orderDetailService.FindItemsNotOrdered();
            ViewData["orderDetails"] = orderDetails;
            return View();
        }

        public async Task<ActionResult> AddProductToCart(long productId, int quantity)
        {
            Product product = productService.FindById(productId).Result!;
            OrderDetail orderDetail = new OrderDetail()
            {
                ProductId = productId,
                Product = product,
                Quantity = quantity,
                TotalPrice = product.Price * quantity
            };
            await orderDetailService.Save(orderDetail);
            return Redirect(nameof(Cart));
        }

        public ActionResult PlaceOrder()
        {
            Order order = new Order()
            {
                Name = "order1",
                OrderDetails = orderDetailService.FindItemsNotOrdered(),
                Status = OrderStatus.Pending.ToString()
            };

            orderService.Save(order);
            return Redirect(nameof(Cart));
        }
    }
}