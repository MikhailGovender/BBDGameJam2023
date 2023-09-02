using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainMenu;

    public void StartGame()
    {
        SceneManager.LoadScene("Level Test");
    }

	public void HowToPlay()
	{
		SceneManager.LoadScene("How To Play");
	}
}
