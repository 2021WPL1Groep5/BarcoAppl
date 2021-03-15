using BarcoApplicatie.BibModels;
using Microsoft.EntityFrameworkCore;
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
            this.context = new Barco2021Context();
        }

        private Barco2021Context context;

        public List<RqBarcoDivision> getAllDivisions()
        {
            return context.RqBarcoDivision.ToList();
        }

        public List<RqJobNature> getAllJobNatures()
        {
            return context.RqJobNature.ToList();
        }

        public List<RqRequest> getAllRequests()
        {
            return context.RqRequest.ToList();
        }
        public void saveChanges()
        {
            context.SaveChanges();
        }

        public RqRequest getRequestWithDate(DateTime? date)
        {
            return context.RqRequest.FirstOrDefault(r => r.ExpectedEnddate == date);
        }

        public void removeJobRequest(DateTime? date)
        {
            context.RqRequest.Remove(getRequestWithDate(date));
            saveChanges();
        }


        public void Request(string initials, string divisions, string jobNature, string projectName, 
            string partNumber, DateTime? date, string grossWeight, string netWeight, CheckBox checkbox,
            DateTime? dateEUT1, CheckBox checkBoxEUT1, 
            DateTime? dateEUT2, CheckBox checkBoxEUT2,
             DateTime? dateEUT3, CheckBox checkBoxEUT3,
              DateTime? dateEUT4, CheckBox checkBoxEUT4,
               DateTime? dateEUT5, CheckBox checkBoxEUT5,
                DateTime? dateEUT6, CheckBox checkBoxEUT6,
            string link, string remarks, string testdivision)
        {
            //omschrijving voor in EUT tabel
            string omschrijving = "";

            //Add request

            RqRequest request = new RqRequest();
            request.JrNumber = "0001";
            request.HydraProjectNr = "0001";
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


            //Add request Detail

            RqRequestDetail requestDetail = new RqRequestDetail();

            requestDetail.IdRequest = request.IdRequest;
            requestDetail.Testdivisie = testdivision;
            context.RqRequestDetail.Add(requestDetail);
            context.SaveChanges();

            //Add EUT

            Eut eut = new Eut();
            if (checkBoxEUT1.IsChecked == true)
            {
                omschrijving += "EUT1, ";
                eut.AvailableDate = dateEUT1;
                eut.OmschrijvingEut = omschrijving;
            }

            if (checkBoxEUT2.IsChecked == true)
            {
                omschrijving += "EUT2, ";
                eut.AvailableDate = dateEUT2;
                eut.OmschrijvingEut = omschrijving;
            }
            if (checkBoxEUT3.IsChecked == true)
            {
                omschrijving += "EUT3, ";
                eut.AvailableDate = dateEUT3;
                eut.OmschrijvingEut = omschrijving;
            }

            if (checkBoxEUT4.IsChecked == true)
            {
                omschrijving += "EUT4, ";
                eut.AvailableDate = dateEUT4;
                eut.OmschrijvingEut = omschrijving;
            }
            if (checkBoxEUT5.IsChecked == true)
            {
                omschrijving += "EUT5, ";
                eut.AvailableDate = dateEUT5;
                eut.OmschrijvingEut = omschrijving;
            }

            if (checkBoxEUT6.IsChecked == true)
            {
                omschrijving += "EUT6, ";
                eut.AvailableDate = dateEUT6;
                eut.OmschrijvingEut = omschrijving;
            }

            eut.IdRqDetail = requestDetail.IdRqDetail;
            context.Eut.Add(eut);
            context.SaveChanges();

            //Add Optional remarks

            RqOptionel optional = new RqOptionel();
            optional.Link = link;
            optional.Remarks = remarks;

            optional.IdRequest = request.IdRequest;
            context.RqOptionel.Add(optional);
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
