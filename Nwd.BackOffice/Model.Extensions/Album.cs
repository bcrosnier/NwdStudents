using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Nwd.BackOffice.Model
{
    public partial class Album
    {
        [NotMapped]
        [Required]
        [Display( Name = "choucroute file")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase CoverFile { get; set; }

        [Required]
        [NotMapped]
        public string ArtistName { get; set; }
    }
}
