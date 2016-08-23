using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PredictAColor.Commands
{
    /// <summary>
    /// Реализация для асинхронной команды
    /// </summary>
    public class AsyncCommand : IAsyncCommand
    {
        /// <summary>
        /// Действие команды
        /// </summary>
        Func<Object, Task> _action;

        /// <summary>
        /// Событие изменение возможности запуска команды
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Конструктор. Создаёт экземпляр асинхронной команды
        /// </summary>
        /// <param name="action">Действие команды</param>
        public AsyncCommand(Func<Object, Task> action)
        {
            _action = action;
        }

        /// <summary>
        /// Может ли команда быть запущена
        /// </summary>
        /// <param name="parameter">Параметр команды</param>
        /// <returns>Возможность запуска</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Запуск команды (реализация ICommand)
        /// </summary>
        /// <param name="parameter">Параметр запуска</param>
        public void Execute(object parameter)
        {
            Task t = Task.Factory.StartNew(async () =>
            {
                await ExecuteAsync(parameter);
            });
        }

        /// <summary>
        /// Асинхронный запуск действия команды
        /// </summary>
        /// <param name="parameter">Параметр команды</param>
        /// <returns>Задача команды</returns>
        public async Task ExecuteAsync(object parameter)
        {
            if (_action != null)
            {
                await _action(parameter);
            }
            else
            {
                throw new NullReferenceException("Action is null!");
            }
        }
    }
}
