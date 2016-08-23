using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PredictAColor.MVVM
{
    /// <summary>
    /// Базовый класс для всех моделей страниц
    /// </summary>
    public abstract class PageViewModelBase : ViewModelBase
    {
        /// <summary>
        /// Команда закрытия окна
        /// </summary>
        public CommandViewModel CloseWindowCommand { get; set; }

        /// <summary>
        /// Конструктор - создаёт базовую страницу
        /// </summary>
        public PageViewModelBase() : base()
        {
            CloseWindowCommand = new CommandViewModel(OnCloseWindowAsync);
        }

        /// <summary>
        /// Асинхронное закрытие окна
        /// </summary>
        /// <param name="p">Параметр закрытия окна</param>
        /// <returns>Задача закрытия окна</returns>
        protected abstract Task OnCloseWindowAsync(Object p);
    }
}
