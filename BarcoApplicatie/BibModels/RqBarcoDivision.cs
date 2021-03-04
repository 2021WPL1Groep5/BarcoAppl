using System;
using System.Collections.Generic;

namespace BarcoApplicatie.BibModels
{
    public partial class RqBarcoDivision
    {
        public RqBarcoDivision()
        {
            RqBarcoDivisionPerson = new HashSet<RqBarcoDivisionPerson>();
        }

        public string Afkorting { get; set; }
        public string Alias { get; set; }
        public bool? Actief { get; set; }

        public virtual ICollection<RqBarcoDivisionPerson> RqBarcoDivisionPerson { get; set; }
    }
}
