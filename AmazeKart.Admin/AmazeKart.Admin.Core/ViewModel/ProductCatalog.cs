using AmazeKart.Admin.Core.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AmazeKart.Admin.Core.ViewModel
{
    public  class ProductCatalog
    {
        public int CatalogId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string ProductImage { get; set; }
        public string MediaType { get; set; }
    }
}
