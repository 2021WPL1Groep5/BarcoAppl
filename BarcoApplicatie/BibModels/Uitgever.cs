using System;
using System.Collections.Generic;

namespace BarcoApplicatie.BibModels
{
    public partial class Uitgever
    {
        public Uitgever()
        {
            Boeken = new HashSet<Boeken>();
        }

        public int UitgId { get; set; }
        public string Uitgever1 { get; set; }

        public virtual ICollection<Boeken> Boeken { get; set; }
    }
}
