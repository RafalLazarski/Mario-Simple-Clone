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

		[SerializeField]
		private SpriteRenderer enemyRenderer;

		private bool isMovingFromStartToEnd = true;
		private float startTime;
		private float currentTime;
		private float duration = 5;

        public void Init()
        {
			startTime = Time.time;
			currentTime = 0;
        }

        public void UpdatePosition()
		{
			currentTime = (Time.time - startTime) / duration;

			if(isMovingFromStartToEnd)
			{
				enemy.position = Vector3.Lerp(startWayPoint.position, endWayPoint.position, currentTime);
			}
			else
			{
                enemy.position = Vector3.Lerp(endWayPoint.position, startWayPoint.position, currentTime);
            }

			if(currentTime >= 1f)
			{
				enemyRenderer.flipX = !enemyRenderer.flipX;
				isMovingFromStartToEnd = !isMovingFromStartToEnd;
				Init();
			}
		}

	}
}
