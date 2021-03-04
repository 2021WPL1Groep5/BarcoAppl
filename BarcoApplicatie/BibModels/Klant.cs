using System;
using System.Collections.Generic;

namespace BarcoApplicatie.BibModels
{
    public partial class Klant
    {
        public Klant()
        {
            Uitleen = new HashSet<Uitleen>();
        }

        public int KlantId { get; set; }
        public string Klantnaam { get; set; }
        public string Plaats { get; set; }

        public virtual ICollection<Uitleen> Uitleen { get; set; }
    }
}
