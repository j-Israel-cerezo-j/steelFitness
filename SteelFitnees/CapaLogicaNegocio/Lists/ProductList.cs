using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
namespace CapaLogicaNegocio.Lists
{
    public class ProductList
    {
        ProductData productData = new ProductData();

        public List<Product> listProduct()
        {
            return productData.listProduct();
        }
    }
}
