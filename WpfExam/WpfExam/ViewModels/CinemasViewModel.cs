using CinemaReserve.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfExam.Behavior;
using WpfExam.Data;
using WpfExam.Helpers;

namespace WpfExam.ViewModels
{
    public class CinemasViewModel : BaseViewModel, IPageViewModel
    {
        private IEnumerable<CinemaModel> cinemasList;
        private IEnumerable<MovieModel> movieList;
        private IEnumerable<ProjectionModel> movieProjections;
        private CinemaModel selectedCinema;
        private MovieModel selectedMovie;
        private ProjectionModel selectedProjection;
        private ICommand redirectToReserveViewCommand;
        public event EventHandler RedirectToReserveViewSuccessEvent;
        private bool isReserveButtonAvailable;

        public bool IsReserveButtonAvailable
        {
            get { return isReserveButtonAvailable; }
            set
            {
                isReserveButtonAvailable = value;
                this.OnPropertyChanged("IsReserveButtonAvailable");
            }
        }

        protected void RaiseRedirectToReserveViewSuccess(int id)
        {
            var redirectToReserveViewSuccessEvent = RedirectToReserveViewSuccessEvent;
            if (redirectToReserveViewSuccessEvent != null)
            {
                this.RedirectToReserveViewSuccessEvent(this, new RedirectToReserveViewSuccessArgs(id));
            }
        }

        public ICommand RedirectToReserveViewCommand
        {
            get
            {
                if (this.redirectToReserveViewCommand == null)
                {
                    this.redirectToReserveViewCommand = new RelayCommand(this.ExecuteRedirectToReserveViewCommand);
                }
                return this.redirectToReserveViewCommand;
            }
        }

        private void ExecuteRedirectToReserveViewCommand(object parameter)
        {
            this.RaiseRedirectToReserveViewSuccess(this.selectedProjection.Id);
        }

        public IEnumerable<ProjectionModel> MovieProjections
        {
            get { return movieProjections; }
            set
            {
                movieProjections = value;
                this.OnPropertyChanged("MovieProjections");
            }
        }

        public MovieModel SelectedMovie
        {
            get { return selectedMovie; }
            set
            {
                selectedMovie = value;
                if (value != null)
                {
                    this.selectedMovie.Id = value.Id;
                    this.selectedMovie.Title = value.Title;
                    this.MovieProjections = DataPersister.GetMovieProjections(this.selectedCinema.Id, this.selectedMovie.Id);
                    this.OnPropertyChanged("SelectedMovie");
                }
            }
        }

        public CinemaModel SelectedCinema
        {
            get { return selectedCinema; }
            set
            {
                selectedCinema = value;

                if (value != null)
                {
                    this.selectedCinema.Id = value.Id;
                    this.selectedCinema.Name = value.Name;
                    this.MoviesList = DataPersister.GetMoviesByCinemaId(this.selectedCinema.Id);
                    this.MovieProjections = null;
                    this.IsReserveButtonAvailable = false;
                    this.OnPropertyChanged("SelectedCinema");
                }
            }
        }

        public ProjectionModel SelectedProjection
        {
            get
            {
                return this.selectedProjection;
            }
            set
            {
                this.selectedProjection = value;

                if (value != null)
                {
                    this.selectedProjection.Cinema = value.Cinema;
                    this.selectedProjection.Id = value.Id;
                    this.selectedProjection.Movie = value.Movie;
                    this.selectedProjection.Time = value.Time;
                    this.IsReserveButtonAvailable = true;
                    this.OnPropertyChanged("SelectedProjection");
                }
            }
        }

        public IEnumerable<CinemaModel> CinemasList
        {
            get
            {
                if (this.cinemasList == null)
                {
                    this.cinemasList = DataPersister.GetCinemas();
                }
                return this.cinemasList;
            }
        }

        public IEnumerable<MovieModel> MoviesList
        {
            get
            {
                return this.movieList;
            }
            set
            {
                if (value != null)
                {
                    this.movieList = value;
                    this.OnPropertyChanged("MoviesList");
                }
            }
        }

        public string Name
        {
            get { return "Cinemas VM"; }
        }
    }
}
