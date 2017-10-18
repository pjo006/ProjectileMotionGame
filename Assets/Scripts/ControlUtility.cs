using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ControlUtility
{
	const float MAP_LEFT = -5f;
	const float MAP_RIGHT = 66.5f;
	const float MAP_BOTTOM = -5f;
	const float MAP_TOP = 30.5f;

	const float ANGLE_SCALE = -0.2f;
	public const float VELOCITY_SCALE = 0.02f;

	public static float GetAngle(){
		return ANGLE_SCALE * Input.mousePosition.y;
	}

	public static float GetVelocity(){
		return VELOCITY_SCALE * Input.mousePosition.x;
	}

	public static bool insidePlayArea(Vector3 position){
		if (position.x >= MAP_LEFT
		   && position.x <= MAP_RIGHT
		   && position.y >= MAP_BOTTOM
		   && position.y <= MAP_TOP) {
			return true;
		}
		return false;
	}
}


