using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    private Slider slider;
    public float FillSpeed = 0.5f;
    private float targetProgress = 0;
    // Start is called before the first frame update
    void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

	void Start()
	{

	}

	// Update is called once per frame
	void Update()
    {
        Debug.Log("Incremening Progress Bar");
        slider.value += targetProgress;
		targetProgress = 0;
	}

    public void IncrementProgress(float progress)
    {
		targetProgress = 0;
		targetProgress = progress;
		Debug.Log($"Incremening by {progress}");
	}    
    
    public void ResetProgress()
    {
        slider.value = 0;
	}
}
