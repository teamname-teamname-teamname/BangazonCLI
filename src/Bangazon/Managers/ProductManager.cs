using System;
using System.Collections.Generic;
using System.Linq;
using Bangazon.Models;
using Microsoft.Data.Sqlite;

namespace Bangazon
{
    public class ProductManager
    {
        private DatabaseInterface _db;
        
        public ProductManager(DatabaseInterface db)
        {
            _db = db;
        }
    }
}