using UnityEngine;
using UnityEngine.UI;

namespace ZD5Project2D.Core
{
    public class MenuState : BaseState
    {
        public override void InitState(GameController gameController)
        {
            base.InitState(gameController);
            gameController.MenuView.StartButton.onClick.AddListener(() => gameController.ChangeState(new GameState()));
            gameController.MenuView.ShowView();
        }

        public override void UpdateState()
        {

        }

        public override void FixedUpdateState()
        {

        }

        public override void DestroyState()
        {
            gameController.MenuView.HideView();
            gameController.MenuView.StartButton.onClick.RemoveAllListeners();
        }
    }
}