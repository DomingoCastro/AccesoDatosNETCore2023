using AccesoDatosCore2023.Models;
using System.Data.SqlClient;

namespace AccesoDatosCore2023.Repositories
{
    public class RepositoryPlantilla
    {
        string connectionString;
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryPlantilla(string cadenaConexion)
        {
            this.connectionString = cadenaConexion;
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }
        public List<Plantilla> GetPlantilla()
        {
            string sql = "SELECT * FROM PLANTILLA";
            this.com.CommandText = sql;
            List<Plantilla> plantilla = new List<Plantilla>();
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                Plantilla plant = new Plantilla();
                plant.IdPlantilla = int.Parse(this.reader["EMPLEADO_NO"].ToString());
                plant.Apellido = this.reader["APELLIDO"].ToString();
                plant.Funcion = this.reader["FUNCION"].ToString();
                plant.Salario = int.Parse(this.reader["SALARIO"].ToString());
                plant.HospCod = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                plant.SalaCod = int.Parse(this.reader["SALA_COD"].ToString());
                plantilla.Add(plant);
            }
            this.reader.Close();
            this.cn.Close();
            return plantilla;
        }
        public Plantilla FindPlantilla(int idplantilla)
        {
            string sql = "SELECT * FROM PLANTILLA WHERE EMPLEADO_NO = @EMPLEADO_NO";
            SqlParameter pamid = new SqlParameter("@EMPLEADO_NO", idplantilla);
            this.com.Parameters.Add(pamid);
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.reader.Read();
            Plantilla plant = new Plantilla();
            plant.IdPlantilla = int.Parse(this.reader["EMPLEADO_NO"].ToString());
            plant.Apellido = this.reader["APELLIDO"].ToString();
            plant.Funcion = this.reader["FUNCION"].ToString();
            plant.Salario = int.Parse(this.reader["SALARIO"].ToString());
            plant.HospCod = int.Parse(this.reader["HOSPITAL_COD"].ToString());
            plant.SalaCod = int.Parse(this.reader["SALA_COD"].ToString());
            this.reader.Close();
            this.com.Parameters.Clear();
            this.cn.Close();
            return plant;
        }
        public List<Plantilla> FindFuncion(string funcion)
        {
            string sql = "SELECT * FROM PLANTILLA WHERE FUNCION = @FUNCION";
            SqlParameter pamfunc = new SqlParameter("@FUNCION", funcion);
            this.com.Parameters.Add(pamfunc);
            this.com.CommandText = sql;
            List<Plantilla> plantilla = new List<Plantilla>();
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                Plantilla plant = new Plantilla();
                plant.IdPlantilla = int.Parse(this.reader["EMPLEADO_NO"].ToString());
                plant.Apellido = this.reader["APELLIDO"].ToString();
                plant.Funcion = this.reader["FUNCION"].ToString();
                plant.Salario = int.Parse(this.reader["SALARIO"].ToString());
                plant.HospCod = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                plant.SalaCod = int.Parse(this.reader["SALA_COD"].ToString());
                plantilla.Add(plant);
            }
            this.reader.Close();
            this.com.Parameters.Clear();
            this.cn.Close();
            return plantilla;
        }
    }
}
