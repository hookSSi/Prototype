using UnityEngine;
using System.Collections;

public class CarScript : MonoBehaviour {

    public float Speed = 0;
    public Vector2 Toward;
    public bool Visible;
    public GameObject HitSound;

	void Start () 
    {
        
	}
	
	void Update () 
    {
        transform.GetComponent<Rigidbody2D>().velocity = Toward * Speed * Time.deltaTime;

        if (this.tag == "CarNE")
            GetComponent<SpriteRenderer>().enabled = !GameObject.Find("GameManager").GetComponent<GameManager>().MusicBool[0];
        else if(this.tag == "CarSW")
            GetComponent<SpriteRenderer>().enabled = !GameObject.Find("GameManager").GetComponent<GameManager>().MusicBool[1];
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Instantiate(HitSound);
            Handheld.Vibrate();
            GameObject.Find("GameManager").GetComponent<GameManager>().PlayerLife = false;
        }
    }
}
