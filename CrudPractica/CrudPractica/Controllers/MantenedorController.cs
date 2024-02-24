using Microsoft.AspNetCore.Mvc;
using CrudPractica.Datos;
using CrudPractica.Models;

namespace CrudPractica.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _contactoDatos = new ContactoDatos();
        public IActionResult Listar()
        {
            //muestra lista de comntactos
            var lista = _contactoDatos.ObtenerLista();
            return View(lista); // el form recibe toda la lista
        }
        public IActionResult Guardar()
        {
            //solo devuelve la vista(formulario html)
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel contacto)
        {
            //recibir un objeto para guardarlo en la bd

            if (!ModelState.IsValid) // si hay un campo obligatorio vacio
                 return View();
  
            var respuesta = _contactoDatos.Guardar(contacto);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
            
        }

        public IActionResult Editar(int Idcontacto)
        {
            //solo devuelve la vista(formulario html)
            var contacto = _contactoDatos.ObtenerContacto(Idcontacto);
            return View(contacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel contacto)
        {
            //metodo que recibe el objeto para poder editarlo
            if (!ModelState.IsValid) // si hay un campo obligatorio vacio
                return View();

            var respuesta = _contactoDatos.Editar(contacto);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int Idcontacto)
        {
            //solo devuelve la vista(formulario html)
            var contacto = _contactoDatos.ObtenerContacto(Idcontacto);
            return View(contacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel contacto)
        {
            //metodo que recibe el objeto para poder eliminarlo
        
            var respuesta = _contactoDatos.Eliminar(contacto.Idcontacto);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
    }
}
