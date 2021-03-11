using BarcoApplicatie.NewBibModels;
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
            this.context = new BarcoContext();
        }

        private BarcoContext context;

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
            request.GrossWeight = grossWeight;
            request.NetWeight = netWeight;

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

        public void addEUT(DateTime? dateEUT1, DateTime? dateEUT2, DateTime? dateEUT3, DateTime? dateEUT4,
            DateTime? dateEUT5, DateTime? dateEUT6, CheckBox checkBoxEUT1, CheckBox checkBoxEUT2,
            CheckBox checkBoxEUT3, CheckBox checkBoxEUT4, CheckBox checkBoxEUT5, CheckBox checkBoxEUT6)
        {
            Eut eut = new Eut();

            if (checkBoxEUT1.IsChecked == true)
            {
                eut.AvailableDateEut1 = dateEUT1;
            }
            if (checkBoxEUT2.IsChecked == true)
            {
                eut.AvailableDateEut2 = dateEUT2;
            }
            if (checkBoxEUT3.IsChecked == true)
            {
                eut.AvailableDateEut3 = dateEUT3;
            }
            if (checkBoxEUT4.IsChecked == true)
            {
                eut.AvailableDateEut4 = dateEUT4;
            }
            if (checkBoxEUT5.IsChecked == true)
            {
                eut.AvailableDateEut5 = dateEUT5;
            }
            if (checkBoxEUT6.IsChecked == true)
            {
                eut.AvailableDateEut6 = dateEUT6;
            }

            context.Eut.Add(eut);
            context.SaveChanges();
        }

        public void addTestDivision(string testDivision)
        {
            RqRequestDetail requestDetail = new RqRequestDetail();
            requestDetail.Testdivisie = testDivision;

            context.RqRequestDetail.Add(requestDetail);
            context.SaveChanges();
        }
    }
}
