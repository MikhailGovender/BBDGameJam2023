using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class LevelSelect : MonoBehaviour
{
    [SerializeField] public Scene[] levels;
    [SerializeField] public int i;

    private ArrayList levelCards;
    private UIDocument doc;
    private VisualElement root;

    void Awake() {
        doc = GetComponent<UIDocument>();
        root = doc.rootVisualElement;
        Button homeButton = root.Q<Button>("home-btn");
        homeButton.clicked += () => SceneManager.LoadScene("Main Menu");
        VisualElement levelScroll = root.Q<VisualElement>("level-scroll");

        // get all the level cards in the scroll view
        levelCards = new ArrayList(levelScroll.Query<VisualElement>(className: "lvl-card").ToList());
        Debug.Log("level Cards: " +  levelCards.Count);

        for (int i = 0; i < levelCards.Count; i++) {
            VisualElement levelCard = (VisualElement) levelCards[i];
            Label levelLabel = levelCard.Q<Label>("lvl-name-lbl");
            string levelName = levelLabel.text;

            if (isUnlocked (levelName)) {
                levelCard.AddManipulator(new Clickable(evt => SceneManager.LoadScene(levelName)));
            }
        }
    }

    bool isUnlocked(string levelName) {
        // this will have to be done later
        // considering using User Preferences to store
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
