using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PredictAColor.MVVM
{
    /// <summary>
    /// Базовый класс для команд
    /// </summary>
    public abstract class CommandBase : ICommand
    {
        /// <summary>
        /// Событие, которое происходит, когда сработал метод CanExecute
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Действие, которое выполняет команда
        /// </summary>
        protected Action<Object> _actionToExecute;

        /// <summary>
        /// Конструктор, в который передаётся действие
        /// </summary>
        /// <param name="actionToExecute">Действие, которое должна выполнять команда</param>
        public CommandBase(Action<Object> actionToExecute)
        {
            _actionToExecute = actionToExecute;
        }

        private Boolean _canExecute;
        /// <summary>
        /// Метод, который определяет возможность выполнения команды
        /// </summary>
        /// <param name="parameter">Некий параметр</param>
        /// <returns>Может ли быть выполнена команда</returns>
        public virtual bool CanExecute(Object parameter)
        {
            if (_canExecute != (_actionToExecute != null))
            {
                var cec = CanExecuteChanged;
                if (cec != null)
                    cec(this, EventArgs.Empty);

                _canExecute = _actionToExecute != null;
            }
            return _actionToExecute != null;
        }

        /// <summary>
        /// Непосредственно выполнение команды
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _actionToExecute(parameter);
        }
    }
}
