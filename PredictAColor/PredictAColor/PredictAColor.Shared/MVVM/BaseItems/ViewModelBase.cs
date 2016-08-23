using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PredictAColor.MVVM
{
    /// <summary>
    /// Базовый класс для всех моделей представления - реализует INotifyPropertyChanged
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие изменения отслеживаемого свойства
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Запуск события изменения отслеживаемого свойства
        /// </summary>
        /// <param name="propertyName">Имя изменяемого свойства</param>
        protected void DoNotifyPropertyChanged(String propertyName)
        {
            var x = PropertyChanged;
            if (x != null)
            {
                x(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
