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

        public ActionResult Album( int id )
        {
            var a = GetAlbumViewModel( id );

            return View( a );
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