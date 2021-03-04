using System;
using System.Collections.Generic;

namespace BarcoApplicatie.BibModels
{
    public partial class RqRequestDetailv1
    {
        public long Id { get; set; }
        public string JrNumber { get; set; }
        public string TestDevision { get; set; }
        public DateTime? EutforeSeenDate { get; set; }
        public string Pvgresp { get; set; }
    }
}
