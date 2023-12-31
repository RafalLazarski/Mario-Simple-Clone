using UnityEngine;

namespace ZD5Project2D.Core
{
    public class LoseState : BaseState
    {
        public override void InitState(GameController gameController)
        {
            base.InitState(gameController);
            gameController.LoseView.ShowView();
        }

        public override void UpdateState()
        {

        }

        public override void FixedUpdateState()
        {

        }

        public override void DestroyState()
        {
            gameController.LoseView.HideView();
        }
    }
}
