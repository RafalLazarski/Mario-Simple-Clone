using UnityEngine;

public class PointsSystem : MonoBehaviour
{
	private int points;
	public int Points => points;

	public void SetPoints(int points)
	{
		this.points = points;
	}

	public void AddPoints()
	{
		points++;
	}
}
