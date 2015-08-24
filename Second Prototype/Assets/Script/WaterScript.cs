using UnityEngine;
using System.Collections;

public class WaterScript : MonoBehaviour {

	void Start () 
    {
	   
	}
	
	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().PlayerLife = false;
        }
    }
}
