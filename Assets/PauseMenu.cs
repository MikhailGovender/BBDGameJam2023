using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If user hits escape
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //If pause menu is inactive
            if(!pauseMenu.activeSelf)
            {
                //Freeze Time in game
                Time.timeScale = 0f;
                //Activate Pause Menu
                pauseMenu.SetActive(true);
                //Make Cursor Visible In Menu
                Cursor.visible = true;
            }
            else
            {
                //Enable Time Again
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
                Cursor.visible = false;
            }
        }
    }

    public void QuitGame()
    {
        //Quits Game lol
        Application.Quit();
    }

	public void ResumeGame()
	{
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
	}
}
