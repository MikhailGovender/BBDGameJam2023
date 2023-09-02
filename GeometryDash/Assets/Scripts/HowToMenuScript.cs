using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToMenuScript : MonoBehaviour
{
	public GameObject howToMenu;
	public void Back()
	{
		SceneManager.LoadScene("Main Menu");
	}
}
