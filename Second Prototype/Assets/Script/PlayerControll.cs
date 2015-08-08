using UnityEngine;
using System.Collections;

public class PlayerControll : MonoBehaviour {

    public const string UP = "Up";
    public GameObject TileScale;
    public Transform PlayerPosition;
    private float X;
    private float Y;
    private Vector2 Forward;
    private Vector2 Left;
    private Vector2 Right;
    private RaycastHit2D hit;
    private float distance;

    public delegate void SwapeDelegate(string way);

    void Start()
    {
        Forward = new Vector2(X, -Y);
        Left = new Vector2(-X, -Y);
        Right = new Vector2(X, Y);

         X = (1.3f * TileScale.transform.localScale.x) / 2;
         Y = (0.97f * TileScale.transform.localScale.y) / 3;

         distance = Vector2.Distance(PlayerPosition.position, ((Vector2)PlayerPosition.position + Forward));
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

    private void Swipe(Touch touch)
    {
        var lastPos = touch.position;
        var distance = Vector2.Distance(lastPos, touchStartPos);

        if (distance > minSwipeDistancePixels && Time.timeScale > 0)
        {
            float dy = lastPos.y - touchStartPos.y;
            float dx = lastPos.x - touchStartPos.x;

            float angle = Mathf.Rad2Deg * Mathf.Atan2(dx, dy);

            angle = (360 + angle) % 360;

            if (290 < angle && angle < 340)
            {
                hit = Physics2D.Raycast((Vector2)PlayerPosition.position - Forward, Forward, distance);

                if(hit.collider == null)
                {
                    GameObject.FindGameObjectWithTag("BoardMaster").transform.Translate(Forward);
                    GameObject.Find("BoardManager").GetComponent<BoardScript>().BoardSet(15, 0);
                    GameObject.Find("BoardManager").GetComponent<BoardScript>().Count = 0;
                }   
            }

            else if (20 < angle && angle < 70)
            {
                hit = Physics2D.Raycast(PlayerPosition.position, Right, distance);

                if (hit.collider == null)
                    GameObject.FindGameObjectWithTag("Player").transform.Translate(X, Y, 0);
            }

            else if (200 < angle && angle < 250)
            {
                hit = Physics2D.Raycast(PlayerPosition.position, Left, distance);

                if (hit.collider == null)
                    GameObject.FindGameObjectWithTag("Player").transform.Translate(-X, -Y, 0);
            }
        }
    }	
}
