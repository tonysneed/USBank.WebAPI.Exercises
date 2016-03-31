namespace RepoUoW.Patterns.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product_Old
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        public int? CategoryId { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        public bool Discontinued { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] RowVersion { get; set; }
    }
}
