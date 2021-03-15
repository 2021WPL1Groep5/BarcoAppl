using BarcoApplicatie.BibModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarcoApplicatie
{
    class JobrequestDataService
    {
        public IEnumerable<RqRequest> GetAll()
        {
            // TODO: Load data from real database using Entity Framework!
            yield return new RqRequest { JrNumber = "0003", Requester = "GN", BarcoDivision = "EP-PROJ-CAV",JobNature = "Qualification (FQR)", EutProjectname = "Test"};
        }
    }
}
