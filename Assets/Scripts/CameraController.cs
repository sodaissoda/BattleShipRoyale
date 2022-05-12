using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    public float height;
    public float speed;

    private Vector3 prevPos;
    private Vector3 pos;
    private Vector3 posDiff;

    private bool first;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player1");
        first = true;
        prevPos = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log((player.GetComponent<Player>().GetCurrentShip() == null) ? "null" : player.GetComponent<Player>().GetCurrentShip().name) ;
        if(player.GetComponent<Player>().GetCurrentShip() != null) {
            // transform.position = player.GetComponent<Player>().GetCurrentShip().transform.position + new Vector3(0, height, 0);
            MoveCamera();
        }
        else {
            Drag();
        }
    }

    void MoveCamera() {
        
    }


    void Drag() {
        if (Input.GetMouseButtonDown(0)) {
            player.GetComponent<Player>().UnselectAll();
            pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - new Vector3(Screen.width/2, 0, Screen.height/2));
        }
        if (first) {
            prevPos = pos;
            first = false;
        }

        if (!Input.GetMouseButton(0)) {
            first = true;
            return;
        }

        posDiff = prevPos - pos;

        transform.Translate(posDiff, Space.World);
        prevPos = pos;
    }
}
