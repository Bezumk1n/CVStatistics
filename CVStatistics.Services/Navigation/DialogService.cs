using CVStatistics.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.Services.Navigation
{
    /// <summary>
    /// Класс диалогового окна
    /// </summary>
    public class DialogService : IDialogService
    {
        #region Events
        /// <summary>
        /// Событие изменения текущей вью-модели
        /// </summary>
        public event Action DialogViewModelChanged;
        #endregion
        #region Properties
        private readonly Func<Type, IViewModel> _viewModelFactory;
        private bool _confirmationSet;
        private bool _dialogResult;
        /// <summary>
        /// Текущее диалоговое окно
        /// </summary>
        public IViewModel DialogViewModel
        {
            get => _DialogViewModel;
            private set
            {
                _DialogViewModel = value;
                DialogViewModelChanged?.Invoke();
            }
        }
        private IViewModel _DialogViewModel;
        #endregion
        #region States
        /// <summary>
        /// Статус открыто ли диалоговое окно
        /// </summary>
        public bool IsDialogOpen { get; private set; } = false;
        /// <summary>
        /// Статус возможно ли принудительное закрытие диалогового окна
        /// </summary>
        public bool CanCloseDialog { get; private set; } = true;
        public bool IsDialogConfirmationButtonsVisible { get; private set; } = false;
        #endregion
        #region Constructor
        public DialogService(Func<Type, IViewModel> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Открыть диалоговое окно
        /// </summary>
        /// <param name="viewType"></param>
        /// <param name="canCloseDialog"></param>
        public void OpenDialog<IViewModel>(bool canCloseDialog)
        {
            CanCloseDialog = canCloseDialog;
            IsDialogOpen = true;
            DialogViewModel = _viewModelFactory.Invoke(typeof(IViewModel));
        }
        /// <summary>
        /// Открыть диалоговое окно с ожиданием
        /// </summary>
        /// <param name="viewType"></param>
        /// <param name="canCloseDialog"></param>
        /// <returns></returns>
        public async Task<bool> OpenAwaitableDialog<IViewModel>(bool canCloseDialog)
        {
            IsDialogConfirmationButtonsVisible = true;
            _confirmationSet = false;

            OpenDialog<IViewModel>(canCloseDialog);

            while (!_confirmationSet)
            {
                await Task.Delay(50);
            }
            return _dialogResult;
        }
        /// <summary>
        /// Закрыть диалоговое окно
        /// </summary>
        /// <param name="dialogResult"></param>
        public void CloseDialog(bool dialogResult)
        {
            _dialogResult = dialogResult;
            _confirmationSet = true;
            IsDialogOpen = false;
            IsDialogConfirmationButtonsVisible = false;
            DialogViewModel = null;
        }
        public void ConfirmDialog()
        {
            CloseDialog(true);
        }
        #endregion
    }
}
