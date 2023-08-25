using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	public float speed;
	private float Movement;

	public float jump;
	public bool isContactingGround;

	private Rigidbody2D rb;
	// Start is called before the first frame update
	void Start()
	{
				rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		Movement = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(speed * Movement, rb.velocity.y);

		//Handle Jumping - Jump = Spacebar in Unity
		//Ground Check to prevent jumping in air
		if(Input.GetButton("Jump") && isContactingGround)
		{
			rb.AddForce(new Vector2(rb.velocity.x, jump));
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//If object collides with object tagged as ground
		if (collision.gameObject.CompareTag("Ground"))
		{
			isContactingGround = true;
		}
	}

	//If exiting ground
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			isContactingGround = false;
		}
	}
}
