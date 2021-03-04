using System;
using System.Collections.Generic;

namespace BarcoApplicatie.BibModels
{
    public partial class Categorie
    {
        public Categorie()
        {
            Boeken = new HashSet<Boeken>();
        }

        public int CatId { get; set; }
        public string Categorie1 { get; set; }

        public virtual ICollection<Boeken> Boeken { get; set; }
    }
}
