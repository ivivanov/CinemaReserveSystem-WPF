using CinemaReserve.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfExam.ViewModels
{
    public class AllMoviesViewModel : BaseViewModel, IPageViewModel
    {
        private IEnumerable<MovieModel> movieList;
        private MovieModel selectedMovie;
        private MovieDetailsModel movieDetails;

        public MovieDetailsModel MovieDetails
        {
            get { return movieDetails; }
            set
            {
                movieDetails = value;
                if (value != null)
                {
                    this.movieDetails.Id = value.Id;
                    this.movieDetails.Projections = value.Projections;
                    this.movieDetails.Title = value.Title;
                    this.movieDetails.Description = value.Description;
                    this.movieDetails.Actors = value.Actors;

                }
                this.OnPropertyChanged("MovieDetails");
            }
        }


        public IEnumerable<MovieModel> MoviesList
        {
            get
            {
                if (this.movieList == null)
                {
                    this.movieList = Data.DataPersister.GetAllMovies();
                }
                return this.movieList;
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
                    this.MovieDetails = Data.DataPersister.GetMovieDetails(this.selectedMovie.Id);
                    this.OnPropertyChanged("SelectedMovie");
                }
            }
        }


        public string Name
        {
            get { return "All Movies VM"; }
        }
    }
}
