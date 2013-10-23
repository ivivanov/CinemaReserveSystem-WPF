using CinemaReserve.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfExam.Behavior;

namespace WpfExam.ViewModels
{
    public class SearchViewModel : BaseViewModel, IPageViewModel
    {
        private string searchPhrase;
        private ICommand searchCommand;
        private IEnumerable<MovieModel> movieList;

        public IEnumerable<MovieModel> MoviesList
        {
            get
            {
                return this.movieList;
            }
            set
            {
                this.movieList = value;
                this.OnPropertyChanged("MoviesList");
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                if (this.searchCommand == null)
                {
                    this.searchCommand = new RelayCommand(this.ExecuteSearchCommand);
                }
                return searchCommand;
            }
        }

        private void ExecuteSearchCommand(object parameter)
        {
            this.MoviesList = Data.DataPersister.GetMoviesByKeyword(this.SearchPhrase.ToLower());
        }


        public string SearchPhrase
        {
            get { return searchPhrase; }
            set
            {
                searchPhrase = value;
            }
        }


        public string Name
        {
            get { return "Search VM"; }
        }
    }
}
