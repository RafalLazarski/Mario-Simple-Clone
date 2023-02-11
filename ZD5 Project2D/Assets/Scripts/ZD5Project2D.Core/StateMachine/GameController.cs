using UnityEngine;

namespace ZD5Project2D.Core
{
	public class GameController : MonoBehaviour
	{
		private BaseState currentState;

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