using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public sealed class MateriaPrimaDAL : OperacionesAbstractDAL
    {
        #region Atributos y Constructores

        public MateriaPrima Materia { get; set; }

        public MateriaPrimaDAL()
        {

        }

        public MateriaPrimaDAL(MateriaPrima Materia)
        {
            this.Materia = Materia;
        }

        #endregion

        #region Metodos

        public override void Insert()
        {
            string query = @"INSERT INTO MateriaPrima (nombre, stock, cantidadMinima, ultimoDiaReposicion, unidadMedida, idAlmacen) 
                            VALUES (@nombre, @stock, @cantidadMinima, @ultimoDiaReposicion, @unidadMedida, @idAlmacen)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@nombre", Materia.Nombre);
                cmd.Parameters.AddWithValue("@stock", Materia.Stock);
                cmd.Parameters.AddWithValue("@cantidadMinima", Materia.CantidadMinima);
                cmd.Parameters.AddWithValue("@ultimoDiaReposicion", Materia.UltimoDiaReposicion);
                cmd.Parameters.AddWithValue("@unidadMedida", Materia.UnidadMedida);
                cmd.Parameters.AddWithValue("@idAlmacen", Materia.IdAlmacen);

                //Ejecutamos el comando
                //Methods.ExecuteBasicCommand(cmd);
                Methods.ExecuteBasicCommandWithTransaction(cmd);

                string queryAuditoria = @"INSERT INTO Auditoria (tabla, crud, descripcion, idUsuario)
                                            VALUES (@tabla, @crud, @descripcion, @idUsuario)";
                cmd = null;
                cmd = Methods.CreateBasicCommand(queryAuditoria);
                cmd.Parameters.AddWithValue("@tabla", "MateriaPrima");
                cmd.Parameters.AddWithValue("@crud", "C");
                cmd.Parameters.AddWithValue("@descripcion", "ID=" + Methods.GetActIdTable("MateriaPrima") + " MAteria prima insertada");
                cmd.Parameters.AddWithValue("@idUsuario", Sesion.idUsuario);
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Update()
        {
            string query = "UPDATE MateriaPrima SET nombre=@nombre, stock=@stock, cantidadMinima=@cantidadMinima, ultimoDiaReposicion=@ultimoDiaReposicion, unidadMedida=@unidadMedida, idAlmacen=@idAlmacen WHERE idMateria=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@nombre", Materia.Nombre);
                cmd.Parameters.AddWithValue("@stock", Materia.Stock);
                cmd.Parameters.AddWithValue("@cantidadMinima", Materia.CantidadMinima);
                cmd.Parameters.AddWithValue("@ultimoDiaReposicion", Materia.UltimoDiaReposicion);
                cmd.Parameters.AddWithValue("@unidadMedida", Materia.UnidadMedida);
                cmd.Parameters.AddWithValue("@idAlmacen", Materia.IdAlmacen);
                cmd.Parameters.AddWithValue("@id", Materia.IdMateria);

                //Ejecutamos el comando
                //Methods.ExecuteBasicCommand(cmd);
                Methods.ExecuteBasicCommandWithTransaction(cmd);

                string queryAuditoria = @"INSERT INTO Auditoria (tabla, crud, descripcion, idUsuario)
                                            VALUES (@tabla, @crud, @descripcion, @idUsuario)";
                cmd = null;
                cmd = Methods.CreateBasicCommand(queryAuditoria);
                cmd.Parameters.AddWithValue("@tabla", "MateriaPrima");
                cmd.Parameters.AddWithValue("@crud", "U");
                cmd.Parameters.AddWithValue("@descripcion", "ID=" + Materia.IdMateria + " Materia Prima modificada");
                cmd.Parameters.AddWithValue("@idUsuario", Sesion.idUsuario);
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Delete()
        {
            string query = "UPDATE MateriaPrima SET estado=0 WHERE idMateria=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", Materia.IdMateria);

                //Ejecutamos el comando
                //Methods.ExecuteBasicCommand(cmd);
                Methods.ExecuteBasicCommandWithTransaction(cmd);

                string queryAuditoria = @"INSERT INTO Auditoria (tabla, crud, descripcion, idUsuario)
                                            VALUES (@tabla, @crud, @descripcion, @idUsuario)";
                cmd = null;
                cmd = Methods.CreateBasicCommand(queryAuditoria);
                cmd.Parameters.AddWithValue("@tabla", "MateriaPrima");
                cmd.Parameters.AddWithValue("@crud", "D");
                cmd.Parameters.AddWithValue("@descripcion", "ID=" + Materia.IdMateria + " Materia Prima eliminada");
                cmd.Parameters.AddWithValue("@idUsuario", Sesion.idUsuario);
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataTable Select()
        {
            DataTable result = new DataTable();
            string query = "SELECT * FROM vwMateriaPrima ORDER BY 2";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                result = Methods.ExecuteDataTableCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public MateriaPrima Get(short id)
        {
            MateriaPrima materia = null;

            string query = @"SELECT idMateria, nombre, stock, cantidadMinima, ultimoDiaReposicion, unidadMedida, idAlmacen, estado FROM MateriaPrima WHERE idMateria = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    materia = new MateriaPrima(short.Parse(dr[0].ToString()),dr[1].ToString(),short.Parse(dr[2].ToString()), byte.Parse(dr[3].ToString()),DateTime.Parse(dr[4].ToString()),dr[5].ToString(),byte.Parse(dr[7].ToString()),byte.Parse(dr[6].ToString()));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                dr.Close();
            }

            return materia;
        }

        /// <summary>
        /// Metodo para actualizar el Stock
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cantidad"></param>
        /// <param name="operacion">0 = verificar, 1 = Aumentar, 2 = reducir</param>
        public static void UpdateStock(short id, double cantidad, byte operacion)
        {
            string query = "UPDATE MateriaPrima SET stock=@stock WHERE idMateria=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", id);

                if (operacion == 1)
                {
                    cmd.Parameters.AddWithValue("@stock", GetStock(id) + cantidad);
                }
                else if(operacion == 2)
                {
                    cmd.Parameters.AddWithValue("@stock", GetStock(id) - cantidad);
                }

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static short GetStock(short id)
        {
            short stock = 0;

            string query = @"SELECT stock FROM MateriaPrima WHERE idMateria = @id AND estado=1";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    stock = short.Parse(dr[0].ToString());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                dr.Close();
            }

            return stock;
        }

        public DataTable SelectByIdName(short id)
        {
            DataTable res = new DataTable();

            try
            {
                string query = @"SELECT M.idMateria, M.nombre
                                    FROM MateriaPrima M
                                    INNER JOIN ProveedorMateria P ON P.idProveedor = @id
                                    WHERE M.estado = 1 AND M.idMateria = P.idMateria AND P.idProveedor = @id";

                SqlCommand cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                res = Methods.ExecuteDataTableCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return res;
        }

        public DataTable SelectIdName()
        {
            DataTable res = new DataTable();

            try
            {
                string query = @"SELECT idMateria, nombre FROM MateriaPrima WHERE estado = 1";

                SqlCommand cmd = Methods.CreateBasicCommand(query);
                res = Methods.ExecuteDataTableCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return res;
        }

        public static void UpdateStock(byte operacion, short idMateria, double cantidad, int idProduccion)
        {
            string query = "exec dbo.uspUpdateStockMateria @idOperacion, @idMateria, @cantidad, @idProduccion";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idOperacion", operacion);
                cmd.Parameters.AddWithValue("@idMateria", idMateria);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@idProduccion", idProduccion);
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
