using BLL.Interface;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.BLL.Interfaces;
using Talabat.BLL.Specifications.Order_Specifications;
using Talabat.DAL.Entities;
using Talabat.DAL.Entities.Order;

namespace Talabat.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentService _paymentService;

        //private readonly IGenericRepo<Product> _productsRepo;
        //private readonly IGenericRepo<DeliveryMethod> _deliveryMethodsRepo;
        //private readonly IGenericRepo<Order> _ordersRepo;

        public OrderService(IBasketRepository basketRepo,
            //IGenericRepo<Product> productsRepo,
            //IGenericRepo<DeliveryMethod> deliveryMethodsRepo,
            //IGenericRepo<Order> ordersRepo,,
           //cc
            IUnitOfWork unitOfWork ,IPaymentService paymentService
           )
        {
            _basketRepo = basketRepo;
            _unitOfWork = unitOfWork;
            _paymentService = paymentService;
            //_paymentService = paymentService;
            //_productsRepo = productsRepo;
            //_deliveryMethodsRepo = deliveryMethodsRepo;
            //_ordersRepo = ordersRepo;
        }
        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shipToAddress)
        {
            // 1. Get Basket From Baskets Repo
            var basket = await _basketRepo.GetBasketAsync(basketId);

            // 2. Get Selected Items at Basket From Products Repo
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var product = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                var productItemOrdered = new ProductItemOrdered(product.Id, product.Name, product.PictureUrl);

            var orderItem = new OrderItem(productItemOrdered, product.Price, item.Quantity);

            items.Add(orderItem);
        }

        // 3. Get Delivery Method From DeliveryMethods Repo
        var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(deliveryMethodId);

        // 4. Calculate SubTotal
        var subtotal = items.Sum(item => item.Price * item.Quantity);


           // check to see if order exists
            var spec = new OrderWithItemsByPaymentIntentSpecification(basket.PaymentIntentId);
        var existingOrder = await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
            if (existingOrder != null)
            {
                _unitOfWork.Repository<Order>().Delete(existingOrder);
                await _paymentService.CreateOrUpdatePaymentIntent(basket.PaymentIntentId);
            }

    // 5. Create Order
    var order = new Order(buyerEmail, shipToAddress, deliveryMethod, items, subtotal, basket.PaymentIntentId);
    _unitOfWork.Repository<Order>().Add(order);



    // 6. Save To Database [TODO]
    var result = await _unitOfWork.Complete();
            if(result <= 0) return null;


            return order;
        }

public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
{
    var spec = new OrderWithItemsAndDeliveryMethodSpecification(buyerEmail);

    return await _unitOfWork.Repository<Order>().GetAllWithSpecAsync(spec);
}


public async Task<Order> GetOrderByIdAsync(int orderId, string buyerEmail)
{
    var spec = new OrderWithItemsAndDeliveryMethodSpecification(orderId, buyerEmail);

    return await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
}
public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
{
    return await _unitOfWork.Repository<DeliveryMethod>().GetAllAsync();
}
    }
}
