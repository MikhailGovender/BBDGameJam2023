using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
        
  }

  // Update is called once per frame
  void Update()
  {
        
  }

  //This is linked to FinishLine object
  //This funciton executes when something collides with the obj it is attached to
	private void OnCollisionEnter2D(Collision2D collision)
	{
		//Remember what tag the object you want to detect a collision with is
    if(collision.gameObject.CompareTag("Player"))
    {
      //Go to scene 2
      SceneManager.LoadScene("Level 2");
    }
	}
}
