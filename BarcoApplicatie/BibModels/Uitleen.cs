using System;
using System.Collections.Generic;

namespace BarcoApplicatie.BibModels
{
    public partial class Uitleen
    {
        public int Uitlnr { get; set; }
        public int? BoekId { get; set; }
        public DateTime? Datum { get; set; }
        public int? KlantId { get; set; }

        public virtual Boeken Boek { get; set; }
        public virtual Klant Klant { get; set; }
    }
}
