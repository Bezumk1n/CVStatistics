using CVStatistics.Domain.Interfaces;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        #region Events
        /// <summary>
        /// Событие изменения текущей вью-модели
        /// </summary>
        public event Action CurrentViewModelChanged;
        #endregion
        #region Properties
        private readonly Func<Type, IViewModel> _viewModelFactory;
        /// <summary>
        /// Текущая вью-модель
        /// </summary>
        public IViewModel CurrentViewModel
        {
            get => _CurrentViewModel;
            private set
            {
                _CurrentViewModel = value;
                CurrentViewModelChanged?.Invoke();
            }
        }
        private IViewModel _CurrentViewModel;
        #endregion
        #region Constructor
        public NavigationService(Func<Type, IViewModel> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Навигация через фабрику DI
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        public void Navigate<IViewModel>()
        {
            try
            {
                CurrentViewModel = _viewModelFactory.Invoke(typeof(IViewModel));
            }
            catch (InvalidOperationException notFound)
            {
                //TODO Оповестить пользователя о том что отсутствует необходимая вью-модель
                //Возможно ее не зарегистрировали в файле AddViewModelsHostBuilderExtension
            }
        }
        #endregion
    }
}
