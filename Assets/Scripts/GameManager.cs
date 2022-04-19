using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject gridLine;
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
        for(int i = 0; i < 2; i++) {
            for(int j = 0; j <= gridSize * 10; j++) {
                if (i == 0) { // x direction first
                    Instantiate(gridLine, new Vector3(0f, .01f, gridSize * j), Quaternion.identity, grid.transform);
                }
                else if(i == 1) { // z direction (rotated 90)
                    Instantiate(gridLine, new Vector3(0f, .01f, gridSize * j), Quaternion.AngleAxis(90, Vector3.up), grid.transform);
                }
            }
        }
    }
}