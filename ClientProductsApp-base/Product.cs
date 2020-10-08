using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProductsApp {
    class Product {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public override string ToString() {
            return $"Id: {this.Id}; Name: {this.Name}; Category: {this.Category}; Price: {this.Price}€";
        }
    }
}
