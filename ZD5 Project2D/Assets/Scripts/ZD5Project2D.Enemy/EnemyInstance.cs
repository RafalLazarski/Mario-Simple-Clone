using UnityEngine;

namespace ZD5Project2D.Enemy {
	public class EnemyInstance : MonoBehaviour
	{
		[SerializeField]
		private Transform enemy;

		[SerializeField]
		private Transform startWayPoint;

		[SerializeField]
		private Transform endWayPoint;

		public void UpdatePosition()
		{
			Debug.Log("Update enemy pos");
		}

	}
}
