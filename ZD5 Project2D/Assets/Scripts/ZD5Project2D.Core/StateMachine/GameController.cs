using UnityEngine;
using ZD5Project2D.UI;
using ZD5Project2D.Player;
using ZD5Project2D.Enemy;

namespace ZD5Project2D.Core
{
	public class GameController : MonoBehaviour
	{
		private BaseState currentState;

        [SerializeField]
        private MenuView menuView;
        public MenuView MenuView => menuView; // {get { return menuView }}

        [SerializeField]
        private GameView gameView;
        public GameView GameView => gameView;

        [SerializeField]
        private PointsSystem pointsSystem;
        public PointsSystem PointsSystem => pointsSystem;

        [SerializeField]
        private PlayerMovement playerMovement;
        public PlayerMovement PlayerMovement => playerMovement;

        [SerializeField]
        private EnemyController enemyController;
        public EnemyController EnemyController => enemyController;

        [SerializeField]
        private LoseView loseView;
        public LoseView LoseView => loseView;

        private void Start()
        {
            ChangeState(new MenuState());
        }

        private void Update()
        {
            currentState?.UpdateState();
        }

        private void FixedUpdate()
        {
            currentState?.FixedUpdateState();
        }

        private void OnDestroy()
        {
        }

        public void ChangeState(BaseState newState)
        {
            currentState?.DestroyState();
            currentState = newState;
            currentState?.InitState(this);
        }
    }
}