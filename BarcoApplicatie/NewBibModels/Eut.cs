using System;
using System.Collections.Generic;

namespace BarcoApplicatie.NewBibModels
{
    public partial class Eut
    {
        public int Id { get; set; }
        public int IdRqDetail { get; set; }
        public DateTime? AvailableDateEut1 { get; set; }
        public DateTime? AvailableDateEut2 { get; set; }
        public DateTime? AvailableDateEut3 { get; set; }
        public DateTime? AvailableDateEut4 { get; set; }
        public DateTime? AvailableDateEut5 { get; set; }
        public DateTime? AvailableDateEut6 { get; set; }
        public string OmschrijvingEut { get; set; }
    }
}
