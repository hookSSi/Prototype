using UnityEngine;
using System.Collections;

public class BoardScript : MonoBehaviour {

    public GameObject[] RoadTile;
    public GameObject[] WallTile1;
    public GameObject[] WallTile2;
    public GameObject[] RespawnTile;
    public float Count = 0;
    private GameObject[] AnnoyingTile;
    private GameObject ToInstantiate;
    private GameObject ToInstantiate2;
    private GameObject instance;
    private GameObject Subinstance;
    private GameObject SubToInstantiate;
    private Transform BoardHolder;
    private Transform BoardChild;
    private float X;
    private float Y;
    private float Z = 0;
    private Transform BoardPosition;
    private Transform PlayerPosition;
    private Vector2 Forward;
    private Vector2 Left;
    private Vector2 Right;
    private RaycastHit2D hit;
    private float distance;

	void Start () 
    {
        X = (1.3f * RoadTile[0].transform.localScale.x) / 2;
        Y = (0.97f * RoadTile[0].transform.localScale.y) / 3;
        BoardHolder = new GameObject("BoardMaster").transform;
        BoardSet(0, 0);
        BoardPosition = GameObject.FindGameObjectWithTag("BoardMaster").transform;
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;

        Forward = new Vector2(X, -Y);
        Left = new Vector2(-X, -Y);
        Right = new Vector2(X, Y);

        distance = Vector2.Distance(PlayerPosition.position, ((Vector2)PlayerPosition.position + Forward));
	}
	
	void Update () 
    {
        if (GameObject.Find("UIManager").GetComponent<UIScript>().StartTrigger && GameObject.Find("GameManager").GetComponent<GameManager>().PlayerLife && Time.timeScale > 0)
       { 
            if (Input.GetKeyDown(KeyCode.W))
            {
                hit = Physics2D.Raycast(((Vector2)PlayerPosition.position - Forward), Forward, distance);

                if (hit.collider == null)
                {
                    BoardPosition.Translate(X, -Y, 0);
                    BoardSet(15, 0);
                    Count = 0;
                }   
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                hit = Physics2D.Raycast(PlayerPosition.position, Left, distance);

                if (hit.collider == null)
                    PlayerPosition.Translate(-X, -Y, 0);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                hit = Physics2D.Raycast(PlayerPosition.position, Right, distance);

                if (hit.collider == null)
                    PlayerPosition.Translate(X, Y, 0);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {

            }

            Count += Time.deltaTime;

            if (Count > 300)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().PlayerLife = false;
            }
       }
	}

    public void BoardSet(int a,int b)
    {
        int z = 0;

        for (int i = a; i < 16; i++)
        {
            BoardChild = new GameObject("Board" + z++).transform;
            ToInstantiate = RoadTile[Random.Range(0, RoadTile.Length)];
            for (int j = b; j < 15; j++)
            {
                if(i == 8)
                {
                    if ((j == 1 || j == 14))
                        AnnoyingTileSet(i, j);

                    else
                    {
                        ToInstantiate = RoadTile[0];
                        instance = Instantiate(ToInstantiate, new Vector3(0 + X * j - X * i, -5 + Y * j + (0.97f - X) * i, (Z += 0.01f) + 0.1f * j + 0.1f * i), Quaternion.identity) as GameObject;
                    }
                }

                else if ( ((ToInstantiate == RoadTile[1]) || (ToInstantiate == RoadTile[0])) && (j % Random.Range(4, 9) == Random.Range(0, 2)) || (j == 1 || j == 14))
                {
                    AnnoyingTileSet(i, j);
                }

                else
                {
                     instance = Instantiate(ToInstantiate, new Vector3(0 + X * j - X * i, -5 + Y * j + (0.97f - X) * i, (Z += 0.01f) + 0.1f * j + 0.1f * i), Quaternion.identity) as GameObject;
                }  

                instance.transform.SetParent(BoardChild);
                BoardHolder.gameObject.tag = "BoardMaster";
                BoardChild.gameObject.tag = "BoardChild";
            }

            if (((ToInstantiate == RoadTile[2]) || (ToInstantiate == RoadTile[3])))
                CarBoardSet(i);

            BoardChild.transform.SetParent(BoardHolder);
        }
    }

    void CarBoardSet(int i)
    {
        Subinstance = RespawnTile[Random.Range(0,RespawnTile.Length)];

        if (Subinstance == RespawnTile[0])
            Subinstance = Instantiate(Subinstance, new Vector3(0 + X * 0 - X * i, -5 + Y * 0 + (0.97f - X) * i, 0), Quaternion.identity) as GameObject;
        else
            Subinstance = Instantiate(Subinstance, new Vector3(0 + X * 14 - X * i, -5 + Y * 14 + (0.97f - X) * i, 0), Quaternion.identity) as GameObject;

            Subinstance.transform.SetParent(BoardChild);
    }  

    void AnnoyingTileSet(int i,int j)
    {
        if (ToInstantiate == RoadTile[0])
            AnnoyingTile = WallTile1;
        else
            AnnoyingTile = WallTile2;

        ToInstantiate2 = AnnoyingTile[Random.Range(0, AnnoyingTile.Length)];
        instance = Instantiate(ToInstantiate2, new Vector3(0 + X * j - X * i, -5 + Y * j + (0.97f - X) * i, (Z += 0.01f) + 0.1f * j + 0.1f * i), Quaternion.identity) as GameObject;
        instance.transform.SetParent(BoardChild);
    }
}