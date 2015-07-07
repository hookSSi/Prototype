using UnityEngine;
using System.Collections;

public class NoBuliding : MonoBehaviour {

	void Start () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Building")
        {
            Destroy(other.gameObject);
        }
        
        if(this.tag == "Building" && other.tag =="Attack")
        {
            Destroy(other.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Building")
        {
            Destroy(other.gameObject);
        }
    }
}
