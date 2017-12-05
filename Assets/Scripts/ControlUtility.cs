using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ControlUtility
{
	public const float MAP_LEFT = -5f; // set the bounds of the map
	public const float MAP_RIGHT = 66.5f;
	public const float MAP_BOTTOM = -5f;
	public const float MAP_TOP = 30.5f;

	const float ANGLE_SCALE = -1f; // carefully set constants
	public const float VELOCITY_SCALE = 25f;

	public static float GetAngle(){
		return ANGLE_SCALE * Input.mousePosition.y * 90f / Screen.height; // get the scaled vertical mouse
	}

	public static float GetVelocity(){
		return VELOCITY_SCALE * Input.mousePosition.x / Screen.width; // scale the mouse input
	}

	public static float GetVelocityFraction(){
		return Input.mousePosition.x / Screen.width; // normalize the mouse
	}

	public static bool insidePlayArea(Vector3 position){
		if ( // check if over sides (or above top in 0grav)
				position.x >= MAP_LEFT
		 	  	&& position.x <= MAP_RIGHT
		   		&& position.y >= MAP_BOTTOM
				&& (position.y <= MAP_TOP || Physics.gravity.sqrMagnitude >= 0.1f)
		){
			return true;
		}
		return false;
	}
}


