using UnityEngine;
using ZD5Project2D.UI;
using ZD5Project2D.Player;

namespace ZD5Project2D.Core
{
	public class GameController : MonoBehaviour
	{
		private BaseState currentState;

        [SerializeField]
        private MenuView menuView;
        public MenuView MenuView => menuView; // {get { return menuView }}

        [SerializeField]
        private PlayerMovement playerMovement;
        public PlayerMovement PlayerMovement => playerMovement;

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
            // ChangeState(null);
            // some method to save game before shut down
        }

        public void ChangeState(BaseState newState)
        {
            currentState?.DestroyState();
            currentState = newState;
            currentState?.InitState(this);
        }
    }
}