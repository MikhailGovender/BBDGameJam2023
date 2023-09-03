using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuScript : MonoBehaviour
{

    private UIDocument doc;
    private VisualElement root;

    private Button 
        playButton, 
        leaderboardButton, 
        exitButton, 
        settingsButton, 
        aboutButton;
    
    private void Awake() {
        doc = GetComponent<UIDocument>();
        root = doc.rootVisualElement;
        playButton = root.Q<Button>("play-btn");
        exitButton = root.Q<Button>("exit-btn");

        playButton.clicked += StartGame;
        exitButton.clicked += ExitGame;
    }

    private void GoToAboutPage() {

    }

    private void GoToSettings() {

    }

    private void ExitGame() {
        Application.Quit();
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Level Select");
    }
}
