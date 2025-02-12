using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.EntityFramework;

namespace SignalR.BusinessLayer.Container
{
    public static class Extension
    {
        public static void DependencyContainer(this IServiceCollection services)
        {
            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IAboutService, AboutManager>();

            services.AddScoped<IBookingDal, EfBookingDal>();
            services.AddScoped<IBookingService, BookingManager>();

            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IContactService, ContactManager>();

            services.AddScoped<IDiscountDal, EfDiscountDal>();
            services.AddScoped<IDiscountService, DiscountManager>();

            services.AddScoped<IFeatureDal, EfFeatureDal>();
            services.AddScoped<IFeatureService, FeatureManager>();

            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();

            services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            services.AddScoped<ITestimonialService, TestimonialManager>();

            services.AddScoped<IOrderDal, EfOrderDal>();
            services.AddScoped<IOrderService, OrderManager>();

            services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();
            services.AddScoped<IOrderDetailService, OrderDetailManager>();

            services.AddScoped<IMoneySafeDal, EfMoneySafeDal>();
            services.AddScoped<IMoneySafeService, MoneySafeManager>();

            services.AddScoped<IDiningTableDal, EfDiningTableDal>();
            services.AddScoped<IDiningTableService, DiningTableManager>();

            services.AddScoped<IBasketDal, EfBasketDal>();
            services.AddScoped<IBasketService, BasketManager>();

            services.AddScoped<INotificationDal, EfNotificationDal>();
            services.AddScoped<INotificationService, NotificationManager>();

            services.AddScoped<IMessageDal, EfMessageDal>();
            services.AddScoped<IMessageService, MessageManager>();
        }
    }
}
