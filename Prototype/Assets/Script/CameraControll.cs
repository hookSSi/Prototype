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
        if ((Mathf.Abs(Player.position.x - Cam.position.x) > 0.01) || (Mathf.Abs(Player.position.y - Cam.position.y) > 0.01))
        {
            Cam.position = new Vector3(Player.position.x,  Player.position.y, -10);
        }
    }
}
