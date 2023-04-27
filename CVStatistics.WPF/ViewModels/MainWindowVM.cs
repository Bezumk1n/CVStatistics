using CVStatistics.Domain.Interfaces;
using CVStatistics.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CVStatistics.WPF.ViewModels
{
    public class MainWindowVM : BaseVM
    {
        #region Properties
        public override string Title => "Coronavirus Statistics";
        /// <summary>
        /// Сервис навигации
        /// </summary>
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;

        /// <summary>
        /// Текущия модель представления
        /// </summary>
        public IViewModel CurrentViewModel => _navigationService.CurrentViewModel;
        #endregion
        #region Dialog
        /// <summary>
        /// Контент диалогового окна
        /// </summary>
        public IViewModel DialogContent => _dialogService.DialogViewModel;
        public bool IsDialogConfirmationButtonsVisible => _dialogService.IsDialogConfirmationButtonsVisible;
        #endregion
        #region States
        /// <summary>
        /// Статус - открыт ли диалог
        /// </summary>
        public bool IsDialogOpen => _dialogService.IsDialogOpen;
        /// <summary>
        /// Статус - возможно ли принудительно закрыть диалоговое окно
        /// </summary>
        public bool CanCloseDialog => _dialogService.CanCloseDialog;
        #endregion
        #region Commands
        public ICommand CommandNavigateToMain { get; }
        public ICommand CommandNavigateToDetails { get; }
        public ICommand CommandNavigateToDemo { get; }
        public ICommand CommandNavigateToInfo { get; }
        public ICommand CommandCloseDialog { get; }
        public ICommand CommandConfirmDialog { get; }
        #endregion
        #region Constructor
        public MainWindowVM(INavigationService navigationService, IDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;

            CommandCloseDialog = new DelegateCommand(() => _dialogService.CloseDialog());
            CommandConfirmDialog = new DelegateCommand(() => _dialogService.ConfirmDialog());

            CommandNavigateToMain = new DelegateCommand(() => _navigationService.Navigate<MainStatisticsVM>());
            CommandNavigateToDetails = new DelegateCommand(() => _navigationService.Navigate<DetailedStatisticsVM>());
            CommandNavigateToDemo = new DelegateCommand(() => _navigationService.Navigate<DemoVM>());
            CommandNavigateToInfo = new DelegateCommand(() => _navigationService.Navigate<InfoVM>());

            _navigationService.CurrentViewModelChanged += () => OnPropertyChanged(() => CurrentViewModel);


            _dialogService.DialogViewModelChanged += () =>
            {
                OnPropertyChanged(() => DialogContent);
                OnPropertyChanged(() => IsDialogOpen);
                OnPropertyChanged(() => CanCloseDialog);
                OnPropertyChanged(() => IsDialogConfirmationButtonsVisible);
            };
        }
        #endregion
    }
}
