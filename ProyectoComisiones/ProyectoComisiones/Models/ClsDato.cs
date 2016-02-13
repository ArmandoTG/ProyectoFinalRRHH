using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

namespace ProyectoComisiones.Models
{
    public class ClsDato
    {

        public ClsDato()
        { }

        private string vStrError;
        CdnConexionBD objSql = new CdnConexionBD();

        public string Retorna_Error()
        {
            return vStrError;
        }

        public DataTable LstPedidosBUX(string vendedor, string fechainicio, string fechafin)
        {
            DataTable dt = new DataTable();
            DataTable dtlDt = new DataTable();
            try
            {
                dtlDt.Columns.Add("Dato");
                dtlDt.Rows.Add(vendedor);
                dtlDt.Rows.Add(fechainicio);
                dtlDt.Rows.Add(fechafin);
                dt = objSql.Selecciona_Tabla("ListaCP_x_Vendedor_y_Rango_Fechas_3", dtlDt);
                vStrError = objSql.Retorna_Error();
            }
            catch (Exception ex)
            {
                vStrError = ex.Message;
            }
            return dt;
        }


        public DataTable LstFacturas(string nropedido)
        {
            DataTable dt = new DataTable();
            DataTable dtlDt = new DataTable();
            try
            {
                dtlDt.Columns.Add("Dato");
                dtlDt.Rows.Add(nropedido);
                dt = objSql.Selecciona_Tabla("SP_LISTA_FACTURAS_CP", dtlDt);
                vStrError = objSql.Retorna_Error();
            }
            catch (Exception ex)
            {
                vStrError = ex.Message;
            }
            return dt;
        }


        public DataTable LstProveedores(string nropedido)
        {
            DataTable dt = new DataTable();
            DataTable dtlDt = new DataTable();
            try
            {
                dtlDt.Columns.Add("Dato");
                dtlDt.Rows.Add(nropedido);
                dt = objSql.Selecciona_Tabla("Lista_Proveedores_Por_CP", dtlDt);
                vStrError = objSql.Retorna_Error();
            }
            catch (Exception ex)
            {
                vStrError = ex.Message;
            }
            return dt;
        }







        public DataTable LstVendedores()
        {
            DataTable dt = new DataTable();
            DataTable dtlDt = new DataTable();
            try
            {
                dtlDt.Columns.Add("Dato");
                dt = objSql.Selecciona_Tabla("ListarVendedoresBUX", dtlDt);
                vStrError = objSql.Retorna_Error();
            }
            catch (Exception ex)
            {
                vStrError = ex.Message;
            }
            return dt;
        }

        

    }
}