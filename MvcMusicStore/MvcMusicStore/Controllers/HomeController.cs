﻿using MvcMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    public class HomeController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            var albums = GetTopSellingAlbums(5);
            return View(albums);
        }

        private List<Album> GetTopSellingAlbums(int count)
        {
            return storeDB.Albums.OrderByDescending(o => o.OrderDetails.Count())
                .Take(count)
                .ToList();
        }

        public ActionResult Search(string SearchValue)
        {
            List<Album> albums = null;

            if (!string.IsNullOrEmpty(SearchValue))
            {
                albums = storeDB.Albums.Where(a => a.Title.Contains(SearchValue) || a.Artist.Name.Contains(SearchValue)).ToList();
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View(albums);
        }

    }
}
