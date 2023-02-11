using UnityEngine;

namespace ZD5Project2D.Core
{
    public class MenuState : BaseState
    {
        public override void InitState(GameController gameController)
        {
            base.InitState(gameController);
            gameController.MenuView.ShowView();
        }

        public override void UpdateState()
        {
            Debug.Log("Menu update");
        }

        public override void FixedUpdateState()
        {

        }

        public override void DestroyState()
        {
            gameController.MenuView.HideView();
        }
    }
}