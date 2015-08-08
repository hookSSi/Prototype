using UnityEngine;
using System.Collections;

public class EndTile : MonoBehaviour {

	void Start () 
    {
	
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tile" || other.gameObject.tag == "CarSW" || other.gameObject.tag == "CarNE")
        {
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().PlayerLife = false;
        }
    }
}
