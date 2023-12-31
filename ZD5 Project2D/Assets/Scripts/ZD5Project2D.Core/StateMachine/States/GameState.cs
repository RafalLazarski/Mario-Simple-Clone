using UnityEngine;
using ZD5Project2D.UI;

namespace ZD5Project2D.Core
{
    public class GameState : BaseState
    {
        public override void InitState(GameController gameController)
        {
            base.InitState(gameController);

            gameController.PlayerMovement.Init();
            gameController.GameView.ShowView();

            gameController.PointsSystem.SetPoints(0);
            gameController.GameView.UpdatePoints(gameController.PointsSystem.Points);

            gameController.PlayerMovement.AddMoneyListener(AddPoint);

            gameController.PlayerMovement.OnEnemyHit += () => gameController.ChangeState(new LoseState());
        }

        public override void UpdateState()
        {
            gameController.PlayerMovement.UpdatePosition();
            gameController.EnemyController.UpdateEnemiesPos();
        }

        public override void FixedUpdateState()
        {
            gameController.PlayerMovement.FixedUpdatePosition();
        }

        public override void DestroyState()
        {
            gameController.GameView.HideView();
            gameController.PlayerMovement.RemoveListener();
            gameController.PlayerMovement.Dispose();
        }

        private void AddPoint()
        {
            gameController.PointsSystem.AddPoints();
            gameController.GameView.UpdatePoints(gameController.PointsSystem.Points);
        }

    }
}
