using System;
using PruebaTecnicaPlatec.Models;
using Microsoft.EntityFrameworkCore;
using DataBaseInMemory.DataContext;

namespace PruebaTecnicaPlatec.Repositorios
{
    public class ProductRepository : IProductRepository
    {
        public AppDbContext context = new AppDbContext();
        public ProductRepository()
        {
            using (var cont = new AppDbContext())
            {
                Random random = new Random();   
                var products = new List<Product>
                {
                new Product
                        {
                            Id = random.Next(),
                            Name = $"One",
                            Price = 100,
                            Quantity = 1
                        },
                        new Product
                        {
                            Id = random.Next(),
                            Name = $"Two",
                            Price = 200,
                            Quantity = 2
                        },
                        new Product
                        {
                            Id = random.Next(),
                            Name = $"Three",
                            Price = 300,
                            Quantity = 3
                        },
                        new Product
                        {
                            Id = random.Next(),
                            Name = $"Four",
                            Price = 400,
                            Quantity = 4
                        }
                };
                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
        public IEnumerable<Product> GetProducts()
        {
            return context.Products
                    .ToList();

        }

        public String DeleteProduct(int id)
        {
            using (var cont = new AppDbContext())
            {
                
            
                try
                {
                    var product = context.Products.Where(x => x.Id == id);
                    context.Remove(product);
                    //context.SaveChanges();                
                    return "OK";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public Product GetProductsId(int id)
        {
            try
            {
                var product = context.Products.Where(x => x.Id == id).FirstOrDefault();
                //context.SaveChanges();                
                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public String PostProduct(Product product)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    if (product == null) 
                    { 
                        return "No hay registros";
                    }
                    if (product.Name.Trim().Length == 0)
                    {
                        return "El producto no tiene nombre";
                    }
                    if (product.Price == 0)
                    {
                        return "El precio es Cero";
                    }
                    if (product.Quantity == 0)
                    {
                        return "La cantidad es Cero";
                    }
                    context.Add(product);
                    context.SaveChanges();
                    return "OK";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public String PutProduct(Product product)
        {
            using (var context = new AppDbContext())
            {
                try
                {
                    context.Update(product);
                    context.SaveChanges();
                    return "OK";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }
    }
}
