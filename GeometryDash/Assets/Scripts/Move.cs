using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Speeds { Slow, Normal, Fast, Faster, Fastest}
public class Move : MonoBehaviour
{
	public Speeds CurrentSpeed;
	private float[] speedValues = { 8.6f, 10.4f, 12.96f, 15.6f, 19.27f };

	public float jump;
	public bool isContactingGround;
	public bool portalTraveled;
	public bool hasRespawned;
	private bool onMobile;

	public GameManagerScript GameManagerScript;

	public ProgressBarController ProgressBarController;

	private Rigidbody2D rb;
	// Start is called before the first frame update
	void Start()
	{
		if(SystemInfo.deviceType == DeviceType.Handheld)
		{
			onMobile = true;
		}
		rb = GetComponent<Rigidbody2D>();

		Time.timeScale = 1f;
	}

	// Update is called once per frame
	void Update()
	{

		if(portalTraveled)
		{
			MovePlayerBackward();
		}
		else
		{
			MovePlayerForward();
		}

		//Handle Jumping - Jump = Spacebar in Unity
		//Ground Check to prevent jumping in air
		if(onMobile)
		{
			Touch touch = Input.GetTouch(0);
			if(touch.phase == TouchPhase.Began)
			{
				Jump();
			}
		}
		else
		{
			if (Input.GetButton("Jump") && isContactingGround)
			{
				Jump();
			}
		}
	}

	private void Jump()
	{
		rb.velocity = Vector2.zero;
		rb.AddForce(Vector2.up * 26.6581f, ForceMode2D.Impulse);
	}

	private void MovePlayerForward()
	{
		transform.position += Vector3.right * speedValues[(int)CurrentSpeed] * Time.deltaTime;
	}	
	private void MovePlayerBackward()
	{
		transform.position -= Vector3.right * speedValues[(int)CurrentSpeed] * Time.deltaTime;
	}	
	private void StopPlayer()
	{
		transform.position = Vector3.zero;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//If object collides with object tagged as ground
		if (collision.gameObject.CompareTag("Ground"))
		{
			isContactingGround = true;
		}
		if (collision.gameObject.CompareTag("Win"))
		{
			GameManagerScript.GameOver();
			Time.timeScale = 0;
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

	private void OnTriggerExit2D(Collider2D collision)
	{
		if(collision.CompareTag("Portal"))
		{
			StartCoroutine(PortalTravel(0.5f));
		}
		if (collision.CompareTag("ProgMarker"))
		{
			ProgressBarController.IncrementProgress(0.25f);
		}
	}

	IEnumerator PortalTravel(float duration)
	{
		yield return new WaitForSeconds(0.5f);
		portalTraveled = true;
	}

}
