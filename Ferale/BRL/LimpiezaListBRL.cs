using Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
    public sealed class LimpiezaListBRL
    {
        public static DBFeraleDataSet ObtenerListaEmpleadoReporte1(DateTime fechaInicio, DateTime fechaFin)
        {
            DBFeraleDataSet feraleDataSet = null;

            try
            {
                feraleDataSet = LimpiezaDAL.ObtenerListaLimpiezaReporte1(fechaInicio, fechaFin);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return feraleDataSet;
        }

        public static DBFeraleDataSet ObtenerListaEmpleadoReporte2(byte idEstablecimiento)
        {
            DBFeraleDataSet feraleDataSet = null;

            try
            {
                feraleDataSet = LimpiezaDAL.ObtenerListaLimpiezaReporte2(idEstablecimiento);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return feraleDataSet;
        }

        public static DBFeraleDataSet ObtenerListaEmpleadoReporte3(byte idTipoLimpieza)
        {
            DBFeraleDataSet feraleDataSet = null;

            try
            {
                feraleDataSet = LimpiezaDAL.ObtenerListaLimpiezaReporte3(idTipoLimpieza);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return feraleDataSet;
        }
    }
}
