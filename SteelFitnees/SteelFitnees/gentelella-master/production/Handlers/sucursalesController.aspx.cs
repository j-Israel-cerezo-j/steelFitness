using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocio.Services;
using CapaEntidades;
using CapaLogicaNegocio.Exceptions;
using Newtonsoft.Json;
namespace SteelFitnees.gentelella_master.production.Handlers
{
    public partial class sucursalesController : System.Web.UI.Page
    {
        public string getJsonResponse { get; private set; } = "{\"k\":1}";
        private BrancheSerevice brancheSerevice = new BrancheSerevice();
        protected void Page_Load(object sender, EventArgs e)
        {
            string request = Request.QueryString["meth"];
            if (request=="si")
            {
                getSucursalesAllImage();
            }
            else
            {
                getSucursalesAll();
            }            
        }
        
        private void getSucursalesAll()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {
                response.success = true;
                string json = brancheSerevice.jsonBranches();
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
        private void getSucursalesAllImage()
        {
            var data = new Dictionary<string, Object>();
            Response response = new Response();
            try
            {
                response.success = true;
                string json = brancheSerevice.jsonTableBranches();
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