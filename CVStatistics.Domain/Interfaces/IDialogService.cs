using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.Domain.Interfaces
{
    public interface IDialogService
    {
        /// <summary>
        /// Событие смены текущей вью модели
        /// </summary>
        public event Action DialogViewModelChanged;
        /// <summary>
        /// Текущая вью модель
        /// </summary>
        public IViewModel DialogViewModel { get; }
        /// <summary>
        /// Открыть новое диалоговое окно
        /// </summary>
        /// <param name="viewType"></param>
        /// <param name="canCloseDialog"></param>
        public void OpenDialog<IViewModel>(bool canCloseDialog = true);
        /// <summary>
        /// Открыть новое диалоговое окно с ожиданием
        /// </summary>
        /// <param name="viewType"></param>
        /// <param name="canCloseDialog"></param>
        /// <returns></returns>
        public Task<bool> OpenAwaitableDialog<IViewModel>(bool canCloseDialog = true);
        /// <summary>
        /// Закрыть диалоговое окно
        /// </summary>
        /// <param name="dialogResult"></param>
        public void CloseDialog(bool dialogResult = false);
        public void ConfirmDialog();
        /// <summary>
        /// Статус открыто ли диалоговое окно
        /// </summary>
        public bool IsDialogOpen { get; }
        /// <summary>
        /// Статус возможно ли принудительно закрыть диалоговое окно
        /// </summary>
        public bool CanCloseDialog { get; }
        public bool IsDialogConfirmationButtonsVisible { get; }
    }
}
