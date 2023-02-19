using TMPro;
using UnityEngine;

namespace ZD5Project2D.UI
{
    public class GameView : BaseView
    {
        [SerializeField]
        private TextMeshProUGUI goldCounter;

        public void UpdatePoints(int currentPoints)
        {
            goldCounter.text = "Gold: " + currentPoints.ToString();
        }
    }
}