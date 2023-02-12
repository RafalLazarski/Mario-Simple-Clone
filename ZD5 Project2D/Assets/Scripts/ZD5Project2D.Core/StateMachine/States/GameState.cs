using UnityEngine;

namespace ZD5Project2D.Core
{
    public class GameState : BaseState
    {
        public override void InitState(GameController gameController)
        {
            base.InitState(gameController);
            gameController.PlayerMovement.Init();
        }

        public override void UpdateState()
        {
            gameController.PlayerMovement.UpdatePosition();
        }

        public override void FixedUpdateState()
        {
            gameController.PlayerMovement.FixedUpdatePosition();
        }

        public override void DestroyState()
        {
            gameController.PlayerMovement.Dispose();
        }

    }
}
