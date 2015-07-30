using UnityEngine;
using System.Collections;

public class BuildingScript : MonoBehaviour {

	void Start () 
    {
	
	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Plyaer")
        {
            
        }
    }
}
