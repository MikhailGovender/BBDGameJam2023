using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	private Vector3 cameraOffset = new Vector3(0f, 0f, -10f);
	private float smoothTime = 0.20f;
	private Vector3 velocity = Vector3.zero;

	[SerializeField] private Transform target;

	private void FixedUpdate()
	{
        Vector3 targetPosition = target.position + cameraOffset;
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}

}
