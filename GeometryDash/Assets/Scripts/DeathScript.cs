using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    //References to Start/Respawn Point
    public GameObject startPoint;
    public GameObject Player;
    //Make player invisible on death
    SpriteRenderer spriteRenderer;
    Rigidbody2D PlayerRigidBody;
    Move MoveScript;

	public ProgressBarController ProgressBarController;


	private void Awake()
	{
		spriteRenderer = Player.GetComponent<SpriteRenderer>();
        PlayerRigidBody = Player.GetComponent<Rigidbody2D>();
        MoveScript = Player.GetComponent<Move>();
	}

	// Start is called before the first frame update
	void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {
        
    }

	void Die()
    {
        StartCoroutine(Respawn(0.2f));
    }

    IEnumerator Respawn(float duration)
     {
        MoveScript.portalTraveled = false;
        ProgressBarController.ResetProgress();

        //Player will dissapear on hitting obstacle
        spriteRenderer.enabled = false;
		PlayerRigidBody.velocity = Vector2.zero;
		yield return new WaitForSeconds(duration);

        //Player respawns after a few moments
		Player.transform.position = startPoint.transform.position;
        spriteRenderer.enabled = true;
		yield return new WaitForSeconds(0.5f);
	}

	//Function To Execute When Player collides with enemy/spike
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
        {
            //Reset Position to Start
            Die();
        }
	}
}
