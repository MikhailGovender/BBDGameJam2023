using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Custom;

public class Progress : MonoBehaviour
{
    
    public GameObject player;
    public GameObject start;
    public GameObject end;
    public string levelName;

    private float completion = 0f;

    private UIDocument doc;
    private VisualElement root;
    private ProgressBar lvlProgressBar;
    private float prev_completion = 0f;
    void Awake() {
        doc = GetComponent<UIDocument>();
        root = doc.rootVisualElement;
        lvlProgressBar = root.Q<ProgressBar>("lvl-progress");
    }

    // Update is called once per frame
    void Update()
    {

        float playerX = player.transform.position.x;
        float startX = start.transform.position.x;
        float endX = end.transform.position.x;

        completion = 100 * (playerX - startX) / (endX - startX);
        lvlProgressBar.value = completion;

        // update leveldata on death
        if (prev_completion > completion) {
            LevelData data = LevelData.getData(levelName);
            if (data.completion < prev_completion) {
                data.completion = prev_completion;
                //data.levelName = levelName;
            }

            data.tries += 1;

            LevelData.writeData(data);
        }

        prev_completion = completion;

    }
}
