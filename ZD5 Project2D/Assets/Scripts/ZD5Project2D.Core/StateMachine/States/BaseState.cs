using UnityEngine;

namespace ZD5Project2D.Core
{
    public abstract class BaseState
    {
        protected GameController gameController;

        public virtual void InitState(GameController gameController)
        {
            this.gameController = gameController;
        }
        public abstract void UpdateState();
        public abstract void FixedUpdateState();
        public abstract void DestroyState();

    }
}


