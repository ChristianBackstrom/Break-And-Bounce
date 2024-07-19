using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OutsideOfCamera
{
	public static bool IsOutside(Vector3 position)
	{
		return (position.x > GenerateColliderAroundCamera.GetRightEdge().x + 1 || position.x < -GenerateColliderAroundCamera.GetRightEdge().x - 1 || position.y > GenerateColliderAroundCamera.GetTopEdge().y + 1 || position.y < -GenerateColliderAroundCamera.GetTopEdge().y - 1);
	}
}
