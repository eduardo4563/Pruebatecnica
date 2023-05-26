using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using MVC_CRUD.Datos;
using MVC_CRUD.Models;
using NuGet.Protocol.Plugins;

namespace MVC_CRUD.Controllers
{
    public class MantenedorController : Controller
    {

        Librosdatos _librosdatos=new Librosdatos();
        asignaturadatos _asigdatos = new asignaturadatos();
    
      
        public IActionResult Listar()
        {
            //la vista mostrara una lista de libros
            var olista = _librosdatos.Listar();
            return View(olista);
        }
   

        [HttpPost]
        public IActionResult Listar(string busqueda = "")
        {
            //la vista mostrara una lista de libros
            
            var olista = _librosdatos.Busqueda(busqueda);
          
            
            return View(olista);

            
        }
        public IActionResult Guardar()
        {
          
            //metodo solo devuelve la vista
            

            return View();
        }
        [HttpPost]
        public IActionResult Guardar(librosmodel olibros)
        {
            //metodo recibe el objeto para guardar en la base de datox

            if (!ModelState.IsValid)
                return View();


            var respuesta = _librosdatos.Guardar(olibros);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Editar(int Idlibros)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var olibro = _librosdatos.Obtener(Idlibros);
            return View(olibro);
        }

        [HttpPost]
        public IActionResult Editar(librosmodel olibro)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _librosdatos.Actualizar(olibro);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Eliminar(int Idlibros)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ocontacto = _librosdatos.Obtener(Idlibros);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Eliminar(librosmodel olibro)
        {

            var respuesta = _librosdatos.Eliminar(olibro.id_libro);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        //asignatura

        public IActionResult Listar_asi()
        {
            //la vista mostrara una lista de libros
            var olista = _asigdatos.Listar();
            return View(olista);
        }
        public IActionResult Guardar_asi()
        {
            //metodo solo devuelve la vista
            return View();
        }
        [HttpPost]
        public IActionResult Guardar_asi(asignaturamodel oasi)
        {
            //metodo recibe el objeto para guardar en la base de datox

            if (!ModelState.IsValid)
                return View();


            var respuesta = _asigdatos.Guardar(oasi);

            if (respuesta)
                return RedirectToAction("Listar_asi");
            else
                return View();
        }


        public IActionResult Editar_asi(int Idasignatura)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oasi = _asigdatos.Obtener(Idasignatura);
            return View(oasi);
        }

        [HttpPost]
        public IActionResult Editar_asi(asignaturamodel oasi)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _asigdatos.Actualizar(oasi);

            if (respuesta)
                return RedirectToAction("Listar_asi");
            else
                return View();
        }


        public IActionResult Eliminar_asi(int Idasignatura)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oasi = _asigdatos.Obtener(Idasignatura);
            return View(oasi);
        }

        [HttpPost]
        public IActionResult Eliminar_asi(asignaturamodel OASI)
        {

            var respuesta = _asigdatos.Eliminar(OASI.id_asig);

            if (respuesta)
                return RedirectToAction("Listar_asi");
            else
                return View();
        }


    }
}
