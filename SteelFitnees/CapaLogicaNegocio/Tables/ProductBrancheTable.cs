using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaLogicaNegocio.Tables
{
    public class ProductBrancheTable
    {
        private ProductBrancheData productBrancheData = new ProductBrancheData();
        public DataTable table()
        {
            return productBrancheData.tableProductBranches();
        }
    }
}
