﻿using Empujar.core.Config;
using Empujar.core.DbContexts;
using Empujar.core.Models.CONF;
using Empujar.mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Empujar.mvc.Controllers
{
    public class TipoCentroDeCostoController : Controller
    {
        private readonly WebDBContext db = new WebDBContext();

        //Devuelve la pagina
        public async Task<IActionResult> Index()
        {
            try
            {
                return await Task.Run<ActionResult>(() =>
                {
                    return View();
                });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { mensaje = "Error al ingresar al modulo de Tipos de Centros de Costo. Intente mas tarde." });
            }
        }

        //Devuelve la lista de objetos en JSON
        public async Task<JsonResult> GetInfo()
        {
            var Tipos = await db.TiposDeCentroDeCosto
                            .OrderBy(x => x.Nombre)
                            .Select(y => new { Numeral = y.ID, Nombre = y.Nombre })
                            .ToListAsync();

            return Json(Tipos);
        }

        //Actualiza la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> SaveInfo([Bind("ID,Nombre")] TipoDeCentroDeCostoViewModel tipo, int Numeral, string Mode)
        {
            ResultadoViewModel resultadoView = new ResultadoViewModel();

            if (ModelState.IsValid)
            {
                //Si estoy editando 
                if (Mode == "E")
                {
                    try
                    {
                        //Obtengo el regitro de la tabla correspondiente al objeto que se esta editando
                        var tipoDB = await db.TiposDeCentroDeCosto.FirstOrDefaultAsync(m => m.ID == Numeral);

                        if (tipoDB == null)
                        {
                            resultadoView.returnValue = ConfigAppSetting.NotFoundMessage;
                            return Json(resultadoView);
                        }

                        tipoDB.Nombre = tipo.Nombre;

                        db.Update(tipoDB);
                        await db.SaveChangesAsync();

                    }
                    catch (Exception ex)
                    {
                        resultadoView.returnValue = ConfigAppSetting.DBErrorMessage;
                    }
                }

                //Si estoy borrando 
                if (Mode == "D")
                {
                    try
                    {
                        //Obtengo el regitro de la tabla correspondiente al objeto que quiero borrar
                        var tipoDB = await db.TiposDeCentroDeCosto.FirstOrDefaultAsync(m => m.ID == Numeral);

                        if (tipoDB == null)
                        {
                            resultadoView.returnValue = ConfigAppSetting.NotFoundMessage;
                            return Json(resultadoView);
                        }

                        db.Remove(tipoDB);
                        await db.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        resultadoView.returnValue = ConfigAppSetting.DBErrorMessage;
                    }
                }

                //Si estoy dando de alta
                if (Mode == "A")
                {
                    //Agrego el registros 
                    try
                    {
                        TipoDeCentroDeCosto tipoDB = new TipoDeCentroDeCosto
                        {
                            Nombre = tipo.Nombre
                        };

                        db.TiposDeCentroDeCosto.Add(tipoDB);
                        await db.SaveChangesAsync();
                        resultadoView.NumeralID = tipoDB.ID.ToString();
                    }
                    catch (Exception ex)
                    {
                        resultadoView.returnValue = ConfigAppSetting.DBErrorMessage;
                        return Json(resultadoView);
                    }
                }
            }
            else
            {
                resultadoView.returnValue = string.Join("<br/>", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
            }

            return Json(resultadoView);
        }
    }
}
