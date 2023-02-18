using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private Rigidbody2D rigidbody2D;

	public void UpdateMovement(Vector2 speed, float yPos)
	{
		transform.position = new Vector2(rigidbody2D.position.x, yPos);
		rigidbody2D.velocity = speed;
	}

	//public void StopMovement()
	//{
	//	rigidbody2D.velocity = Vector2.zero;
	//}
}
