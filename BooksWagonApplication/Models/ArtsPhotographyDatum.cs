using System;
using System.Collections.Generic;

namespace BooksWagonApplication.Models
{
    public partial class ArtsPhotographyDatum
    {
        public ArtsPhotographyDatum()
        {
            ArtsPhotographies = new HashSet<ArtsPhotography>();
        }

        public int? BookTypeId { get; set; }
        public string? TypeOfBook { get; set; }
        public string? SubTypeOfBook { get; set; }

        public virtual ICollection<ArtsPhotography> ArtsPhotographies { get; set; }
    }
}
