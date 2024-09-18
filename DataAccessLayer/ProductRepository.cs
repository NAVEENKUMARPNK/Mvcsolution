using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class ProductRepository:IProductRepository
    {

        ProductDbContext con = null;
        public ProductRepository(ProductDbContext regs)
        {
            con = regs;
        }
        public void insertproduct(Products values)
        {
            con.Add(values);
            con.SaveChanges();

        }
        public void UpdateProduct(Products value)
        {
            con.Update(value);
            con.SaveChanges();
        }
        public void DeleteProduct(int reg)
        {
            var count = con.Products.Find(reg);
            con.Remove(count);
            con.SaveChanges();
        }
        public List<Products> selectallProduct()
        {
            return con.Products.ToList();
        }
        public Products selectbyname(string Name)
        {
            return con.Products.FirstOrDefault(X => X.Name == Name);
        }
        public Products selectbyId(int id)
        {
            return con.Products.Find(id);
        }

    }
}
