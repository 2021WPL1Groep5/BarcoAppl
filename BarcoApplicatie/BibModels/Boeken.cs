using System;
using System.Collections.Generic;

namespace BarcoApplicatie.BibModels
{
    public partial class Boeken
    {
        public Boeken()
        {
            Uitleen = new HashSet<Uitleen>();
        }

        public int BoekId { get; set; }
        public int? AuteurId { get; set; }
        public short? Jaar { get; set; }
        public string Titel { get; set; }
        public int? CatId { get; set; }
        public int? UitgId { get; set; }

        public virtual Auteur Auteur { get; set; }
        public virtual Categorie Cat { get; set; }
        public virtual Uitgever Uitg { get; set; }
        public virtual ICollection<Uitleen> Uitleen { get; set; }
    }
}
