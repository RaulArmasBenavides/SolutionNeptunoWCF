using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Servicio.Neptuno.wcf
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "EmpleadoService" en el código y en el archivo de configuración a la vez.
    public class EmpleadoService : IEmpleadoService
    {
        SqlConnection cn;

        public void EmpleadoActualizar(Empleado emp)
        {
            
        }

        public void EmpleadoAdicionar(Empleado emp)
        {
            using (cn = new SqlConnection("server=.;database=neptuno;integrated security=true"))
            {
                var cmd = new SqlCommand("usp_Empleado_Adicionar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Apellido", emp.Apellidos);
                cmd.Parameters.AddWithValue("@Nombre", emp.Nombre);
                cmd.Parameters.AddWithValue("@Cargo", emp.Cargo);
                cmd.Parameters.Add("@IdEmpleado", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    emp.IdEmpleado = (int)cmd.Parameters["@IdEmpleado"].Value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Empleado EmpleadoBuscar(int emp)
        {
            return null;
        }

        public void EmpleadoEliminar(int emp)
        {
           
        }

        public List<Empleado> EmpleadoListar()
        {
            List<Empleado> lista = new List<Empleado>();
            using (cn = new SqlConnection("server=.;database=neptuno;integrated security=true"))
            {
                var cmd = new SqlCommand("usp_Empleado_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Empleado em = new Empleado()
                        {
                            IdEmpleado = Convert.ToInt32(dr[0]),
                            Apellidos = dr[1].ToString(),
                            Nombre = dr[2].ToString(),
                            Cargo = dr[3].ToString()
                        };
                        lista.Add(em);
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return lista;
            }
        }
    }
}
