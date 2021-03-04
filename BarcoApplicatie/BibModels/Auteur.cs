using System;
using System.Collections.Generic;

namespace BarcoApplicatie.BibModels
{
    public partial class Auteur
    {
        public Auteur()
        {
            Boeken = new HashSet<Boeken>();
        }

        public int AuteurId { get; set; }
        public string Naam { get; set; }

        public virtual ICollection<Boeken> Boeken { get; set; }
    }
}
