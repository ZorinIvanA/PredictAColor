using PredictAColor.MVVM;
using PredictAColor.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace PredictAColor
{
    /// <summary>
    /// Базовая навигация по страницам
    /// </summary>
    public class Navigation
    {
        /// <summary>
        /// Активная игра. Если null - значит активной игры нет.
        /// </summary>
        public GameData ActiveGame { get; set; }

        /// <summary>
        /// Текущий фрейм
        /// </summary>
        public Frame CurrentFrame { get; set; }

        /// <summary>
        /// Переход на указанную страницу с указанной вьюмоделью
        /// </summary>
        /// <typeparam name="TPage">Тип страницы</typeparam>
        /// <typeparam name="TViewModel">Тип вьюмодели</typeparam>
        /// <param name="arguments"></param>
        protected void MoveToPage<TPage, TViewModel>(params object[] arguments)
            where TPage : Page
            where TViewModel : ViewModelBase
        {
            TViewModel vm;
            if (arguments == null || arguments.Count() == 0)
                vm = Activator.CreateInstance(typeof(TViewModel)) as TViewModel;
            else
                vm = Activator.CreateInstance(typeof(TViewModel), arguments) as TViewModel;

            CurrentFrame.Navigate(typeof(TPage), vm);            
        }

        /// <summary>
        /// Возвращает результат показа диалога
        /// </summary>
        /// <typeparam name="TDialog">Тип диалога</typeparam>
        /// <typeparam name="TViewModel">Тип вьюмодели</typeparam>
        /// <param name="arguments"></param>
        /// <returns>Результат диалога</returns>
        protected Object GetDialogResult<TDialog, TViewModel>(params object[] arguments)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Старт новой игры
        /// </summary>
        public void StartNewGame()
        {
            SaveActiveGame();

            MoveToPage<Game, GameViewModel>(ActiveGame);
        }

        private void SaveActiveGame()
        {
            var needFinish = false;
            if (ActiveGame != null)
                needFinish = (Boolean)GetDialogResult<NeedSaveDialog, NeedCloseGameViewModel>(null);

            if (needFinish)
            {
                SaveGame();
                ActiveGame = null;
            }
        }

        /// <summary>
        /// Показать главное меню
        /// </summary>
        /// <param name="currentGameData">Текущие данные игры</param>
        public void ShowMenu(GameData currentGameData)
        {
            if (currentGameData != null)
                ActiveGame = currentGameData;

            MoveToPage<MenuPage, MenuViewModel>();
        }

        /// <summary>
        /// Показать окно статистики
        /// </summary>
        /// <param name="currentGameData">Текущие данные игры</param>
        public void ShowStatistics(GameData currentGameData)
        {
            if (currentGameData != null)
                ActiveGame = currentGameData;

            MoveToPage<Statistics, StatisticsViewModel>();
        }

        /// <summary>
        /// Показать настройки игры
        /// </summary>
        /// <param name="currentGameData">Текущие данные игры</param>
        public void ShowSettings(GameData currentGameData)
        {
            if (currentGameData != null)
                ActiveGame = currentGameData;

            MoveToPage<Settings, SettingsViewModel>();
        }

        public void ReturnToGame()
        {
            MoveToPage<Game, GameViewModel>();
        }

        protected void SaveGame()
        {
            //throw new NotImplementedException();
        }


    }
}
