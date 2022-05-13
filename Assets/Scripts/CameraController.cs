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
    private Vector3 mousePos;
    public Vector3 centerScreen;

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
        if (!Input.GetMouseButton(0)) {
            first = true;
            return;
        }
        player.GetComponent<Player>().UnselectAll();
        mousePos = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y - 1f).normalized;// - new Vector3(.5f, 0, .5f);
        Debug.Log(mousePos);

        pos = Vector3.Scale(mousePos, new Vector3(speed, 0, speed));
        //Debug.Log(pos);
        
        if (first) {
            prevPos = pos;
            first = false;
        }

        posDiff = prevPos - pos;
        //Debug.Log(posDiff);

        //transform.Translate(posDiff, Space.World);
        prevPos = pos;
    }
}
