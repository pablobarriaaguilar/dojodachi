using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;

namespace Dojodachi.Controllers;

public class HomeController : Controller
{  
     
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        if(HttpContext.Session.GetInt32("Fullness")== null && HttpContext.Session.GetInt32("Meals") ==null 
        && HttpContext.Session.GetInt32("Happiness")==null && HttpContext.Session.GetInt32("Happiness")==null && HttpContext.Session.GetInt32("Energy")==null) 
        {
            Pet _pet =new Pet();
            HttpContext.Session.SetInt32("Fullness",_pet.Saciedad);
            HttpContext.Session.SetInt32("Meals",_pet.Comida);
            HttpContext.Session.SetInt32("Happiness",_pet.Felicidad);
            HttpContext.Session.SetInt32("Energy",_pet.Energia);
        }
    return View();
    }



    [HttpPost]
    [Route("Feed")]
    public IActionResult Feed()
    {
        Pet _pet = new Pet();
        _pet.Saciedad =(int)HttpContext.Session.GetInt32("Fullness");
        _pet.Comida = (int)HttpContext.Session.GetInt32("Meals");
        _pet.Felicidad = (int)HttpContext.Session.GetInt32("Happiness");
        _pet.Energia = (int)HttpContext.Session.GetInt32("Energy");

        string mensaje =  _pet.Alimentar(_pet);

        HttpContext.Session.SetInt32("Fullness",_pet.Saciedad);
        HttpContext.Session.SetInt32("Meals",_pet.Comida);
        HttpContext.Session.SetInt32("Happiness",_pet.Felicidad);
        HttpContext.Session.SetInt32("Energy",_pet.Energia);
        HttpContext.Session.SetString("mensaje",mensaje);

        _pet.Saciedad =(int)HttpContext.Session.GetInt32("Fullness");
        _pet.Comida = (int)HttpContext.Session.GetInt32("Meals");
        _pet.Felicidad = (int)HttpContext.Session.GetInt32("Happiness");
        _pet.Energia = (int)HttpContext.Session.GetInt32("Energy");

        Console.WriteLine(_pet.ComprobarGanar(_pet) + _pet.Saciedad + _pet.Felicidad);
        if(_pet.ComprobarGanar(_pet) ==  "Ganaste"){
            HttpContext.Session.SetString("comprobacion","ganaste");
            HttpContext.Session.SetString("mensaje","ganaste");
        }

        if(_pet.ComprobarPerder() =="Perdiste"){
            HttpContext.Session.SetString("comprobacion","perdiste");
            HttpContext.Session.SetString("mensaje","Tu mascota a muerto!");
        }

        return View("Index");
    }

    [HttpPost]
    [Route("Play")]
    public IActionResult Play()
    {
        Pet _pet = new Pet();
        _pet.Saciedad =(int)HttpContext.Session.GetInt32("Fullness");
        _pet.Comida = (int)HttpContext.Session.GetInt32("Meals");
        _pet.Felicidad = (int)HttpContext.Session.GetInt32("Happiness");
        _pet.Energia = (int)HttpContext.Session.GetInt32("Energy");

        string mensaje = _pet.Jugar();

        HttpContext.Session.SetInt32("Fullness",_pet.Saciedad);
        HttpContext.Session.SetInt32("Meals",_pet.Comida);
        HttpContext.Session.SetInt32("Happiness",_pet.Felicidad);
        HttpContext.Session.SetInt32("Energy",_pet.Energia);
        HttpContext.Session.SetString("mensaje",mensaje);

        if(_pet.ComprobarGanar(_pet) ==  "Ganaste"){
            HttpContext.Session.SetString("comprobacion","ganaste");
            HttpContext.Session.SetString("mensaje",mensaje);
        }

        if(_pet.ComprobarPerder() =="Perdiste"){
            HttpContext.Session.SetString("comprobacion","perdiste");
            HttpContext.Session.SetString("mensaje","Tu mascota a muerto!");
        }

        return View("Index");
    }

    [HttpPost]
    [Route("Work")]
    public IActionResult Work()
    {
        Pet _pet = new Pet();
        _pet.Saciedad =(int)HttpContext.Session.GetInt32("Fullness");
        _pet.Comida = (int)HttpContext.Session.GetInt32("Meals");
        _pet.Felicidad = (int)HttpContext.Session.GetInt32("Happiness");
        _pet.Energia = (int)HttpContext.Session.GetInt32("Energy");

       string mensaje = _pet.Trabajar();

        HttpContext.Session.SetInt32("Fullness",_pet.Saciedad);
        HttpContext.Session.SetInt32("Meals",_pet.Comida);
        HttpContext.Session.SetInt32("Happiness",_pet.Felicidad);
        HttpContext.Session.SetInt32("Energy",_pet.Energia);
        HttpContext.Session.SetString("mensaje",mensaje);

        if(_pet.ComprobarGanar(_pet) ==  "Ganaste"){
            HttpContext.Session.SetString("comprobacion","ganaste");
            HttpContext.Session.SetString("mensaje",mensaje);
        }

        if(_pet.ComprobarPerder() =="Perdiste"){
            HttpContext.Session.SetString("comprobacion","perdiste");
            HttpContext.Session.SetString("mensaje","Tu mascota a muerto!");
        }

        return View("Index");
    }

    [HttpPost]
    [Route("Sleep")]
    public IActionResult Sleep()
    {
        Pet _pet = new Pet();
        _pet.Saciedad =(int)HttpContext.Session.GetInt32("Fullness");
        _pet.Comida = (int)HttpContext.Session.GetInt32("Meals");
        _pet.Felicidad = (int)HttpContext.Session.GetInt32("Happiness");
        _pet.Energia = (int)HttpContext.Session.GetInt32("Energy");

        string mensaje = _pet.Dormir();

        HttpContext.Session.SetInt32("Fullness",_pet.Saciedad);
        HttpContext.Session.SetInt32("Meals",_pet.Comida);
        HttpContext.Session.SetInt32("Happiness",_pet.Felicidad);
        HttpContext.Session.SetInt32("Energy",_pet.Energia);
        HttpContext.Session.SetString("mensaje",mensaje);
        if(_pet.ComprobarGanar(_pet) ==  "Ganaste"){
            HttpContext.Session.SetString("comprobacion","ganaste");
            HttpContext.Session.SetString("mensaje",mensaje);
        }

        if(_pet.ComprobarPerder() =="Perdiste"){
            HttpContext.Session.SetString("comprobacion","perdiste");
            HttpContext.Session.SetString("mensaje","Tu mascota a muerto!");
        }

        return View("Index");
    }

    [HttpPost]
    [Route("Reinicio")]
    public IActionResult Reinicio(){
        HttpContext.Session.Clear();
         Pet _pet = new Pet();
        

        string mensaje =  _pet.Alimentar(_pet);

        HttpContext.Session.SetInt32("Fullness",_pet.Saciedad);
        HttpContext.Session.SetInt32("Meals",_pet.Comida);
        HttpContext.Session.SetInt32("Happiness",_pet.Felicidad);
        HttpContext.Session.SetInt32("Energy",_pet.Energia);
        HttpContext.Session.SetString("mensaje",mensaje);

        _pet.Saciedad =(int)HttpContext.Session.GetInt32("Fullness");
        _pet.Comida = (int)HttpContext.Session.GetInt32("Meals");
        _pet.Felicidad = (int)HttpContext.Session.GetInt32("Happiness");
        _pet.Energia = (int)HttpContext.Session.GetInt32("Energy");
        return RedirectToAction("Index");
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
