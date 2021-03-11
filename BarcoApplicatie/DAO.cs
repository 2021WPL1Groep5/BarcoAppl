using BarcoApplicatie.BibModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace BarcoApplicatie
{

    //===========  Koen =============
    class DAO
    {

        private static readonly DAO instance = new DAO();

        public static DAO Instance()
        {
            return instance;
        }

        private DAO()
        {
            this.context = new BarcoDBContext();
        }

        private BarcoDBContext context;

        public List<RqBarcoDivision> getAllDivisions()
        {
            return context.RqBarcoDivision.ToList();
        }

        public List<RqJobNature> getAllJobNatures()
        {
            return context.RqJobNature.ToList();
        }

        public void saveChanges()
        {
            context.SaveChanges();
        }

        public void Request(string initials, string divisions, string jobNature, string projectName, 
            string partNumber, DateTime? date, string grossWeight, string netWeight, CheckBox checkbox)
        {
            RqRequest request = new RqRequest();
            request.JrNumber = "0002";
            request.Requester = initials;
            request.BarcoDivision = divisions;
            request.JobNature = jobNature;
            request.EutProjectname = projectName;
            request.EutPartnumbers = partNumber;
            request.ExpectedEnddate = date;
            request.InternRequest = false;
            request.GrossWeight = Convert.ToInt16(grossWeight);
            request.NetWeight = Convert.ToInt16(netWeight);

            if (checkbox.IsChecked == true)
            {
                request.Battery = true;
            }

            context.RqRequest.Add(request);
            context.SaveChanges();

        }

        public void addingOptionalInput(string link, string remarks)
        {
            RqOptionel optional = new RqOptionel();
            optional.Link = link;
            optional.Remarks = remarks;

            context.RqOptionel.Add(optional);
            context.SaveChanges();
        }
    }
}
