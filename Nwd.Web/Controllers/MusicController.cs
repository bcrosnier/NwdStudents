using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nwd.FrontOffice;
using Nwd.FrontOffice.Impl;

namespace Nwd.Web.Controllers
{
    public class MusicController : Controller
    {
        IMusicReader _musicReader;

        public MusicController()
        {
            _musicReader = new MusicReader();
        }

        public ActionResult Catalog()
        {
            Nwd.FrontOffice.ViewModels.Catalog c = GetCatalog();

            return View( c );
        }

        public ActionResult Album( int? id )
        {
            AlbumViewModel a = null;
            if( id.HasValue ) a = GetAlbumViewModel( id.Value );

            if( a == null )
            {
                return new HttpNotFoundResult();
            }
            else
            {
                ViewBag.MetaDescription = String.Join( ", ", a.Tracks.Select( t => t.SongName ) );
                ViewBag.Title = a.AlbumName;
                return View( a );
            }
        }

        [HandleError()]
        public ActionResult MiniPlayer( int albumId, int trackId )
        {
            var p = _musicReader.GetMiniPlayerFor( albumId, trackId );
            if( p == null )
            {
                return new HttpNotFoundResult();
            }
            else
            {
                return Json( p );
            }
        }

        private AlbumViewModel GetAlbumViewModel( int albumId )
        {
            return _musicReader.GetAlbum( albumId );
        }

        private FrontOffice.ViewModels.Catalog GetCatalog()
        {
            return _musicReader.GetCatalog();
        }
    }
}