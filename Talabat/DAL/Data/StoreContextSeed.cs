using DAL.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.DAL.Entities.Order;

namespace DAL.Data
{
    public class StoreContextSeed
    {
        public static async  Task SeedAsync(StoreContext context,ILoggerFactory loggerFactory)
        {
                try
                {

                if (!context.ProductCategories.Any())
                {
                    var categoryData = File.ReadAllText("../DAL/Data/SeedData/categories.json");
                    var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoryData);
                    foreach (var item in categories)
                    {
                        context.Set<ProductCategory>().Add(item);
                        await context.SaveChangesAsync();
                    }
                }
                    if (!context.ProductTypes.Any())
                    {
                        
                            var categoryData = File.ReadAllText("../DAL/Data/SeedData/types.json");
                            var categories = JsonSerializer.Deserialize<List<ProductType>>(categoryData);
                            foreach (var item in categories)
                            {
                                context.Set<ProductType>().Add(item);
                                await context.SaveChangesAsync();
                            }
                        
                       
                          
                    }
                if (!context.Products.Any())
                {
                  
                        var categoryData = File.ReadAllText("../DAL/Data/SeedData/products.json");
                        var categories = JsonSerializer.Deserialize<List<Product>>(categoryData);
                        foreach (var item in categories)
                        {
                            context.Set<Product>().Add(item);
                            await context.SaveChangesAsync();
                        }
                    
                  
                }
                if (!context.DeliveryMethods.Any())
                {
                    var deliverMethodsData =
                        File.ReadAllText("../DAL/Data/SeedData/delivery.json");
                    var deliverMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliverMethodsData);
                    foreach (var deliverMethod in deliverMethods)
                        context.DeliveryMethods.Add(deliverMethod);

                    await context.SaveChangesAsync();
                }
            }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                    logger.LogError(ex, ex.Message);
                }
            }
           
         



        
    }
}
