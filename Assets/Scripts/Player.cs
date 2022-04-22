using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public List<GameObject> ships;

    private GameObject shipToIgnore;

    // Start is called before the first frame update
    void Start()
    {
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
}
