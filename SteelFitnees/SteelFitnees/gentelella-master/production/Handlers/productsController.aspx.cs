using CapaEntidades;
using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SteelFitnees.gentelella_master.production.Handlers
{
    public partial class productsController : System.Web.UI.Page
    {
        private ProductService productService=new ProductService();
        public string getJsonResponse { get; private set; } = "{\"k\":1}";
        protected void Page_Load(object sender, EventArgs e)
        {
            getProductsAll();
        }
        private void getProductsAll()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {
                response.success = true;
                string json = productService.jsonProducts();
                data.Add("recoverData", JsonConvert.DeserializeObject<Dictionary<string, Object>[]>(json));

            }
            catch (ServiceException se)
            {
                response.error = se.getMessage();
            }
            data.Add("footeer", "Verificar por favor");
            response.data = data;
            getJsonResponse = JsonConvert.SerializeObject(response);
        }
    }
}