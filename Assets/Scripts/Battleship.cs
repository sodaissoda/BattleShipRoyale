

/* This is the file for each individual ship on the board.
 * It has scripts pertaining to movement and whether or not it is selected.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battleship : MonoBehaviour
{

    private Vector3 direction;

    private float verticalInput;
    private float horizontalInput;
    private float gridSize;

    private bool canMove = true;
    private bool selected = false;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(checkSelected());

        selected = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        this.gridSize = gameManager.gridSize;
        direction = new Vector3(0, 0, 1); // ship pointing right (x vertical dir, z horizontal)
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetKeyDown(KeyCode.UpArrow) ? 1f : (Input.GetKeyDown(KeyCode.DownArrow) ? -1f : 0f);
        horizontalInput = Input.GetKeyDown(KeyCode.RightArrow) ? 1f : (Input.GetKeyDown(KeyCode.LeftArrow) ? -1f : 0f);

        if (selected) {
            if (canMove && verticalInput > 0) {
                transform.Translate(direction * gridSize);

                Debug.Log(this.gameObject.name + " Moved");
            }
            
            if(horizontalInput > 0) {
                transform.Rotate(0, 90, 0, Space.Self);

                Debug.Log(this.gameObject.name + " Turned right");
            }
            else if(horizontalInput < 0) {
                transform.Rotate(0 ,-90, 0, Space.Self);

                Debug.Log(this.gameObject.name + " Turned left");
            }
        }
    }

    
    void OnMouseDown() {
        Debug.Log("Ship clicked");
        selected = true;
    }

    public bool GetSelected() {
        return selected;
    }

    public void UnSelect() {
        selected = false;
    }
    

    IEnumerator checkSelected() {
        while (true) {
            Debug.Log(selected);
            yield return new WaitForSeconds(.5f);
        }
    }
}
