using Livraria_Lunar_E_commerce.Business;
using Livraria_Lunar_E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Livraria_Lunar_E_commerce.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        public ActionResult Index(int id)
        {

            ClientesAcoes acCliente = new ClientesAcoes();
            return View(acCliente.ConsultaPerfil(id).Find(dto => dto.cd_cliente == id));
        }

        [HttpPost]
        public ActionResult Index(Cliente dto)
        {
            if (ModelState.IsValid)
            {
                ClientesAcoes acCliente = new ClientesAcoes();
                acCliente.Alterar(dto);
            }
            
            return View();
        }


        public ActionResult Pedidos(int id)
        {
            PedidoAcoes acPedidos = new PedidoAcoes();
            return View(acPedidos.Consultar(id));
        }
    }
}