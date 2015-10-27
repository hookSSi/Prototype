using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;


public struct Position
{
    public float x, y;
}

public class BoardManager : MonoBehaviour {

    public int columns, rows;
    public GameObject[] GroundTile;

    private Position MapPosition;
    private Transform boardHolder; 
    private List<Vector3> gridPositions = new List<Vector3>();

    void Start ()
    {
        MapPosition.y = -15f;
        MapPosition.x = -13f;

        BoardSetup();

       // BoardSetup();
    }
	
	void Update ()
    {
	
	}

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;

        
        

        for (float y = MapPosition.y; y < (columns + 1 + MapPosition.y); y++)
        {
            for (float x = MapPosition.x; x < (rows + 1 + MapPosition.x); x++)
            {
                if (x == MapPosition.x || y == MapPosition.y || x == rows + MapPosition.x || y == columns + MapPosition.y)
                {
                    GameObject toInstantiate = GroundTile[1];
                    GameObject instance = Instantiate(toInstantiate, new Vector3(x * 0.64f - y * 0.64f, x * 0.32f + y * 0.32f, 0.01f * x + y * 0.01f), Quaternion.identity) as GameObject;
                    instance.transform.SetParent(boardHolder);
                }

                else
                {
                    GameObject toInstantiate = GroundTile[0];
                    GameObject instance = Instantiate(toInstantiate, new Vector3(x * 0.64f - y * 0.64f, x * 0.32f + y * 0.32f, 0.01f * x + y * 0.01f), Quaternion.identity) as GameObject;
                    instance.transform.SetParent(boardHolder);
                }
            }
        }

        MapPosition.x += ((rows + 1) * 0.64f - (columns + 2) * 0.64f);
        MapPosition.y += ((rows + 1) * 0.32f + (columns + 2) * 0.32f);

        boardHolder.SetParent(this.transform);
    }
}