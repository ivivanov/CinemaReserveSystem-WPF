using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaReserve.ResponseModels;
using WpfExam.Data;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfExam.Behavior;
using System.Windows.Forms;

namespace WpfExam.ViewModels
{
    public class ReserveViewModel : BaseViewModel, IPageViewModel
    {
        private ProjectionDetailsModel projection;
        private IEnumerable<SeatModel> seats;
        private SeatModel selectedSeat;
        private SeatModel selectedSeatFromReservationList;
        private ObservableCollection<SeatModel> seatsForReservation;
        private ICommand addCommand;
        private ICommand removeCommand;
        private ICommand confirmReservationCommand;
        private string mail;
        private string message;
        private string reservationCode;

        public string ReservationCode
        {
            get { return reservationCode; }
            set { reservationCode = value; }
        }


        public string Message
        {
            get
            {
                return this.message;
            }
            set
            {
                if (this.message != value)
                {
                    this.message = value;
                    this.OnPropertyChanged("Message");
                }
            }
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }


        public ICommand ConfirmReservationCommand
        {
            get
            {
                if (this.confirmReservationCommand == null)
                {
                    this.confirmReservationCommand = new RelayCommand(this.ExecuteConfirmReservationCommand);
                }
                return confirmReservationCommand;
            }
        }

        private void ExecuteConfirmReservationCommand(object parameter)
        {
            if (this.SeatsForReservation.Count == 0)
            {
                this.Message = "No selected seats! Please add seats by selecting them in the left view and than click Add button";
            }
            else
            {
                if (String.IsNullOrEmpty(this.Mail))
                {
                    this.Message = "Please Provide valid Mail!";
                }
                else
                {
                    try
                    {
                        CreateReservationModel newReservation = new CreateReservationModel();
                        newReservation.Seats = this.SeatsForReservation;
                        newReservation.Email = this.Mail;
                        var response = DataPersister.CreateReservation(newReservation, this.ProjectionId);
                        this.Message = "This is your reservation code: " + response.UserCode;
                    }
                    catch (Exception ex)
                    {
                        this.Message = "Server error: " + ex.Message;
                    }
                   
                }
            }
        }


        public ICommand RemoveCommand
        {
            get
            {
                if (this.removeCommand == null)
                {
                    this.removeCommand = new RelayCommand(this.ExecuteRemoveCommand);
                }
                return removeCommand;
            }
        }

        private void ExecuteRemoveCommand(object parameter)
        {
            if (this.SelectedSeatFromReservationList != null)
            {
                this.SeatsForReservation.Remove(this.SelectedSeatFromReservationList);
            }
        }

        public ICommand AddCommand
        {
            get
            {
                if (this.addCommand == null)
                {
                    this.addCommand = new RelayCommand(this.ExecuteAddComand);
                }
                return addCommand;
            }
        }

        private void ExecuteAddComand(object parameter)
        {
            if (this.SelectedSeat != null)
            {
                if (this.SelectedSeat.Status == "free")
                {
                    this.SeatsForReservation.Add(this.SelectedSeat);
                }
            }
        }

        public ObservableCollection<SeatModel> SeatsForReservation
        {
            get { return seatsForReservation; }
            set { seatsForReservation = value; }
        }


        public SeatModel SelectedSeat
        {
            get { return selectedSeat; }
            set
            {
                selectedSeat = value;
                if (value != null)
                {
                    this.selectedSeat.Column = value.Column;
                    this.selectedSeat.Row = value.Row;
                    this.selectedSeat.Status = value.Status;
                }
            }
        }

        public SeatModel SelectedSeatFromReservationList
        {
            get { return selectedSeatFromReservationList; }
            set
            {
                selectedSeatFromReservationList = value;
                if (value != null)
                {
                    this.selectedSeatFromReservationList.Column = value.Column;
                    this.selectedSeatFromReservationList.Row = value.Row;
                    this.selectedSeatFromReservationList.Status = value.Status;
                }
            }
        }


        public ReserveViewModel(int id)
        {
            this.ProjectionId = id;
            this.Projection = DataPersister.getProjectionById(this.ProjectionId);
            this.Seats = this.Projection.Seats;
            this.seatsForReservation = new ObservableCollection<SeatModel>();
        }


        public IEnumerable<SeatModel> Seats
        {
            get { return seats; }
            set { seats = value; }
        }

        public int HoleRows
        {
            get
            {
                int rows = this.Projection.Seats.Select(x => x.Row).Count();
                return rows;
            }
        }

        public int HoleColumns
        {
            get
            {
                int cols = this.Projection.Seats.Select(x => x.Column).Count();
                return cols;
            }
        }

        public ProjectionDetailsModel Projection
        {
            get { return projection; }
            set
            {
                projection = value;
                if (value != null)
                {
                    this.projection.Id = value.Id;
                    this.projection.Movie = value.Movie;
                    this.projection.Seats = value.Seats;
                    this.projection.Time = value.Time;
                }
                this.OnPropertyChanged("Projection");
            }
        }

        public int ProjectionId { get; set; }



        public string Name
        {
            get { return "Reserve VM"; }
        }
    }
}
