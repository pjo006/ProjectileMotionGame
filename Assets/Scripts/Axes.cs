using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Axes : MonoBehaviour {
	const float WIDTH = 0.1f;


	// Use this for initialization
	void Start() {
		DrawLine (Vector3.zero, ControlUtility.MAP_TOP * Vector3.up);
		DrawLine (Vector3.zero, ControlUtility.MAP_RIGHT * Vector3.right);
	}

	void DrawLine(Vector3 start, Vector3 end) {
		LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.SetPositions (new Vector3[] { start, end });
		lineRenderer.material = new Material (Shader.Find ("Particles/Additive"));
		lineRenderer.startColor = Color.white;
		lineRenderer.endColor = Color.white;
		lineRenderer.startWidth = WIDTH;
		lineRenderer.endWidth = WIDTH;
	}

}
