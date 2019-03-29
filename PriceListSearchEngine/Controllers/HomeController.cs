using System;
using System.Web.Mvc;
using BusinessLayer;

namespace PriceListSearchEngine.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string searchKodHotel, string searchRolaOsoby, DateTime? searchDataCennika, DateTime? searchDataPobytu, string searchAirportPL, string searchAirportGR, string searchKodPokoju, string searchOkres, string searchWyzywienie)
        {
            string rokCennika = null;
            string miesiacCennika = null;
            string dataCennika = null;

            DataEngine dataEngine = new DataEngine();
            FlightModel flightModel = new FlightModel();
            flightModel.searchAirportGR = searchAirportGR;
            flightModel.searchAirportPL = searchAirportPL;

            if (searchDataCennika != null)
            {
                rokCennika = searchDataCennika.Value.Year.ToString();
                miesiacCennika = searchDataCennika.Value.Month.ToString("d2");
                dataCennika = "Export_Pivot_" + rokCennika + "_" + miesiacCennika;
            }
            else
            {
                dataCennika = "Export_Pivot_2019_01";
            }
                       
            string searchAirport = flightModel.searchAirportPL + flightModel.searchAirportGR;

            if (!(searchKodHotel == null))
            {
                var dana = dataEngine.DataConnectWithParams(dataCennika, searchKodHotel, searchRolaOsoby, searchDataCennika, searchDataPobytu, searchAirport, searchKodPokoju, searchOkres, searchWyzywienie);
                return View(dana);
            }
            else
            {
                var dana = dataEngine.DataConnectWithOutParams(dataCennika);
                return View(dana);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}