using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ControlUtility
{
	const float ANGLE_SCALE = -0.2f;
	public const float VELOCITY_SCALE = 0.02f;

	public static float GetAngle(){
		return ANGLE_SCALE * Input.mousePosition.y;
	}

	public static float GetVelocity(){
		return VELOCITY_SCALE * Input.mousePosition.x;
	}	
}


