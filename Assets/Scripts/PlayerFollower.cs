using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{

    public GameObject player;

    public float height;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log((player.GetComponent<Player>().GetCurrentShip() == null) ? "null" : player.GetComponent<Player>().GetCurrentShip().name) ;
        if(player.GetComponent<Player>().GetCurrentShip() != null) {
            transform.position = player.GetComponent<Player>().GetCurrentShip().transform.position + new Vector3(0, height, 0);
        }
    }
}
