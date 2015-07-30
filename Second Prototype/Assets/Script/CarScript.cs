using UnityEngine;
using System.Collections;

public class CarScript : MonoBehaviour {

    public float Speed = 0;
    public Vector2 Toward;

	void Start () 
    {
        
	}
	
	void Update () 
    {
        transform.GetComponent<Rigidbody2D>().velocity = Toward * Speed * Time.deltaTime;
	}

    void OntriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().PlayerLife = false;
        }
    }
}
