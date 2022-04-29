using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public List<GameObject> ships;
    private GameObject camera;

    private GameObject shipToIgnore;

    private Vector3 dragOrigin;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        shipToIgnore = null;

        // adds player's ships to ships list
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
        ShipSelectorManager();
    }

    void ShipSelectorManager() {
        for(int i = 0; i < ships.Count; i++) {
            if (ships[i].GetComponent<Battleship>().GetSelected() && ships[i] != shipToIgnore) {
                shipToIgnore = ships[i];
                for (int j = 0; j < ships.Count; j++) {
                    if (ships[j] != shipToIgnore) {
                        ships[j].GetComponent<Battleship>().UnSelect();
                    }
                }
            }
        }
    }

    void UnselectAll() {
        for(int i = 0; i < ships.Count; i++) {
            ships[i].GetComponent<Battleship>().UnSelect();
        }
    }

    void OnMouseDrag(Collider other) {
        Debug.Log("mouse dragged");
        UnselectAll();

        if (Input.GetMouseButtonDown(0)) {
            dragOrigin = Input.mousePosition;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * speed, 0, pos.y * speed);

        transform.Translate(move, Space.World);
    }

    public GameObject GetCurrentShip() {
        return shipToIgnore;
    }
}
