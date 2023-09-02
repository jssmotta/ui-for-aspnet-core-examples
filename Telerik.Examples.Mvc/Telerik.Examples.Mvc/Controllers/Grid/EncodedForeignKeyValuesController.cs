using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telerik.Examples.Mvc.Models;

namespace Telerik.Examples.Mvc.Controllers.Grid
{
    public class EncodedForeignKeyValuesController : Controller
    {
       
        public IActionResult EncodedForeignKeyValues()
        {
            PopulateCities();

            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var result = Enumerable.Range(1, 20).Select(i => new ForeignKeyOrderViewModel
            {
                OrderID = i,
                TaskID = i,
                Freight = i * 10,
                OrderDate = new DateTime(2016, 9, 15).AddDays(i % 7),
                ShipName = "ShipName " + i,
                ShipCityId = i
            });

            var dsResult = result.ToDataSourceResult(request);
            return Json(dsResult);
        }

        public ActionResult Update([DataSourceRequest] DataSourceRequest request, ForeignKeyOrderViewModel order)
        {
            return Json(new[] { order }.ToDataSourceResult(request));
        }

        public ActionResult Create([DataSourceRequest] DataSourceRequest request, ForeignKeyOrderViewModel order)
        {
            return Json(new[] { order }.ToDataSourceResult(request));
        }

        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, ForeignKeyOrderViewModel order)
        {
            return Json(new[] { order }.ToDataSourceResult(request));
        }

        private void PopulateCities()
        {
            var cities = new CityViewModel[] { new() { CityID = 1, CityName = "Washington, D.C." },new() { CityID = 2, CityName = "London" },new() { CityID = 3, CityName = "Berlin" },new() { CityID = 4, CityName = "Tokyo" },new() { CityID = 5, CityName = "Beijing" },new() { CityID = 6, CityName = "Canberra" },new() { CityID = 7, CityName = "Ottawa" },new() { CityID = 8, CityName = "Paris" },new() { CityID = 9, CityName = "Rome" },new() { CityID = 10, CityName = "Madrid" },new() { CityID = 11, CityName = "Moscow" },new() { CityID = 12, CityName = "New Delhi" },new() { CityID = 13, CityName = "Brasilia" },new() { CityID = 14, CityName = "Cairo" },new() { CityID = 15, CityName = "Buenos Aires" },new() { CityID = 16, CityName = "Seoul" },new() { CityID = 17, CityName = "Cape Town" },new() { CityID = 18, CityName = "Helsinki" },new() { CityID = 19, CityName = "Oslo" },new() { CityID = 20, CityName = "Stockholm" } };
 
            ViewData["cities"] = cities;
        }
       

        // https://docs.telerik.com/aspnet-core/html-helpers/data-management/grid/columns/foreignkey-column?_ga=2.55083758.494890001.1693234765-397234248.1693234765&_gl=1*1bpdn80*_ga*Mzk3MjM0MjQ4LjE2OTMyMzQ3NjU.*_ga_9JSNBCSF54*MTY5MzMyMTgxMi41LjAuMTY5MzMyMjEzMS42MC4wLjA.
    }
}
