using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.EntityFramework;
using SignalR.DtoLayer.DiningTableDtos;

namespace SignalR.Api.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneySafeService _moneySafeService;
        private readonly IDiningTableService _dingTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;
        private readonly IBasketService _basketService;
        private readonly IDiscountService _discountService;
        private readonly IMessageService _messageService;
        private readonly ITestimonialService _testimonialService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneySafeService moneySafeService, IDiningTableService dingTableService, IBookingService bookingService, INotificationService notificationService, IBasketService basketService, IDiscountService discountService, IMessageService messageService, ITestimonialService testimonialService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneySafeService = moneySafeService;
            _dingTableService = dingTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
            _basketService = basketService;
            _discountService = discountService;
            _messageService = messageService;
            _testimonialService = testimonialService;
        }

        public static int ClientCount { get; set; } = 0;

        public async Task SendStatistics()
        {
            var categoryCountValue = await _categoryService.TCategoryCountAsync();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCountValue);

            var productCountValue = await _productService.TProductCountAsync();
            await Clients.All.SendAsync("ReceiveProductCount", productCountValue);

            var activeCategoryCountValue = await _categoryService.TActiveCategoryCountAsync();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategoryCountValue);

            var passiveCategoryCountValue = await _categoryService.TPassiveCategoryCountAsync();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", passiveCategoryCountValue);

            var hamburgerCountValue = await _productService.TProductCountByCategoryName("Hamburger");
            await Clients.All.SendAsync("ReceiveHamburgerCount", hamburgerCountValue);

            var drinkCountValue = await _productService.TProductCountByCategoryName("İçecek");
            await Clients.All.SendAsync("ReceiveDrinkCount", drinkCountValue);

            var averageProductPriceValue = await _productService.TAverageProductPrice();
            await Clients.All.SendAsync("ReceiveAverageProductPrice", averageProductPriceValue.ToString("N0"));

            var mostExpensiveProductValue = await _productService.TMostExpensiveProduct();
            await Clients.All.SendAsync("ReceiveMostExpensiveProduct", mostExpensiveProductValue);

            var cheapestProductValue = await _productService.TCheapestProduct();
            await Clients.All.SendAsync("ReceiveCheapestProduct", cheapestProductValue);

            var avgHamburgerPriceValue = await _productService.TAverageProductPriceByCategoryName("Hamburger");
            await Clients.All.SendAsync("ReceiveAverageHamburgerPrice", avgHamburgerPriceValue.ToString("N0"));

            var totalOrderCountValue = await _orderService.TotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", totalOrderCountValue);

            var activeOrderCountValue = await _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCountValue);

            var lastOrderPriceValue = await _orderService.TTotalPriceOfLatestOrder();
            await Clients.All.SendAsync("ReceiveTotalPriceOfLatestOrder", lastOrderPriceValue.ToString("N0"));

            var moneySafeTotalAmountValue = _moneySafeService.TTotalAmount();
            await Clients.All.SendAsync("ReceiveMoneySafeTotalAmount", moneySafeTotalAmountValue.ToString("N0"));

            var todaysEarningsValue = await _orderService.TTodaysEarnings();
            await Clients.All.SendAsync("ReceiveTodaysEarnings", todaysEarningsValue.ToString("N0"));

            var diningTableCountValue = await _dingTableService.TDiningTableCountAsync();
            await Clients.All.SendAsync("ReceiveDiningTableCount", diningTableCountValue);
        }

        public async Task SendProgress()
        {
            var moneySafeTotalAmountValue = _moneySafeService.TTotalAmount();
            await Clients.All.SendAsync("ReceiveMoneySafeTotalAmount", moneySafeTotalAmountValue.ToString("N0"));

            var activeOrderCountValue = await _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCountValue);

            var diningTableCountValue = await _dingTableService.TDiningTableCountAsync();
            await Clients.All.SendAsync("ReceiveDiningTableCount", diningTableCountValue);

            var avgProductPrice = await _productService.TAverageProductPrice();
            await Clients.All.SendAsync("ReceiveAvgProductPrice", avgProductPrice.ToString("N0"));

            var drinkCount = await _productService.TProductCountByCategoryName("İçecek");
            await Clients.All.SendAsync("ReceiveDrinkCount", drinkCount);

            var avgHamburgerPrice = await _productService.TAverageProductPriceByCategoryName("Hamburger");
            await Clients.All.SendAsync("ReceiveAvgHamburgerPrice", avgHamburgerPrice);

            var totalProductPrice = await _productService.TTotalProductPrice();
            await Clients.All.SendAsync("ReceiveTotalProductPrice", totalProductPrice.ToString("N0"));

            var totalPriceOfLatestOrder = await _orderService.TTotalPriceOfLatestOrder();
            await Clients.All.SendAsync("ReceivePriceOfLastOrder", totalPriceOfLatestOrder.ToString("N0"));

            var categoryCount = await _categoryService.TCategoryCountAsync();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);

            var productCount = await _productService.TProductCountAsync();
            await Clients.All.SendAsync("ReceiveProductCount", productCount);

            var bookingCount = await _bookingService.TBookingCount();
            await Clients.All.SendAsync("ReceiveBookingCount", bookingCount);

            var avgDiscountRate = await _discountService.TAvgDiscountRate();
            await Clients.All.SendAsync("ReceiveAvgDiscountRate", avgDiscountRate);

            var messageCount = await _messageService.TMessageCount();
            await Clients.All.SendAsync("ReceiveMessageCount", messageCount);

            var testimonialCount = await _testimonialService.TTestimonialCountAsync();
            await Clients.All.SendAsync("ReceiveTestimonialCount", testimonialCount);
        }

        public async Task SendReservationList()
        {
            var values = await _bookingService.TGetListAsync();
            await Clients.All.SendAsync("ReceiveBookingList", values);
        }

        public async Task SendNotification()
        {
            var unreadMessageCountValue = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveUnreadMessageCount", unreadMessageCountValue);

            var newNotification = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNewNotificationCount", newNotification);

            var unreadNotificationListValues = await _notificationService.TGetAllNotificationsByStatusFalse();
            await Clients.All.SendAsync("ReceiveUnreadNotificationList", unreadNotificationListValues);
        }

        public async Task SendDiningTableStatus()
        {
            var values = await _dingTableService.TGetListAsync();
            await Clients.All.SendAsync("ReceiveDiningTableList", values);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            ClientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", ClientCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            ClientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", ClientCount);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendBasket()
        {
            var basketCountValue = await _basketService.TGetBasketProductCountByTableNumber(4);
            await Clients.All.SendAsync("ReceiveBasketProductCount", basketCountValue);
        }
    }
}
