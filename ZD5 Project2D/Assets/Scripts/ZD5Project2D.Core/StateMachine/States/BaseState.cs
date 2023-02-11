using UnityEngine;

namespace ZD5Project2D.Core;

public abstract class BaseState
{
	public abstract void InitState();
    public abstract void UpdateState();
    public abstract void FixedUpdateState();
    public abstract void DestroyState();

}
