using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOrbScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float floatHeight = 1.0f;
    public float floatSpeed = 1.0f;

    private Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		// Calculate the new Y position based on a sine wave.
		float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
		// Update the object's position with the new Y coordinate.
		transform.position = new Vector3(transform.position.x, newY, transform.position.z);
	}
}
