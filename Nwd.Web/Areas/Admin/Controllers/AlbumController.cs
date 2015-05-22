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
        AlbumRepository _repo;

        public AlbumController()
        {
            _repo = new AlbumRepository();
        }

        public ActionResult Index()
        {
            var albums = _repo.GetAllAlbums();

            return View( albums );
        }

        [HttpGet]
        public ActionResult Edit( int id )
        {
            var a = _repo.GetAlbumForEdit( id );
            if( a == null )
            {
                return HttpNotFound();
            }
            else
            {
                return View( a );
            }
        }

        public ActionResult IsAlbumTitleAvailable( string title )
        {
            if( !_repo.AlbumExists( title ) )
                return Json( true, JsonRequestBehavior.AllowGet );

            return Json( false, JsonRequestBehavior.AllowGet );
        }

        [HttpPost]
        public ActionResult Edit( Album model )
        {
            if( ModelState.IsValid )
            {
                _repo.EditAlbum( Server, model );
                return Edit( model.Id );
            }

            return View( model );
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
                _repo.CreateAlbum(album, Server);
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