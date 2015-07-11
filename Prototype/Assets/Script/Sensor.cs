using UnityEngine;
using System.Collections;

public class Sensor : MonoBehaviour {

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Police" && GameObject.Find("GameManager").GetComponent<GameManager>().GunMan)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().SirenBool = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Police")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().SirenBool = false;
        }
    }
}
