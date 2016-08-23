using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PredictAColor.Commands
{
    /// <summary>
    /// Интерфейс асинхронной команды
    /// </summary>
    public interface IAsyncCommand: ICommand
    {
        /// <summary>
        /// Асинхронный запуск асинхронной команды
        /// </summary>
        /// <param name="parameter">Параметр асинхронной команды</param>
        /// <returns>Задача</returns>
        Task ExecuteAsync(Object parameter);
    }
}
