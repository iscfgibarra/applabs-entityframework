using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppLabs.EntityFramework.Web.Demo.Models;
using AppLabs.EntityFramework.Interfaces;
using AppLabs.EntityFramework.Data.Entities;

namespace AppLabs.EntityFramework.Web.Demo.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUnitOfWork _uow;
        private readonly IRepository<Proyecto> _proyectosRepository;
        private readonly IRepository<Entrada> _entradaRepository;
        private readonly IRepository<Etiqueta> _etiquetaRepository;


        public HomeController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _proyectosRepository = _uow.GetRepository<Proyecto>();
            _entradaRepository = _uow.GetRepository<Entrada>();
            _etiquetaRepository = _uow.GetRepository<Etiqueta>();
        }

        public async Task<IActionResult> Index()
        {
            await DeleteDatosDePrueba();

            var proyecto = await _proyectosRepository.AddAsync(new Proyecto
            {
                ProyectoId = 1,
                Nombre = "Proyecto Prueba",
                Descripcion = "Este es un proyecto de prueba"

            });
            var etiqueta = await _etiquetaRepository.AddAsync(new Etiqueta
            {
                EtiquetaId = 1,
                Nombre = "Desarrollo",
                Descripcion = "Actividades de desarrollo"
            });


            
                var entrada = await _entradaRepository.AddAsync(new Entrada
                {
                    EntradaId = 1,
                    Nombre = "Creacion de API de Bitacora",
                    Descripcion = "Se realizará la APÍ de bitacora",
                    Fecha = DateTime.Now,
                    EtiquetaId = etiqueta.EtiquetaId,
                    ProyectoId = proyecto.ProyectoId
                });

                _uow.Save();
                return View(entrada);
            
        }

        

        private async Task DeleteDatosDePrueba()
        {
            var entradas = await _entradaRepository.GetAllAsync();

            foreach (var e in entradas)
            {
                _entradaRepository.Delete(e);
            }

            var proyectos = await _proyectosRepository.GetAllAsync();

            foreach(var p in proyectos)
            {
                _proyectosRepository.Delete(p);
            }

            var etiquetas = await _etiquetaRepository.GetAllAsync();

            foreach (var item in etiquetas)
            {
                _etiquetaRepository.Delete(item);
            }

            _uow.Save();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
