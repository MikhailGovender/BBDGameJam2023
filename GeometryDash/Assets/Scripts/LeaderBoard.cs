using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LeaderBoard : MonoBehaviour
{
    private UIDocument doc;
    private VisualElement root;
    private Button homeButton;
    // Start is called before the first frame update
    void Start()
    {
        doc = GetComponent<UIDocument>();
        root = doc.rootVisualElement;
        homeButton = root.Q<Button>("home-btn");

        homeButton.clicked += GoToMainMenu;
    }

    private void GoToMainMenu() {
        SceneManager.LoadScene("Main Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
