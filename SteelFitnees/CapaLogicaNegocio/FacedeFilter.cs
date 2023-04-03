using CapaLogicaNegocio.Exceptions;
using CapaLogicaNegocio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class FacedeFilter
    {
        private BrancheSerevice brancheSerevice = new BrancheSerevice();
        private DayService dayService = new DayService();
        private HoursService hoursService = new HoursService();
        private ProductService productService= new ProductService();
        public string by(string filterBy)
        {
            if (filterBy == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            switch (filterBy)
            {
                case "sucursales":
                    return brancheSerevice.jsonBranches();
                case "dias":
                    return dayService.jsonDays();
                case "productos":
                    return productService.jsonProducts();
                default:
                    throw new ServiceException(MessageErrors.MessageErrors.noneFilter);
            }            
        }
        public string table(string filterByValue,string filterBy)
        {
            if (filterBy == "")
            {
                throw new ServiceException(MessageErrors.MessageErrors.idRecordEmpty);
            }
            switch (filterBy)
            {
                case "sucursales":
                    return brancheSerevice.jsontableSchedulesByIdBrancheTable(filterByValue);
                case "dias":
                    return hoursService.jsonTableSchedulesByIdDay(filterByValue);
                default:
                    throw new ServiceException(MessageErrors.MessageErrors.noneFilter);
            }
        }
    }
}
