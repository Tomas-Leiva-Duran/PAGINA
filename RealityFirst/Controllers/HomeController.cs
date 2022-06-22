﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using RealityFirst.Models;
using RealityFirst.Servicio;
using Microsoft.Extensions.Configuration;

namespace RealityFirst.Controllers
{
    public class HomeController : Controller
    {
        IConfiguration config;
        ArtistaServicio artista;

        NoticiaServicio noticia;    

        public HomeController(IConfiguration config)
        {
            this.config = config;
            string ConnectionString = config.GetConnectionString("DBRealityFirst");
            artista = new ArtistaServicio(ConnectionString);
            noticia = new NoticiaServicio(ConnectionString);

        }

        public IActionResult Artista()
        {
            IList<ArtistaModel> lista = artista.GetAll();
            return View("Artista", lista);
        }

        public IActionResult Index()
        {
            IList<NoticiaModel> lista = noticia.GetAll();
            return View("Index", lista);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }

        public IActionResult Ficha_artista(int id)
        {
            ArtistaModel Obj = artista.Get(id);
            return View(Obj);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
