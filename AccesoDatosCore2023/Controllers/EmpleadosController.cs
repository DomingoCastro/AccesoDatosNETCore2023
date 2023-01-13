using AccesoDatosCore2023.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace AccesoDatosCore2023.Controllers
{
    public class EmpleadosController : Controller
    {
        //NECESITAMOS NEUSTROS OBJETOS DE BASE DE DATOS

        string connectionString;
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        // EN EL CONSTRUCTOR CREAMOS LOS OOBJETOS
        public EmpleadosController()
        {
            this.connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA";
            this.cn = new SqlConnection(this.connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }
        public IActionResult Index()
        {
            List<Empleado> empleados = new List<Empleado>();
            string sql = "SELECT * FROM EMP";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                Empleado emp = new Empleado();
                emp.IdEmpleado = int.Parse(this.reader["EMP_NO"].ToString());
                emp.Apellido = this.reader["APELLIDO"].ToString();
                emp.Oficio = this.reader["OFICIO"].ToString();
                emp.Salario = int.Parse(this.reader["SALARIO"].ToString());
                empleados.Add(emp);
            }
            this.cn.Close();
            this.reader.Close();
            return View(empleados);
        }
    }
}
