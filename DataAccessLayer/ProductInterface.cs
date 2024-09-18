using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IProductRepository
    {

        public void insertproduct(Products value);
        public void UpdateProduct(Products value);
        public void DeleteProduct(int reg);
        public List<Products> selectallProduct();
        public Products selectbyname(string Name);
        public Products selectbyId(int id);

    }
}

