using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CVStatistics.Domain.BaseObjects
{
    public class VM : NotifyObject
    {
        #region Common properties
        /// <summary>
        /// Переопределяемы заголовок вью модели
        /// </summary>
        public virtual string Title
        {
            get => _Title;
            set
            {
                _Title = value;
                OnPropertyChanged();
            }
        }
        private string _Title = string.Empty;
        #endregion
    }
}
