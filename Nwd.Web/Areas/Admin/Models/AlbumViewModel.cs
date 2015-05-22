using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Nwd.BackOffice.Model;

namespace Nwd.Web.Areas.Admin
{
    public class AlbumViewModel
    {
        public AlbumViewModel()
        {
            Tracks = new HashSet<Track>();
        }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Duration)]
        public System.TimeSpan? Duration { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public System.DateTime? ReleaseDate { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string CoverImageUrl { get; set; }

        [Required]
        public string Artist { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}