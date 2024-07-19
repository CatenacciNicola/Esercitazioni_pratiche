using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ContravvenzioniWebApp.DAO;
using ContravvenzioniWebApp.Models;
using ContravvenzioniWebApp.Data;

public class SelectController : Controller
{
    private readonly VerbaleDAO _verbaleDAO;

    public SelectController(VerbaleDAO verbaleDAO)
    {
        _verbaleDAO = verbaleDAO;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult VerbaliPerTrasgressore()
    {
        var result = _verbaleDAO.GetVerbaliPerTrasgressore();
        return View(result);
    }

    public IActionResult PuntiDecurtatiPerTrasgressore()
    {
        var result = _verbaleDAO.GetPuntiDecurtatiPerTrasgressore();
        return View(result);
    }

    public IActionResult VerbaliOltre10Punti()
    {
        var result = _verbaleDAO.GetVerbaliOltre10Punti();
        return View(result);
    }

    public IActionResult VerbaliOltre400Euro()
    {
        var result = _verbaleDAO.GetVerbaliOltre400Euro();
        return View(result);
    }
}
