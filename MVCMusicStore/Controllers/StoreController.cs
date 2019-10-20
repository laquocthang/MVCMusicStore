﻿using MVCMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore.Controllers
{
	public class StoreController : Controller
	{
		MusicStoreEntities storeDB = new MusicStoreEntities();

		// GET: Store
		public ActionResult Index()
		{
			var genres = storeDB.Genres.ToList();
			return View(genres);
		}

		//
		// GET: /Store/Browse?genre=Disco
		// Use the .Single() in LINQ to query for the appropriate Genre onject
		public ActionResult Browse(string genre)
		{
			var genreModel = storeDB.Genres.Include("Albums").Single(g => g.Name == genre);
			return View(genreModel);
		}

		//
		// GET: /Store/Details/5
		// ASP.NET MVC will automatically pass the URL segment to you as a parameter
		public ActionResult Details(int id)
		{
			var album = storeDB.Albums.Find(id);
			return View(album);
		}
	}
}