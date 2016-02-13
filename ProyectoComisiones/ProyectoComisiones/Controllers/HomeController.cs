using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ProyectoComisiones.Models;




namespace ProyectoComisiones.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        Listas objDato = new Listas();

        public ActionResult Index()
        {

            List<Home> pcontent = new List<Home>();

            //Get all page content from TblHome table

            pcontent = objDato.LstVendedores();

            List<SelectListItem> vendedores = new List<SelectListItem>();
            foreach (var item in pcontent)
            {
                vendedores.Add(new SelectListItem
                {
                    Text = item.DSC_50,
                    Value = item.COD_VENDEDOR.ToString()
                });
            }

            ViewBag.Vendedores = vendedores;
            return View();

        }

        [HttpPost]
        public ActionResult Index(string DSC_50, string fchinicio, string fchfinal)
        {
            List<Home> pcontent = new List<Home>();

            //Get all page content from TblHome table

            pcontent = objDato.LstVendedores();

            List<SelectListItem> vendedores = new List<SelectListItem>();
            foreach (var item in pcontent)
            {
                vendedores.Add(new SelectListItem
                {
                    Text = item.DSC_50,
                    Value = item.COD_VENDEDOR.ToString()
                });
            }

            ViewBag.Vendedores = vendedores;


            List<Home> lstUsuario = new List<Home>();
            lstUsuario = objDato.LstPedidosBux(DSC_50, fchinicio, fchfinal);
            return View(lstUsuario);


        }

         
            //PartialViewResult

        public PartialViewResult Facturas(string NroPedido)
        {

            List<Facturas> lstFacturas = new List<Facturas>();
            lstFacturas = objDato.LstFacturas(NroPedido);
            //return View(lstFacturas);

            return PartialView("Facturas", lstFacturas);

        }

        public PartialViewResult Proveedores(string NroPedido)
        {

            List<Proveedores> lstProveedores = new List<Proveedores>();
            lstProveedores = objDato.LstProveedores(NroPedido);
            //return View(lstFacturas);

            return PartialView("Proveedores", lstProveedores);

        }



   



        //public ActionResult Facturas(string NroPedido)
        //{

        //    List<Facturas> lstFacturas = new List<Facturas>();
        //    lstFacturas = objDato.LstFacturas(NroPedido);


        //    ViewBag.lstFacturas = lstFacturas;

        //    return PartialView("Facturas");

        //}



 

    }
}
