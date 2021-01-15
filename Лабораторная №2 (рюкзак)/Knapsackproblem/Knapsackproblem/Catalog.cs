using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace litemsss
{
    class Catalog: litems
    {
        string _category;
        string _name;
        int _priceofproduct;
        int _healthinessofproduct;
        public string Category;
        public string Name;
        public int PriceofProduct;
        public int HealthinessofProduct;
        public Catalog()
        {
            _category = Category;
            _name = Name;
            _priceofproduct = PriceofProduct;
            _healthinessofproduct = HealthinessofProduct;
        }
        public string category { get => _category; set => _category = value; }
        public string name { get => _name; set => _name = value; }
        
        public int priceofproduct { get => _priceofproduct; set => _priceofproduct = value; }
        public int healthinessofproduct { get => _healthinessofproduct; set => _healthinessofproduct = value; }
    }
}

