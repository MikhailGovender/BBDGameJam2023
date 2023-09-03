using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
		Cursor.visible = true;
		gameOverUI.SetActive(true);
    }

	public void Restart()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
    public void MainMenu()
	{
        SceneManager.LoadScene("Main Menu");
	}
}