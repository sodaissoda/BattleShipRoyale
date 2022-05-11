using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    public float height;
    public float speed;

    private Vector3 dragOrigin;

    private bool once;

    public float mod;


    // Start is called before the first frame update
    void Start()
    {
        once = false;
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


    // not what i want
    void Drag() {
        if (Input.GetMouseButtonDown(0) && !once) {
            dragOrigin = Input.mousePosition;
            once = true;
        }

        if (!Input.GetMouseButton(0)) {
            once = false;
            return;
        }

        Vector3 pos = Camera.main.ScreenToViewportPoint(dragOrigin - Input.mousePosition);
        Vector3 move = new Vector3((pos.x) * speed, 0, (pos.y) * speed);

        move -= new Vector3(move.x * mod, 0, move.y * mod) ;

        transform.Translate(move, Space.World);
    }
}
