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
        leaderboardButton = root.Q<Button>("leaderboard-btn");
        exitButton = root.Q<Button>("exit-btn");
        settingsButton = root.Q<Button>("settings-btn");
        aboutButton = root.Q<Button>("about-btn");

        playButton.clicked += StartGame;
        leaderboardButton.clicked += GoToLeaderboard;
        exitButton.clicked += ExitGame;
        settingsButton.clicked += GoToSettings;
        aboutButton.clicked += GoToAboutPage;
    }

    private void GoToAboutPage() {

    }

    private void GoToSettings() {

    }

    private void GoToLeaderboard() {
        SceneManager.LoadScene("LeaderBoard");
    }

    private void ExitGame() {
        Application.Quit();
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Level Select");
    }
}
