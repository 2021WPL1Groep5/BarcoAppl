using BarcoApplicatie.BibModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BarcoApplicatie
{
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<RqRequest> Requests { get; set; }

        private JobrequestDataService jobrequestDataService;

        private RqRequest selectedJobrequest;

        public MainViewModel(JobrequestDataService jobrequestDataService)
        {
            Requests = new ObservableCollection<RqRequest>();
            this.jobrequestDataService = jobrequestDataService;
        }

        public void Load()
        {
            var requests = jobrequestDataService.GetAll();
            Requests.Clear();
            foreach (var request in requests)
            {
                Requests.Add(request);
            }
        }

        /*
        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set { selectedPerson = value; }
        }*/

        public RqRequest SelectedRequest
        {
            get { return SelectedRequest; }
            set
            {
                selectedJobrequest = value;
                OnPropertyChanged();
            }
        }
    }
}
