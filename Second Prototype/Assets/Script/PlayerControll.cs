using UnityEngine;
using System.Collections;

public class PlayerControll : MonoBehaviour {

    public GameObject TileScale;
    private Transform PlayerPosition;
    private float X;
    private float Y;
    private Vector2 Forward;
    private Vector2 Left;
    private Vector2 Right;
    private RaycastHit2D hit;
    public float distance1;

    public delegate void SwapeDelegate(string way);

    void Start()
    {
        X = (1.3f * TileScale.transform.localScale.x) / 2;
        Y = (0.97f * TileScale.transform.localScale.y) / 3;

        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        Forward = new Vector2(X, -Y);
        Left = new Vector2(-X, -Y);
        Right = new Vector2(X, Y);

        distance1 = Vector2.Distance(PlayerPosition.position, ((Vector2)PlayerPosition.position + Forward));
    }

    private SwapeDelegate swapeDelegate;
    private Vector2 touchStartPos;
    private bool touchStarted;
    private float minSwipeDistancePixels = 100f;

    void Update()
    {
        if (GameObject.Find("UIManager").GetComponent<UIScript>().StartTrigger)
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.touches[0];

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        touchStarted = true;
                        touchStartPos = touch.position;
                        break;
                    case TouchPhase.Ended:
                        if (touchStarted)
                        {
                            Swipe(touch);
                            touchStarted = false;
                        }
                        break;
                    case TouchPhase.Canceled:
                        touchStarted = false;
                        break;
                    case TouchPhase.Stationary:
                        break;
                    case TouchPhase.Moved:
                        break;
                }
            }
        }
    }

    void Swipe(Touch touch)
    {
        var lastPos = touch.position;
        var distance = Vector2.Distance(lastPos, touchStartPos);

        if (distance > minSwipeDistancePixels && Time.timeScale > 0)
        {
           /* float dy = lastPos.y - touchStartPos.y;
            float dx = lastPos.x - touchStartPos.x;

            float angle = Mathf.Rad2Deg * Mathf.Atan2(dx, dy);

            angle = (360 + angle) % 360;

            if (280 < angle && angle < 350) // 앞으로 이동
            {
                hit = Physics2D.Raycast(((Vector2)PlayerPosition.position - Forward), Forward, distance1);

                if(hit.collider == null)
                {
                    GameObject.Find("BoardMaster").transform.Translate(X,-Y,0);
                    GameObject.Find("BoardManager").GetComponent<BoardScript>().BoardSet(15, 0);
                    GameObject.Find("BoardManager").GetComponent<BoardScript>().Count = 0;
                }   
            }

            else if (20 < angle && angle < 70) // 오른쪽 이동
            {
                hit = Physics2D.Raycast(PlayerPosition.position, Right, distance1);

                if (hit.collider == null)
                    GameObject.FindGameObjectWithTag("Player").transform.Translate(X, Y, 0);
            }

            else if (200 < angle && angle < 250) // 왼쪽 이동
            {
                hit = Physics2D.Raycast(PlayerPosition.position, Left, distance1);

                if (hit.collider == null)
                    GameObject.FindGameObjectWithTag("Player").transform.Translate(-X, -Y, 0);
            }*/
        }

        else
        {
            LeftRightTouch(touch);
        }
    }

    void LeftRightTouch(Touch touch)
    {
        if (touch.position.x < Screen.height * 0.2)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Right();
        }

        else if (touch.position.x > Screen.height * 0.8)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Left();
        }
    }

    public void FrontMove()
    {
        hit = Physics2D.Raycast(((Vector2)PlayerPosition.position - Forward), Forward, distance1);

        if (hit.collider == null)
        {
            GameObject.Find("BoardMaster").transform.Translate(X, -Y, 0);
            GameObject.Find("BoardManager").GetComponent<BoardScript>().BoardSet(15, 0);
            GameObject.Find("BoardManager").GetComponent<BoardScript>().Count = 0;
        }   
    }

    public void RightMove()
    {
        hit = Physics2D.Raycast(PlayerPosition.position, Right, distance1);

        if (hit.collider == null)
            GameObject.FindGameObjectWithTag("Player").transform.Translate(X, Y, 0);
    }

    public void LeftMove()
    {
        hit = Physics2D.Raycast(PlayerPosition.position, Left, distance1);

        if (hit.collider == null)
            GameObject.FindGameObjectWithTag("Player").transform.Translate(-X, -Y, 0);
    }
}
