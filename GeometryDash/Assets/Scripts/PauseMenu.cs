using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private UIDocument doc;
    private VisualElement root;
    private VisualElement menuPanel;
    private Button resumeButton;
    private Button pauseButton;
    private Button quitButton;

    private string state = "PLAYING";

    private void Awake() {
        doc = GetComponent<UIDocument>();
        root = doc.rootVisualElement;
        menuPanel = root.Q<VisualElement>("menu-panel");
        pauseButton = doc.rootVisualElement.Q<Button>("pause-btn");
        resumeButton = doc.rootVisualElement.Q<Button>("resume-btn");
        quitButton = doc.rootVisualElement.Q<Button>("quit-btn");

        pauseButton.clicked += PauseGame;
        resumeButton.clicked += ResumeGame;
        quitButton.clicked += QuitGame;

        ResumeGame();
    }

    private void Start() {
        ResumeGame();
    }

    private void setVisible(VisualElement element, bool visible){
        if (visible) {
            element.style.display = DisplayStyle.Flex;
        } else {
            element.style.display = DisplayStyle.None;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If user hits escape
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //If pause menu is inactive
           if(state == "PLAYING")
            {
                PauseGame();
            }
            else if (state == "PAUSED")
            {
                ResumeGame();
            }
        }
    }

    private void PauseGame() {
        state = "PAUSED";
        Time.timeScale = 0f;
        setVisible(menuPanel, true);
    }

    private void QuitGame()
    {
        //Quits Game lol
        SceneManager.LoadScene("Main Menu");
    }

	private void ResumeGame()
	{
        state = "PLAYING";
        Time.timeScale = 1f;
        setVisible(menuPanel, false);
	}
}
