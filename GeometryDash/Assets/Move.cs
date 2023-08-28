using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Speeds { Slow, Normal, Fast, Faster, Fastest}
public class Move : MonoBehaviour
{
	public Speeds CurrentSpeed;
	private float[] speedValues = { 8.6f, 10.4f, 12.96f, 15.6f, 19.27f };
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
		//Movement = Input.GetAxis("Horizontal");
		//rb.velocity = new Vector2(speed * Movement, rb.velocity.y);
		transform.position += Vector3.right * speedValues[(int)CurrentSpeed] * Time.deltaTime;

		//Handle Jumping - Jump = Spacebar in Unity
		//Ground Check to prevent jumping in air
		if(Input.GetButton("Jump") && isContactingGround)
		{
			rb.velocity = Vector2.zero;
			rb.AddForce(Vector2.up * 26.6581f, ForceMode2D.Impulse);
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
