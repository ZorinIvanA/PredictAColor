using PredictAColor.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PredictAColor.MVVM
{
    /// <summary>
    /// Модель представления команды (для использования в моделях представления и биндинга)
    /// </summary>
    public class CommandViewModel : ViewModelBase
    {
        //Комментарий
        private ICommand _command;
        /// <summary>
        /// Сама команда
        /// </summary>
        public ICommand Command
        {
            get { return _command; }
            set
            {
                _command = value;
                DoNotifyPropertyChanged("Command");
            }
        }

        /// <summary>
        /// Команда может быть запущена
        /// </summary>
        public bool CanBeExecuted
        {
            get
            {
                return Command.CanExecute(null);
            }
        }

        /// <summary>
        /// Команда винда
        /// </summary>
        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }

            set
            {
                _isVisible = value;
                DoNotifyPropertyChanged("IsVisible");
            }
        }
        private Boolean _isVisible = true;

        /// <summary>
        /// Команда доступна для использования
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }

            set
            {
                _isEnabled = value;
                DoNotifyPropertyChanged("IsEnabled");
            }
        }
        private Boolean _isEnabled = true;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="action">Обработчик команды</param>
        public CommandViewModel(Func<Object, Task> action)
        {
            _command = new AsyncCommand(action);
            Command.CanExecuteChanged += (sender, e) =>
            {
                DoNotifyPropertyChanged("CanBeExecuted");
            };
        }
    }
}
