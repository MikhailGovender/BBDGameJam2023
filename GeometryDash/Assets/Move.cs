using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Speeds { Slow, Normal, Fast, Faster, Fastest}
public class Move : MonoBehaviour
{
	public Speeds CurrentSpeed;
	private float[] speedValues = { 8.6f, 10.4f, 12.96f, 15.6f, 19.27f };

	public float jump;
	public bool isContactingGround;
	private bool gotPowerUp;

	private Rigidbody2D rb;
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if(gotPowerUp)
		{
			MovePlayerBackward();
			Invoke("ResetMovement", 0.5f);
		}
		else
		{
			MovePlayerForward();
		}

		//Handle Jumping - Jump = Spacebar in Unity
		//Ground Check to prevent jumping in air
		if(Input.GetButton("Jump") && isContactingGround)
		{
			rb.velocity = Vector2.zero;
			rb.AddForce(Vector2.up * 26.6581f, ForceMode2D.Impulse);
		}
	}

	private void MovePlayerForward()
	{
		transform.position += Vector3.right * speedValues[(int)CurrentSpeed] * Time.deltaTime;
	}	
	private void MovePlayerBackward()
	{
		transform.position -= Vector3.right * speedValues[(int)CurrentSpeed] * Time.deltaTime;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//If object collides with object tagged as ground
		if (collision.gameObject.CompareTag("Ground"))
		{
			isContactingGround = true;
		}		
		if (collision.gameObject.CompareTag("PowerUp"))
		{
			gotPowerUp = true;
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

	private void ResetMovement()
	{
		gotPowerUp = false;
	}
}
