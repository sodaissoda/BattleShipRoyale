using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public List<GameObject> ships;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform trans in gameObject.GetComponentsInChildren<Transform>()) {
            if(trans.parent == gameObject.transform) {
                Debug.Log(trans.gameObject.name);
                ships.Add(trans.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
