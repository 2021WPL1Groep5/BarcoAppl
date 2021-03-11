using System;
using System.Collections.Generic;

namespace BarcoApplicatie.NewBibModels
{
    public partial class RqRequestDetail
    {
        public int IdRqDetail { get; set; }
        public string Testdivisie { get; set; }
        public string Pvgresp { get; set; }
        public int IdRequest { get; set; }

        public virtual RqRequest IdRequestNavigation { get; set; }
        public virtual RqTestDevision TestdivisieNavigation { get; set; }
    }
}
