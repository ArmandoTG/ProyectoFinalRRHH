using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Data;
using System.Data.SqlClient;


namespace ProyectoComisiones.Models
{
    public class Listas
    {
        public Listas()
        {}
        private string vStrError;

        private ClsDato ObjDatos = new ClsDato();

        public string Retorna_Error()
        {
            return vStrError;
        }



        public List<Home> LstPedidosBux(string pnro_pedido, string fechainicio, string fechafin)
        {
            Home b_PedidoBux = new Home();
            List<Home> b_usuario = new List<Home>();
            DataTable dt = new DataTable();
            dt = ObjDatos.LstPedidosBUX(pnro_pedido,fechainicio,fechafin);
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    b_PedidoBux = new Home();
                    b_PedidoBux.Empresa = dt.Rows[i]["Empresa"].ToString();
                    b_PedidoBux.CP = dt.Rows[i]["CP"].ToString();
                    b_PedidoBux.FCH_DOC = dt.Rows[i]["FCH_DOC"].ToString();
                    b_PedidoBux.Cliente = dt.Rows[i]["Cliente"].ToString();
                    b_PedidoBux.UUNN = dt.Rows[i]["UUNN"].ToString();
                    b_PedidoBux.Monto = dt.Rows[i]["Monto"].ToString();
                    b_PedidoBux.MARGEN = dt.Rows[i]["MARGEN"].ToString();
                    b_PedidoBux.ImporteMargen = dt.Rows[i]["ImporteMargen"].ToString();
                    b_PedidoBux.TEAM = dt.Rows[i]["TEAM"].ToString();
                    b_PedidoBux.TP = dt.Rows[i]["TP"].ToString();
                    b_PedidoBux.TC_D = dt.Rows[i]["TC_D"].ToString();
                    b_PedidoBux.TipoMoneda = dt.Rows[i]["TipoMoneda"].ToString();
                    b_PedidoBux.EstadoCP = dt.Rows[i]["EstadoCP"].ToString();


                    b_usuario.Add(b_PedidoBux);
                }
            }
            catch (Exception ex)
            {
                vStrError = ex.Message;
            }
            return b_usuario;
        }

        public List<Facturas> LstFacturas(string nro_pedido)
        {
            Facturas b_BuxFacturas = new Facturas();
            List<Facturas> b_usuario = new List<Facturas>();
            DataTable dt = new DataTable();
            dt = ObjDatos.LstFacturas(nro_pedido);
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    b_BuxFacturas = new Facturas();
                    b_BuxFacturas.NCP = dt.Rows[i]["NCP"].ToString();
                    b_BuxFacturas.CLIENTE = dt.Rows[i]["CLIENTE"].ToString();
                    b_BuxFacturas.NFACTURA = dt.Rows[i]["NFACTURA"].ToString();
                    b_BuxFacturas.FEMISION = dt.Rows[i]["FEMISION"].ToString();
                    b_BuxFacturas.FCANCEL = dt.Rows[i]["FCANCEL"].ToString();
                    b_BuxFacturas.VALORDEVENTA = dt.Rows[i]["VALORDEVENTA"].ToString();
                    b_BuxFacturas.DEBEDOLAR = dt.Rows[i]["DEBEDOLAR"].ToString();
                    b_BuxFacturas.HABERDOLAR = dt.Rows[i]["HABERDOLAR"].ToString();
                    b_BuxFacturas.DEBESOLES = dt.Rows[i]["DEBESOLES"].ToString();
                    b_BuxFacturas.HABERSOLES = dt.Rows[i]["HABERSOLES"].ToString();
                    b_BuxFacturas.ESTADO = dt.Rows[i]["ESTADO"].ToString();
                    b_BuxFacturas.CONDICIONDEPAGO = dt.Rows[i]["CONDICIONDEPAGO"].ToString();
                    b_BuxFacturas.MONEDA = dt.Rows[i]["MONEDA"].ToString();
                    


                    b_usuario.Add(b_BuxFacturas);
                }
            }
            catch (Exception ex)
            {
                vStrError = ex.Message;
            }
            return b_usuario;
        }



        public List<Proveedores> LstProveedores(string nro_pedido)
        {
            Proveedores b_BuxProveedores = new Proveedores();
            List<Proveedores> b_usuario = new List<Proveedores>();
            DataTable dt = new DataTable();
            dt = ObjDatos.LstProveedores(nro_pedido);
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    b_BuxProveedores = new Proveedores();
                    b_BuxProveedores.RAZON_SOCIAL = dt.Rows[i]["RAZON_SOCIAL"].ToString();
                    b_BuxProveedores.PAGO = dt.Rows[i]["PAGO"].ToString();
                    b_BuxProveedores.MONEDA = dt.Rows[i]["MONEDA"].ToString();
                    b_BuxProveedores.FECHAPAGO = dt.Rows[i]["FECHAPAGO"].ToString();
                    b_BuxProveedores.IMPORTE = dt.Rows[i]["IMPORTE"].ToString();
                    b_BuxProveedores.ESTADO = dt.Rows[i]["ESTADO"].ToString();



                    b_usuario.Add(b_BuxProveedores);
                }
            }
            catch (Exception ex)
            {
                vStrError = ex.Message;
            }
            return b_usuario;
        }




        public List<Home> LstVendedores()
        {
            Home b_Vendedores = new Home();
            List<Home> b_usuario = new List<Home>();
            DataTable dt = new DataTable();
            dt = ObjDatos.LstVendedores();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    b_Vendedores = new Home();
                    b_Vendedores.COD_VENDEDOR = dt.Rows[i]["COD_VENDEDOR"].ToString();
                    b_Vendedores.DSC_50 = dt.Rows[i]["DSC_50"].ToString();
                    b_usuario.Add(b_Vendedores);
                }
            }
            catch (Exception ex)
            {
                vStrError = ex.Message;
            }
            return b_usuario;
        }








    }
}