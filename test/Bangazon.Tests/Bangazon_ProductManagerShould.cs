using System;
using System.Collections.Generic;
using Bangazon;
using Bangazon.Models;
using Xunit;

namespace Bangazon.Tests
{
    public class ProductManagerShould
    {
        private readonly ProductManager _pm;
        private readonly DatabaseInterface _dab;
        public ProductManagerShould()
        {
            _dab = new DatabaseInterface("BANGAZONCLI_TEST_DB");
            _pm = new ProductManager(_dab);

            _dab.CheckProductTable();
        }
        [Fact]
        public void AddCustomerProductShould()
        {
            Product newProduct = new Product();
            _pm.AddCustomerProduct(newProduct);

            List<Product> result = _pm.GetProductList();

            Assert.Contains(newProduct, result);
        }

        [Fact]
        public void GetProductListShould()
        {
            List<Product> products = _pm.GetProductList();

            Assert.IsType<List<Product>>(products);
        }
    }
}