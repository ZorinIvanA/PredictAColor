using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PredictAColor.MVVM
{
    public class GameViewModel : ViewModelBase
    {
        private Timer _gameTimer;

        private TimeSpan _timePassed;
        /// <summary>
        /// Время, прошедшее с начала игры
        /// </summary>
        public String TimePassed
        {
            get { return _timePassed.ToString(); }
            private set
            {
                _timePassed = TimeSpan.Parse(value);
                RaisePropertyChanged("TimePassed");
            }
        }

        public GameViewModel() : base()
        {

        }

        public GameViewModel(params object[] args) : base(args)
        {
            _gameTimer = new Timer((state) =>
            {
                var newTime = _timePassed.Add(new TimeSpan(0, 0, 1));
                TimePassed = newTime.ToString();
            }, null, 0, 1000);
        }
    }
}
