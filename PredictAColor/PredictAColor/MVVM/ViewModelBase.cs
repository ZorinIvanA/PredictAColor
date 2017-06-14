using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PredictAColor.MVVM
{
    /// <summary>
    /// Базовый класс для всех моделей представления
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие, которое сообщает об изменении свойства
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Вызывает PropertyChanged для одного свойства
        /// </summary>
        /// <param name="propertyName">Свойство, об изменениях в котором надо сообщить</param>
        protected void RaisePropertyChanged(String propertyName)
        {
            var pc = PropertyChanged;
            if (pc != null)
                pc(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Вызывает PropertyChanged для всех свойств
        /// </summary>
        protected void RaiseAllPropertiesChanged()
        {
            foreach (var property in this.GetType().GetProperties())
            {
                RaisePropertyChanged(property.Name);
            }
        }

        public ViewModelBase()
        {

        }

        public ViewModelBase(params object[] args)
        {

        }
    }
}
