using UnityEngine;

namespace ZD5Project2D.UI
{
	public abstract class BaseView : MonoBehaviour
	{
		public virtual void ShowView()
		{
			this.gameObject.SetActive(true);
		}

        public virtual void HideView()
        {
			this.gameObject.SetActive(false);
        }
    } 
}
