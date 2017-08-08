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
        //private readonly DBInitializer _db;
        public ProductManagerShould()
        {
            _dab = new DatabaseInterface("BANGAZONCLI_TEST_DB");
            _pm = new ProductManager(_dab);
            // _db = new DBInitializer();

            _dab.CheckProductTable();
            DbInitializer.Initialize(_dab);
        }
        [Fact]
        public void AddProductToSystemShould()
        {

        }
    }
}