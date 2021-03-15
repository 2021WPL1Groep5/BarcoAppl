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

        public RqRequest getRequestWithID(int id)
        {
            return context.RqRequest.FirstOrDefault(r => r.IdRequest == id);
        }

        public void removeJobRequest(int id)
        {
            context.RqRequest.Remove(getRequestWithID(id));
            saveChanges();
        }


        public void Request(string initials, string divisions, string jobNature, string projectName, 
            string partNumber, DateTime? date, string grossWeight, string netWeight, CheckBox checkbox,
            DateTime? dateEUT, CheckBox checkBoxEUT, string link, string remarks)
        {

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
            requestDetail.Testdivisie = "EMC";
            context.RqRequestDetail.Add(requestDetail);
            context.SaveChanges();

            //Add EUT

            Eut eut = new Eut();
            if (checkBoxEUT.IsChecked == true)
            {
                eut.AvailableDate = dateEUT;
                eut.OmschrijvingEut = "EUT1";
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
