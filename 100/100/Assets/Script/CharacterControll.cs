using UnityEngine;
using System.Collections;

public class CharacterControll : MonoBehaviour {

    public float Speed;
    private Vector2 Direction;
    private int HeartCount = 0;

	void Start ()
    {
       
	}
	
	void Update () 
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        else
            MoveFront();
    }

    public void MoveLeft()
    {
        Direction = new Vector2(1.92f, 0.96f);
        GetComponent<Rigidbody2D>().velocity = Direction * (-Speed) * Time.timeScale;
    }

    public void MoveRight()
    {
        Direction = new Vector2(1.92f, 0.96f);
        GetComponent<Rigidbody2D>().velocity = Direction * Speed * Time.timeScale;
    }

    void MoveFront()
    {
        Direction = new Vector2(-0.64f, 0.32f);
        GetComponent<Rigidbody2D>().velocity = Direction;
    }

    void OnTriggerEnter2D(Collider2D Item)
    {
        Destroy(Item.gameObject);
        HeartCount++;
    }
}
