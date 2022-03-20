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
    public sealed class HonorarioDAL : OperacionesAbstractDAL
    {
        #region Atributos y Constructores

        public Honorario Honorario { get; set; }

        public HonorarioDAL()
        {

        }

        public HonorarioDAL(Honorario Honorario)
        {
            this.Honorario = Honorario;
        }

        #endregion

        #region Metodos

        public override void Insert()
        {
            string query = @"INSERT INTO Honorario (montoTotalCancelado, diaCompletoTrabajo, medioDiaTrabajo, pagoMedioDia, diaFinalPagado, idEmpleado, idMes) 
                            VALUES (@montoTotalCancelado, @diaCompletoTrabajo, @medioDiaTrabajo, @pagoMedioDia, @diaFinalPagado, @idEmpleado, @idMes)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@montoTotalCancelado", Honorario.MontoTotalCancelado);
                cmd.Parameters.AddWithValue("@diaCompletoTrabajo", Honorario.DiaCompletoTrabajo);
                cmd.Parameters.AddWithValue("@medioDiaTrabajo", Honorario.MedioDiaTrabajo);
                cmd.Parameters.AddWithValue("@pagoMedioDia", Honorario.PagoMedioDia);
                cmd.Parameters.AddWithValue("@diaFinalPagado", Honorario.DiaFinalPagado);
                cmd.Parameters.AddWithValue("@idEmpleado", Honorario.IdEmpleado);
                cmd.Parameters.AddWithValue("@idMes", Honorario.IdMes);

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Update()
        {
            string query = "UPDATE Honorario SET montoTotalCancelado=@montoTotalCancelado, diaCompletoTrabajo=@diaCompletoTrabajo, medioDiaTrabajo=@medioDiaTrabajo, pagoMedioDia=@pagoMedioDia, diaFinalPagado=@diaFinalPagado, idEmpleado=@idEmpleado, idMes=@idMes WHERE idHonorario=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@montoTotalCancelado", Honorario.MontoTotalCancelado);
                cmd.Parameters.AddWithValue("@diaCompletoTrabajo", Honorario.DiaCompletoTrabajo);
                cmd.Parameters.AddWithValue("@medioDiaTrabajo", Honorario.MedioDiaTrabajo);
                cmd.Parameters.AddWithValue("@pagoMedioDia", Honorario.PagoMedioDia);
                cmd.Parameters.AddWithValue("@diaFinalPagado", Honorario.DiaFinalPagado);
                cmd.Parameters.AddWithValue("@idEmpleado", Honorario.IdEmpleado);
                cmd.Parameters.AddWithValue("@idMes", Honorario.IdMes);
                cmd.Parameters.AddWithValue("@id", Honorario.IdHonorario);

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Delete()
        {
            string query = "UPDATE Honorario SET estado=0 WHERE idHonorario=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", Honorario.IdHonorario);

                //Ejecutamos el comando
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
            string query = "SELECT * FROM vwHonorario ORDER BY 2";
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

        public Honorario Get(int id)
        {
            Honorario honorario = null;

            string query = @"SELECT idHonorario, fechaCancelado, montoTotalCancelado, diaCompletoTrabajo, medioDiaTrabajo, pagoMedioDia, diaFinalPagado, idEmpleado, idMes, estado FROM Honorario WHERE idHonorario = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    honorario = new Honorario(int.Parse(dr[0].ToString()),DateTime.Parse(dr[1].ToString()),double.Parse(dr[2].ToString()),byte.Parse(dr[3].ToString()),byte.Parse(dr[4].ToString()),double.Parse(dr[5].ToString()),DateTime.Parse(dr[6].ToString()),int.Parse(dr[7].ToString()),short.Parse(dr[8].ToString()),byte.Parse(dr[9].ToString()));
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

            return honorario;
        }

        #endregion
    }
}
