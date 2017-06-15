using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictAColor
{
    /// <summary>
    /// Данные игры
    /// </summary>
    public class GameData
    {
        /// <summary>
        /// Текущая загаданная карта
        /// </summary>
        public CardColors CurrentCard { get; set; }

        /// <summary>
        /// Текущее время игры
        /// </summary>
        public TimeSpan CurrentGameTime { get; set; }

        /// <summary>
        /// Всего перевёрнуто карт
        /// </summary>
        public int TotalCardsOpened { get; set; }

        /// <summary>
        /// Количество угаданных карт
        /// </summary>
        public int CardsPredicted { get; set; }
    }
}
