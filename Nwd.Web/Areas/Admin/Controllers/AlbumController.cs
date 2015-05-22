using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nwd.BackOffice.Impl;
using Nwd.BackOffice.Model;

namespace Nwd.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class AlbumController : Controller
    {
        // GET: Admin/Album
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View( new List<Album>() );
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View( new Album() );
        }

        [HttpPost]
        public ActionResult Create( Album album )
        {
            if (ModelState.IsValid)
            {
                var repo = new AlbumRepository();
                repo.CreateAlbum(album, Server);
                return Redirect("Admin/Album/List");
            }
            return View( album );
        }

        public ActionResult GetTrackFormRow()
        {
            return PartialView( "EditorTemplates/Track", new Track() { Song = new Song() { Name = "Couille" } } );
        }
    }
}