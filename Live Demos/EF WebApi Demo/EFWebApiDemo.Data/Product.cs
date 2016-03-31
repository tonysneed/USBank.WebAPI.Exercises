using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace EFWebApiDemo.Data
{
    using System;
    using System.Collections.Generic;

    //[JsonObject(IsReference = true)]
    public partial class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int? CategoryId { get; set; }

        public decimal? UnitPrice { get; set; }

        public bool Discontinued { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public Category Category { get; set; }
    }
}
