using AccesoDatosCore2023.Models;
using AccesoDatosCore2023.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AccesoDatosCore2023.Controllers
{
    public class PlantillaController : Controller
    {
        RepositoryPlantilla repoplantilla;
        public PlantillaController(RepositoryPlantilla repoplantilla)
        {
            this.repoplantilla = repoplantilla;
        }
        public IActionResult Index()
        {
            List<Plantilla> plant = repoplantilla.GetPlantilla();
            return View(plant);
        }
        public IActionResult Details(int idplantilla) 
        {
            Plantilla plant = this.repoplantilla.FindPlantilla(idplantilla);
            return View(plant);
        }
        [HttpPost]
        public IActionResult Index(string funcion)
        {
            List<Plantilla> plantilla = repoplantilla.FindFuncion(funcion);
            return View(plantilla);
        }
    }
}
