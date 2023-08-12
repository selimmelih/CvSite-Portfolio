﻿using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Web.Mvc;
namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        GenericRepository<TblSertifikalarim> repo = new GenericRepository<TblSertifikalarim>();
        // GET: Sertifika
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            ViewBag.d = id;
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifikalarim t)
        {
            var sertifika = repo.Find(x=>x.ID== t.ID);  
            sertifika.Aciklama= t.Aciklama;
            sertifika.Tarih= t.Tarih;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(TblSertifikalarim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x=>x.ID  == id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }
    }
}