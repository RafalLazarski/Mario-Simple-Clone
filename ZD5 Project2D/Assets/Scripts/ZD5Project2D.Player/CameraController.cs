using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private Rigidbody2D rigidbody2D;

	[SerializeField]
	private Vector2 cameraBoundaries;

	public void UpdateMovement(Vector2 speed, float yPos)
	{
		yPos = Mathf.Clamp(yPos, cameraBoundaries.x, cameraBoundaries.y);
		transform.position = new Vector2(rigidbody2D.position.x, yPos);
		rigidbody2D.velocity = speed;
	}

	//public void StopMovement()
	//{
	//	rigidbody2D.velocity = Vector2.zero;
	//}
}
