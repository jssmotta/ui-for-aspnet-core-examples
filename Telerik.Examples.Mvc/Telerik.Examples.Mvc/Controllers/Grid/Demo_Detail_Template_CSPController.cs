﻿using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Telerik.Examples.Mvc.Models;

namespace Telerik.Examples.Mvc.Controllers.Grid
{
    public class Demo_Detail_Template_CSPController : Controller
    {
        public IActionResult Demo_Detail_Template_CSP()
        {
            return View();
        }
        public IActionResult _Child_Grid(int employeeID)
        {
            return PartialView(employeeID);
        }
        public virtual List<ExtendedEmployeeViewModel> GetAllParents()
        {
            List<ExtendedEmployeeViewModel> results = JsonSerializer.Deserialize<List<ExtendedEmployeeViewModel>>(JsonParentData);
            return results;
        }
        public virtual List<OrderViewModel> GetAllChildren()
        {
            List<OrderViewModel> results = JsonSerializer.Deserialize<List<OrderViewModel>>(JsonChildrenData);
            return results;
        }
        public ActionResult Parent_Read([DataSourceRequest] DataSourceRequest request)
        {
            var result = GetAllParents();

            var dsResult = result.ToDataSourceResult(request);
            return Json(dsResult);
        }
        public ActionResult Children_Read([DataSourceRequest] DataSourceRequest request, int employeeID)
        {
            var result = GetAllChildren().Where(order => order.EmployeeID == employeeID);

            var dsResult = result.ToDataSourceResult(request);
            return Json(dsResult);
        }
        //public ActionResult DetailProducts_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] List<DetailProductViewModel> orders)
        //{
        //    var results = new List<DetailProductViewModel>();
        //    if (orders != null && ModelState.IsValid)
        //    {
        //        results = orders;
        //    }
        //    return Json(results.ToDataSourceResult(request));
        //}
        //public ActionResult DetailProducts_Create([DataSourceRequest] DataSourceRequest request,
        //    [Bind(Prefix = "models")] List<DetailProductViewModel> orders)
        //{

        //    var results = new List<DetailProductViewModel>();
        //    if (orders != null && ModelState.IsValid)
        //    {
        //        int entriesNum = GetAll().Count();

        //        foreach (DetailProductViewModel order in orders)
        //        {
        //            bool isInvalid = entriesNum >= order.ProductID;
        //            if (isInvalid)
        //            {
        //                ModelState.AddModelError("NotUnique", "Row already exists");
        //                return Json(results.ToDataSourceResult(request, ModelState));
        //            }

        //        }


        //        results = orders;
        //    }
        //    return Json(results.ToDataSourceResult(request, ModelState));

        //}

        //public ActionResult DetailProducts_Destroy([DataSourceRequest] DataSourceRequest request,
        //    [Bind(Prefix = "models")] List<DetailProductViewModel> orders)
        //{
        //    //ModelState.AddModelError("Destroy", "An unexplaing error");
        //    var results = new List<DetailProductViewModel>();
        //    if (orders != null && ModelState.IsValid)
        //    {
        //        foreach (var order in orders)
        //        {
        //            results.Add(order);
        //        }
        //    }
        //    return Json(results.ToDataSourceResult(request, ModelState));
        //}

        public static string JsonParentData { get; set; } = "[{\"EmployeeID\":1,\"FirstName\":\"Nancy\",\"EmployeeName\":null,\"LastName\":\"Davolio\""+
            ",\"Title\":\"SalesRepresentative\",\"Country\":\"USA\",\"City\":\"Seattle\",\"Address\":\"507-20thAve.E.\\nApt.2A\",\"HomePhone\":\"(206)555-9857\",\"Notes\":\"EducationincludesaBAinpsychologyfromColoradoStateUniversityin1970.Shealsocompleted\\\"TheArtoftheColdCall.\\\"NancyisamemberofToastmastersInternational.\",\"ReportsTo\":null},{\"EmployeeID\":2,\"FirstName\":\"Andrew\",\"EmployeeName\":null,"+
            "\"LastName\":\"Fuller\",\"Title\":\"VicePresident,Sales\",\"Country\":\"USA\",\"City\":\"Tacoma\",\"Address\":\"908W.CapitalWay\",\"HomePhone\":\"(206)555-9482\","+
            "\"Notes\":\"AndrewreceivedhisBTScommercialin1974andaPh.D.ininternationalmarketingfromtheUniversityofDallasin1981.HeisfluentinFrenchandItalianandreadsGerman.Hejoinedthecompanyasasalesrepresentative,waspromotedtosalesmanagerinJanuary1992andtovicepresidentofsalesinMarch1993.AndrewisamemberoftheSalesManagementRoundtable,theSeattleChamberofCommerce,andthePacificRimImportersAssociation.\",\"ReportsTo\":null},"+
            "{\"EmployeeID\":3,\"FirstName\":\"Janet\",\"EmployeeName\":null,\"LastName\":\"Leverling\",\"Title\":\"SalesRepresentative\",\"Country\":\"USA\",\"City\":\"Kirkland\",\"Address\":\"722MossBayBlvd.\",\"HomePhone\":\"(206)555-3412\",\"Notes\":\"JanethasaBSdegreeinchemistryfromBostonCollege(1984).Shehasalsocompletedacertificateprograminfoodretailingmanagement.Janetwashiredasasalesassociatein1991andpromotedtosalesrepresentativeinFebruary1992.\",\"ReportsTo\":null},{\"EmployeeID\":4,\"FirstName\":\"Margaret\",\"EmployeeName\":null,\"LastName\":\"Peacock\",\"Title\":\"SalesRepresentative\",\"Country\":\"USA\",\"City\":\"Redmond\",\"Address\":\"4110OldRedmondRd.\",\"HomePhone\":\"(206)555-8122\","+
            "\"Notes\":\"MargaretholdsaBAinEnglishliteraturefromConcordiaCollege(1958)andanMAfromtheAmericanInstituteofCulinaryArts(1966).ShewasassignedtotheLondonofficetemporarilyfromJulythroughNovember1992.\",\"ReportsTo\":null},{\"EmployeeID\":5,\"FirstName\":\"Steven\",\"EmployeeName\":null,\"LastName\":\"Buchanan\",\"Title\":\"SalesManager\",\"Country\":\"UK\",\"City\":\"London\",\"Address\":\"14GarrettHill\",\"HomePhone\":\"(71)555-4848\",\"Notes\":\"StevenBuchanangraduatedfromSt.AndrewsUniversity,Scotland,withaBSCdegreein1976.Uponjoiningthecompanyasasalesrepresentativein1992,hespent6monthsinanorientationprogramattheSeattleofficeandthenreturnedtohispermanentpostinLondon.HewaspromotedtosalesmanagerinMarch1993.Mr.Buchananhascompletedthecourses\\\"SuccessfulTelemarketing\\\"and\\\"InternationalSalesManagement.\\\"HeisfluentinFrench.\",\"ReportsTo\":null},"+
            "{\"EmployeeID\":6,\"FirstName\":\"Michael\",\"EmployeeName\":null,\"LastName\":\"Suyama\",\"Title\":\"SalesRepresentative\",\"Country\":\"UK\",\"City\":\"London\",\"Address\":\"CoventryHouse\\nMinerRd.\",\"HomePhone\":\"(71)555-7773\",\"Notes\":\"MichaelisagraduateofSussexUniversity(MA,economics,1983)andtheUniversityofCaliforniaatLosAngeles(MBA,marketing,1986).Hehasalsotakenthecourses\\\"Multi-CulturalSelling\\\"and\\\"TimeManagementfortheSalesProfessional.\\\"HeisfluentinJapaneseandcanreadandwriteFrench,Portuguese,andSpanish.\",\"ReportsTo\":null}]";
        public static string JsonChildrenData { get; set; } = "[{\"OrderID\":10258,\"CustomerID\":\"ERNSH\",\"ContactName\":\"RolandMendel\","+
            "\"Freight\":140.51,\"ShipAddress\":\"Kirchgasse6\",\"OrderDate\":\"2021-07-17T00:00:00\",\"ShippedDate\":\"2021-07-23T00:00:00\",\"ShipCountry\":\"Austria\",\"ShipCity\":\"Graz\",\"ShipName\":\"ErnstHandel\",\"EmployeeID\":1},{\"OrderID\":10270,\"CustomerID\":\"WARTH\",\"ContactName\":\"PirkkoKoskitalo\",\"Freight\":136.54,\"ShipAddress\":\"Torikatu38\",\"OrderDate\":\"2021-08-01T00:00:00\",\"ShippedDate\":\"2021-08-02T00:00:00\",\"ShipCountry\":\"Finland\",\"ShipCity\":\"Oulu\",\"ShipName\":\"WartianHerkku\",\"EmployeeID\":1},{\"OrderID\":10275,\"CustomerID\":\"MAGAA\",\"ContactName\":\"GiovanniRovelli\",\"Freight\":26.93,\"ShipAddress\":\"ViaLudovicoilMoro22\",\"OrderDate\":\"2021-08-07T00:00:00\",\"ShippedDate\":\"2021-08-09T00:00:00\","+
            "\"ShipCountry\":\"Italy\",\"ShipCity\":\"Bergamo\",\"ShipName\":\"MagazziniAlimentariRiuniti\",\"EmployeeID\":1},{\"OrderID\":10285,\"CustomerID\":\"QUICK\",\"ContactName\":\"HorstKloss\",\"Freight\":76.83,\"ShipAddress\":\"Taucherstraße10\",\"OrderDate\":\"2021-08-20T00:00:00\",\"ShippedDate\":\"2021-08-26T00:00:00\",\"ShipCountry\":\"Germany\",\"ShipCity\":\"Cunewalde\",\"ShipName\":\"QUICK-Stop\",\"EmployeeID\":1},{\"OrderID\":10292,\"CustomerID\":\"TRADH\",\"ContactName\":\"AnabelaDomingues\",\"Freight\":1.35,\"ShipAddress\":\"Av.InêsdeCastro,414\",\"OrderDate\":\"2021-08-28T00:00:00\",\"ShippedDate\":\"2021-09-02T00:00:00\",\"ShipCountry\":\"Brazil\",\"ShipCity\":\"SaoPaulo\",\"ShipName\":\"TradiçaoHipermercados\",\"EmployeeID\":1},"+
            "{\"OrderID\":10265,\"CustomerID\":\"BLONP\",\"ContactName\":\"FrédériqueCiteaux\",\"Freight\":55.28,"+
            "\"ShipAddress\":\"24,placeKléber\",\"OrderDate\":\"2021-07-25T00:00:00\",\"ShippedDate\":\"2021-08-12T00:00:00\",\"ShipCountry\":\"France\",\"ShipCity\":\"Strasbourg\",\"ShipName\":\"Blondelpèreetfils\",\"EmployeeID\":2},{\"OrderID\":10277,\"CustomerID\":\"MORGK\",\"ContactName\":\"AlexanderFeuer\",\"Freight\":125.77,\"ShipAddress\":\"Heerstr.22\",\"OrderDate\":\"2021-08-09T00:00:00\",\"ShippedDate\":\"2021-08-13T00:00:00\",\"ShipCountry\":\"Germany\",\"ShipCity\":\"Leipzig\",\"ShipName\":\"MorgensternGesundkost\",\"EmployeeID\":2},{\"OrderID\":10280,\"CustomerID\":\"BERGS\",\"ContactName\":\"ChristinaBerglund\",\"Freight\":8.98,\"ShipAddress\":\"Berguvsvägen8\",\"OrderDate\":\"2021-08-14T00:00:00\",\"ShippedDate\":\"2021-09-12T00:00:00\","+
            "\"ShipCountry\":\"Sweden\",\"ShipCity\":\"Luleå\",\"ShipName\":\"Berglundssnabbköp\",\"EmployeeID\":2},{\"OrderID\":10295,\"CustomerID\":\"VINET\",\"ContactName\":\"PaulHenriot\",\"Freight\":1.15,\"ShipAddress\":\"59ruedel-Abbaye\",\"OrderDate\":\"2021-09-02T00:00:00\",\"ShippedDate\":\"2021-09-10T00:00:00\",\"ShipCountry\":\"France\",\"ShipCity\":\"Reims\",\"ShipName\":\"VinsetalcoolsChevalier\",\"EmployeeID\":2},{\"OrderID\":10300,\"CustomerID\":\"MAGAA\",\"ContactName\":\"GiovanniRovelli\",\"Freight\":17.68,\"ShipAddress\":\"ViaLudovicoilMoro22\",\"OrderDate\":\"2021-09-09T00:00:00\",\"ShippedDate\":\"2021-09-18T00:00:00\",\"ShipCountry\":\"Italy\",\"ShipCity\":\"Bergamo\",\"ShipName\":\"MagazziniAlimentariRiuniti\",\"EmployeeID\":2},"+
            "{\"OrderID\":10251,\"CustomerID\":\"VICTE\",\"ContactName\":\"MarySaveley\",\"Freight\":41.34,\"ShipAddress\":\"2,rueduCommerce\",\"OrderDate\":\"2021-07-08T00:00:00\",\"ShippedDate\":\"2021-07-15T00:00:00\",\"ShipCountry\":\"France\",\"ShipCity\":\"Lyon\",\"ShipName\":\"Victuaillesenstock\",\"EmployeeID\":3},{\"OrderID\":10253,\"CustomerID\":\"HANAR\",\"ContactName\":\"MarioPontes\",\"Freight\":58.17,\"ShipAddress\":\"RuadoPaço,67\",\"OrderDate\":\"2021-07-10T00:00:00\",\"ShippedDate\":\"2021-07-16T00:00:00\",\"ShipCountry\":\"Brazil\",\"ShipCity\":\"RiodeJaneiro\",\"ShipName\":\"HanariCarnes\",\"EmployeeID\":3},{\"OrderID\":10256,\"CustomerID\":\"WELLI\",\"ContactName\":\"PaulaParente\",\"Freight\":13.97,\"ShipAddress\":\"RuadoMercado,12\","+
            "\"OrderDate\":\"2021-07-15T00:00:00\",\"ShippedDate\":\"2021-07-17T00:00:00\",\"ShipCountry\":\"Brazil\",\"ShipCity\":\"Resende\",\"ShipName\":\"WellingtonImportadora\",\"EmployeeID\":3},"+
            "{\"OrderID\":10266,\"CustomerID\":\"WARTH\",\"ContactName\":\"PirkkoKoskitalo\",\"Freight\":25.73,\"ShipAddress\":\"Torikatu38\",\"OrderDate\":\"2021-07-26T00:00:00\",\"ShippedDate\":\"2021-07-31T00:00:00\",\"ShipCountry\":\"Finland\",\"ShipCity\":\"Oulu\",\"ShipName\":\"WartianHerkku\",\"EmployeeID\":3},{\"OrderID\":10273,\"CustomerID\":\"QUICK\",\"ContactName\":\"HorstKloss\",\"Freight\":76.07,\"ShipAddress\":\"Taucherstraße10\",\"OrderDate\":\"2021-08-05T00:00:00\",\"ShippedDate\":\"2021-08-12T00:00:00\",\"ShipCountry\":\"Germany\",\"ShipCity\":\"Cunewalde\",\"ShipName\":\"QUICK-Stop\",\"EmployeeID\":3},{\"OrderID\":10252,\"CustomerID\":\"SUPRD\",\"ContactName\":\"PascaleCartrain\",\"Freight\":51.3,\"ShipAddress\":\"BoulevardTirou,255\""+
            ",\"OrderDate\":\"2021-07-09T00:00:00\",\"ShippedDate\":\"2021-07-11T00:00:00\",\"ShipCountry\":\"Belgium\",\"ShipCity\":\"Charleroi\",\"ShipName\":\"Suprêmesdélices\",\"EmployeeID\":4},{\"OrderID\":10257,\"CustomerID\":\"HILAA\",\"ContactName\":\"CarlosHernández\",\"Freight\":81.91,\"ShipAddress\":\"Carrera22conAve.CarlosSoublette#8-35\",\"OrderDate\":\"2021-07-16T00:00:00\",\"ShippedDate\":\"2021-07-22T00:00:00\",\"ShipCountry\":\"Venezuela\",\"ShipCity\":\"SanCristóbal\",\"ShipName\":\"HILARION-Abastos\",\"EmployeeID\":4},{\"OrderID\":10259,\"CustomerID\":\"CENTC\",\"ContactName\":\"FranciscoChang\",\"Freight\":3.25,\"ShipAddress\":\"SierrasdeGranada9993\",\"OrderDate\":\"2021-07-18T00:00:00\",\"ShippedDate\":\"2021-07-25T00:00:00\""+
            ",\"ShipCountry\":\"Mexico\",\"ShipCity\":\"MéxicoD.F.\",\"ShipName\":\"CentrocomercialMoctezuma\",\"EmployeeID\":4},{\"OrderID\":10260,\"CustomerID\":\"OTTIK\",\"ContactName\":\"HenriettePfalzheim\",\"Freight\":55.09,\"ShipAddress\":\"Mehrheimerstr.369\",\"OrderDate\":\"2021-07-19T00:00:00\",\"ShippedDate\":\"2021-07-29T00:00:00\",\"ShipCountry\":\"Germany\",\"ShipCity\":\"Köln\",\"ShipName\":\"OttiliesKäseladen\",\"EmployeeID\":4},{\"OrderID\":10248,\"CustomerID\":\"VINET\",\"ContactName\":\"PaulHenriot\",\"Freight\":32.38,\"ShipAddress\":\"59ruedel-Abbaye\",\"OrderDate\":\"2021-07-04T00:00:00\",\"ShippedDate\":\"2021-07-16T00:00:00\",\"ShipCountry\":\"France\",\"ShipCity\":\"Reims\",\"ShipName\":\"VinsetalcoolsChevalier\",\"EmployeeID\":5}"+
            ",{\"OrderID\":10254,\"CustomerID\":\"CHOPS\",\"ContactName\":\"YangWang\",\"Freight\":22.98,\"ShipAddress\":\"Hauptstr.31\",\"OrderDate\":\"2021-07-11T00:00:00\",\"ShippedDate\":\"2021-07-23T00:00:00\",\"ShipCountry\":\"Switzerland\",\"ShipCity\":\"Bern\",\"ShipName\":\"Chop-sueyChinese\",\"EmployeeID\":5},{\"OrderID\":10269,\"CustomerID\":\"WHITC\",\"ContactName\":\"KarlJablonski\",\"Freight\":4.56,\"ShipAddress\":\"1029-12thAve.S.\",\"OrderDate\":\"2021-07-31T00:00:00\",\"ShippedDate\":\"2021-08-09T00:00:00\",\"ShipCountry\":\"USA\",\"ShipCity\":\"Seattle\",\"ShipName\":\"WhiteCloverMarkets\",\"EmployeeID\":5},{\"OrderID\":10297,\"CustomerID\":\"BLONP\",\"ContactName\":\"FrédériqueCiteaux\",\"Freight\":5.74,\"ShipAddress\":\"24,placeKléber\""+
            ",\"OrderDate\":\"2021-09-04T00:00:00\",\"ShippedDate\":\"2021-09-10T00:00:00\",\"ShipCountry\":\"France\",\"ShipCity\":\"Strasbourg\",\"ShipName\":\"Blondelpèreetfils\",\"EmployeeID\":5},{\"OrderID\":10320,\"CustomerID\":\"WARTH\",\"ContactName\":\"PirkkoKoskitalo\",\"Freight\":34.57,\"ShipAddress\":\"Torikatu38\",\"OrderDate\":\"2021-10-03T00:00:00\",\"ShippedDate\":\"2021-10-18T00:00:00\",\"ShipCountry\":\"Finland\",\"ShipCity\":\"Oulu\",\"ShipName\":\"WartianHerkku\",\"EmployeeID\":5},{\"OrderID\":10249,\"CustomerID\":\"TOMSP\",\"ContactName\":\"KarinJosephs\",\"Freight\":11.61,\"ShipAddress\":\"Luisenstr.48\",\"OrderDate\":\"2021-07-05T00:00:00\",\"ShippedDate\":\"2021-07-10T00:00:00\",\"ShipCountry\":\"Germany\",\"ShipCity\":\"Münster\","+
            "\"ShipName\":\"TomsSpezialitäten\",\"EmployeeID\":6},{\"OrderID\":10264,\"CustomerID\":\"FOLKO\",\"ContactName\":\"MariaLarsson\",\"Freight\":3.67,\"ShipAddress\":\"Åkergatan24\",\"OrderDate\":\"2021-07-24T00:00:00\",\"ShippedDate\":\"2021-08-23T00:00:00\",\"ShipCountry\":\"Sweden\",\"ShipCity\":\"Bräcke\",\"ShipName\":\"FolkochfäHB\",\"EmployeeID\":6},{\"OrderID\":10271,\"CustomerID\":\"SPLIR\",\"ContactName\":\"ArtBraunschweiger\",\"Freight\":4.54,\"ShipAddress\":\"P.O.Box555\",\"OrderDate\":\"2021-08-01T00:00:00\",\"ShippedDate\":\"2021-08-30T00:00:00\",\"ShipCountry\":\"USA\",\"ShipCity\":\"Lander\",\"ShipName\":\"SplitRailBeer&Ale\",\"EmployeeID\":6},{\"OrderID\":10272,\"CustomerID\":\"RATTC\",\"ContactName\":\"PaulaWilson\","+
            "\"Freight\":98.03,\"ShipAddress\":\"2817MiltonDr.\",\"OrderDate\":\"2021-08-02T00:00:00\",\"ShippedDate\":\"2021-08-06T00:00:00\",\"ShipCountry\":\"USA\",\"ShipCity\":\"Albuquerque\",\"ShipName\":\"RattlesnakeCanyonGrocery\",\"EmployeeID\":6},{\"OrderID\":10274,\"CustomerID\":\"VINET\",\"ContactName\":\"PaulHenriot\",\"Freight\":6.01,\"ShipAddress\":\"59ruedel-Abbaye\",\"OrderDate\":\"2021-08-06T00:00:00\",\"ShippedDate\":\"2021-08-16T00:00:00\",\"ShipCountry\":\"France\",\"ShipCity\":\"Reims\",\"ShipName\":\"VinsetalcoolsChevalier\",\"EmployeeID\":6}]";
    }
}
