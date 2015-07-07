using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

    public Transform Cam;
    public Transform Player;

	void Start () 
    {
	
	}

    void FixedUpdate()
    {
        if ((Mathf.Abs(Player.position.x - Cam.position.x) > 3.2) || (Mathf.Abs(Player.position.y - Cam.position.y) > 1.9))
        {
            Cam.position = new Vector3(Player.position.x,  Player.position.y, -10);
        }

        Debug.Log(Cam.position);
    }
}
