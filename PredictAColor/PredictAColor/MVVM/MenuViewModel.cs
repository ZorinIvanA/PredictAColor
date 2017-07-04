using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace PredictAColor.MVVM
{
    class MenuViewModel : ViewModelBase
    {
        public UICommand NewGameCommand { get; set; }
        public UICommand ContinueGameCommand { get; set; }
        public UICommand StatisticsCommand { get; set; }
        public UICommand SettingsCommand { get; set; }

        public MenuViewModel()
        {
            NewGameCommand = new UICommand(StartNewGame);
            ContinueGameCommand = new UICommand(ContinueGame);
            StatisticsCommand = new UICommand(Statistics);
            SettingsCommand = new UICommand(Settings);
        }

        public void StartNewGame(Object p)
        {
            (App.Current as PredictAColor.App)?.GlobalNavigations.StartNewGame();
        }

        public void ContinueGame(Object p)
        {
            (App.Current as PredictAColor.App)?.GlobalNavigations.ReturnToGame();
        }

        public void Statistics(Object p)
        {

        }

        public void Settings(Object p)
        {

        }
    }
}
