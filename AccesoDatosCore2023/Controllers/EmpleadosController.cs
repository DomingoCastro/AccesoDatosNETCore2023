using AccesoDatosCore2023.Models;
using AccesoDatosCore2023.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace AccesoDatosCore2023.Controllers
{
    public class EmpleadosController : Controller
    {
        //NECESITAMOS NEUSTROS OBJETOS DE BASE DE DATOS
        RepositoryEmpleados repo;

        // EN EL CONSTRUCTOR RECIBIMOS EL REPOSITORIO
        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Empleado> empleados = repo.GetEmpleados();
            return View(empleados);
        }
        public IActionResult EmpleadosSalario()
        {
            List<Empleado> empleados = repo.GetEmpleados();
            return View(empleados);
        }

        [HttpPost]
        public IActionResult EmpleadosSalario(int salario)
        {
            List<Empleado> empleados = repo.GetEmpleadosSalario(salario);
            return View(empleados);
        }
        public IActionResult Details(int idempleado)
        {
            Empleado empleado = this.repo.FindEmpleado(idempleado);
            return View(empleado);
        }
    }
}
