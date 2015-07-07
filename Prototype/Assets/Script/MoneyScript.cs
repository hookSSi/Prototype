using UnityEngine;
using System.Collections;

public class MoneyScript : MonoBehaviour {

	void Start () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Money += Random.Range(30,200);
            Destroy(this.gameObject);
        }
    }
}
