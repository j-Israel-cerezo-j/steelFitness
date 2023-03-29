using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
namespace CapaLogicaNegocio.Lists
{
    public class BrancheList
    {
        private BrancheData brancheData = new BrancheData();

        public List<Branche> listBraches()
        {
            return brancheData.listBranches();
        }
    }
}
