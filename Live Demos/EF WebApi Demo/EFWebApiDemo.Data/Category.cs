using Newtonsoft.Json;

namespace EFWebApiDemo.Data
{
    using System;
    using System.Collections.Generic;

    //[JsonObject(IsReference = true)]
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
