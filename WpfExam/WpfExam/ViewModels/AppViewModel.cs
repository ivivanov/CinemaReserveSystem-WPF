
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfExam.Behavior;
using WpfExam.Helpers;

namespace WpfExam.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        #region Fields

        private ICommand changeViewModelCommand;
        private ICommand openCinemasViewCommand;
        private IPageViewModel currentViewModel;
        private ICommand openAllMoviesViewCommand;
        private ICommand openSearchViewCommand;

        #endregion

        #region Constructors
        public AppViewModel()
        {
            this.ViewModels = new List<IPageViewModel>();

            CinemasViewModel cinemasVM = new CinemasViewModel();
            cinemasVM.RedirectToReserveViewSuccessEvent += this.SuccessfulRedirectToReserveView;
            this.ViewModels.Add(cinemasVM);

            AllMoviesViewModel allMoviesVM = new AllMoviesViewModel();
            this.ViewModels.Add(allMoviesVM);

            SearchViewModel searchVM = new SearchViewModel();
            this.ViewModels.Add(searchVM);

            this.CurrentViewModel = this.ViewModels[0];
        }

       
        #endregion

        #region Properties

        public IPageViewModel CurrentViewModel
        {
            get
            {
                return this.currentViewModel;
            }
            set
            {
                this.currentViewModel = value;
                this.OnPropertyChanged("CurrentViewModel");
            }
        }

        private IList<IPageViewModel> ViewModels { get; set; }

        #endregion

        #region Commands

        public ICommand OpenSearchViewCommand
        {
            get
            {
                if (this.openSearchViewCommand == null)
                {
                    this.openSearchViewCommand = new RelayCommand(this.ExecuteOpenSearchViewCommand);
                }
                return openSearchViewCommand;
            }
        }

      
        public ICommand ChangeViewModel
        {
            get
            {
                if (this.changeViewModelCommand == null)
                {
                    this.changeViewModelCommand =
                        new RelayCommand(this.ExecuteChangeViewModelCommand);
                }
                return this.changeViewModelCommand;
            }
        }

        public ICommand OpenCinemasViewCommand
        {
            get
            {
                if (this.openCinemasViewCommand == null)
                {
                    this.openCinemasViewCommand = new RelayCommand(this.ExecuteOpenCinemasViewCommand);
                }
                return this.openCinemasViewCommand;
            }
        }

        public ICommand OpenAllMoviesViewCommand
        {
            get
            {
                if (this.openAllMoviesViewCommand == null)
                {
                    this.openAllMoviesViewCommand = new RelayCommand(this.ExecuteOpenAllMoviesViewCommand);
                }
                return openAllMoviesViewCommand;
            }
        }



        #endregion

        #region Functions

        private void ExecuteOpenCinemasViewCommand(object parameter)
        {
            this.CurrentViewModel = this.ViewModels[0];
        }

        private void ExecuteOpenAllMoviesViewCommand(object parameter)
        {
            this.CurrentViewModel = this.ViewModels[1];
        }


        private void ExecuteOpenSearchViewCommand(object parameter)
        {
            this.CurrentViewModel = this.ViewModels[2];
        }

        //public void SuccessfulLoginEventHandler(object sender, EventArgs e)
        //{
        //    LoginSuccessArgs eventArgs = e as LoginSuccessArgs;
        //    this.Username = eventArgs.Username;
        //    this.LoggedInUser = true;
        //    this.ExecuteChangeViewModelCommand(this.ViewModels[2]);
        //}

        //private void ExecuteOpenLoginView(object parameter)
        //{
        //    this.CurrentViewModel = this.ViewModels[0];
        //}

        private void ExecuteChangeViewModelCommand(object parameter)
        {
            var newCurrentViewModel = parameter as IPageViewModel;
            this.CurrentViewModel = newCurrentViewModel;
        }

        private void SuccessfulRedirectToReserveView(object sender, EventArgs e)
        {
            RedirectToReserveViewSuccessArgs args = e as RedirectToReserveViewSuccessArgs;
             int projectionId =args.ProjectionId;
             this.CurrentViewModel = new ReserveViewModel(projectionId);
        }

        #endregion
    }
}
