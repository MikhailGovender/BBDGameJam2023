using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
  public GameObject target;
  // Start is called before the first frame update
  void Start()
  {
        
  }

  // Update is called once per frame
  void Update()
  {
    //Z Axis to -10 to ensure everything is seen
    transform.position = new Vector3(target.transform.position.x,target.transform.position.y,-10);
  }
}
