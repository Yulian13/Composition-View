using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Composition_View.SQL_Class
{
    public class Composition
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Name { get; set; }

        public int NumberPhotos { get; set; }

        public int? IdFirstPhoto { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        public Composition() => Photos = new List<Photo>();

    }
}
