using UnityEngine;
using System.Collections;

public class PlayerControll : MonoBehaviour {

    public const string UP = "Up";
    public GameObject TileScale;
    private float X;
    private float Y;

    public delegate void SwapeDelegate(string way);

    void Start()
    {
         X = (1.3f * TileScale.transform.localScale.x) / 2;
         Y = (0.97f * TileScale.transform.localScale.y) / 3;
    }

    public SwapeDelegate swape
    {
        set
        {
            swapeDelegate = value;
        }
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

        if (distance > minSwipeDistancePixels)
        {
            float dy = lastPos.y - touchStartPos.y;
            float dx = lastPos.x - touchStartPos.x;

            float angle = Mathf.Rad2Deg * Mathf.Atan2(dx, dy);

            angle = (360 + angle - 45) % 360;

            if (0 < angle && angle < 90)
            {
                swapeDelegate("UP");
                GameObject.FindGameObjectWithTag("Tile").transform.Translate(X, -Y, 0);
                GameObject.Find("BoardManager").GetComponent<BoardScript>().BoardSet(15, 0);
                GameObject.Find("BoardManager").GetComponent<BoardScript>().Count = 0;
            }

            else if(90 < angle && angle < 180)
            {
                GameObject.FindGameObjectWithTag("Player").transform.Translate(X, Y, 0);
            }

            else if(270 < angle && angle < 360)
            {
                GameObject.FindGameObjectWithTag("Player").transform.Translate(-X, -Y, 0);
            }
        }
    }	
}
