using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{

    private Transform boardHolder;

    private int a = 0, b = 0;
    public int columns = 11;
    public int rows = 11;
    public Transform Player;
    public GameObject RoadTile;
    public GameObject[] BulidingTile;
    public Camera MainCamera;
    public float X = 0;
    public float Y = 0;
    public ArrayList Array_x = new ArrayList();
    public ArrayList Array_y = new ArrayList();

    void Start()
    {
        X = Player.position.x;
        Y = Player.position.y;
        BoardSet();
    }

    void Update()
    {
        if (10 < Mathf.Abs((Player.position.x - X)) && !Array_x.Contains(X) && !Array_y.Contains(Y))
        {
           Array_x.Add(X);
           a = Player.position.x + 5;
           BoardSet();
           X = Player.position.x;
           Y = Player.position.y;
        }

        if (5 < Mathf.Abs((Player.position.y - Y)) && !Array_y.Contains(Y) && !Array_x.Contains(X))
        {
            Array_y.Add(Y);
            b = Player.position.y + 5;
            BoardSet();
            X = Player.position.x;
            Y = Player.position.y;
        }
    }

    void BoardSet()
    {
        boardHolder = new GameObject("Board").transform;

        for (int x = -5 + a; x < columns - 5 + a; x++)
        {
            for (int y = -5 + b; y < rows - 5 + b; y++)
            {
                if (x == 0 + a || y == 0 + b)
                {
                   GameObject toInstantiate = RoadTile;
                   GameObject instance = Instantiate(toInstantiate, new Vector3((x + a) * 1.55f, (y + b) * 1.4f, 0), toInstantiate.transform.rotation) as GameObject;
                   instance.transform.SetParent(boardHolder);
                }

                else if ((x == Random.Range(-4 + a, -1 + b) && y == Random.Range(-4 + a, -1 + b)) || (x == Random.Range(1 + a, 4 + b) && y == Random.Range(1 + a, 4 + b)))
                {
                    if (x == 0 + a || y == 0 + b)
                        continue;

                    GameObject toInstantiate = BulidingTile[Random.Range(0, BulidingTile.Length)];
                    GameObject instance = Instantiate(toInstantiate, new Vector3( (x + a) * 1.78f, (y + b) * 1.84f, 0), toInstantiate.transform.rotation) as GameObject;
                    instance.transform.SetParent(boardHolder);
                }
            }
        }
    }
}