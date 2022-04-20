using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject gridLine;
    public List<GameObject> players;
    private GameObject grid;

    public int gridSize;

    // Start is called before the first frame update
    void Start()
    {
        grid = GameObject.Find("Grid");

        GenerateGridLines();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateGridLines() {
        for(int j = -5; j <= 5; j++) {
            // x direciton first
                Instantiate(gridLine, new Vector3(gridSize * j, .01f, 0f), Quaternion.identity, grid.transform);
                
            // z direction (rotated 90)
                Instantiate(gridLine, new Vector3(0f, .01f, gridSize * j), Quaternion.AngleAxis(90, Vector3.up), grid.transform);
        }
    }

    void UnselectShips() {

    }
}