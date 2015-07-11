using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

    public Transform Cam;
    public Transform Player;
    public Vector3 Center;
    public float Flip = 1;
    private float ftime = 0;

	void Start () 
    {

	}

    void FixedUpdate()
    {
        ftime += Time.deltaTime;

        if ((Mathf.Abs(Player.position.x - Cam.position.x) > 0.01) || (Mathf.Abs(Player.position.y - Cam.position.y) > 0.01))
        {
            Cam.position = new Vector3(Player.position.x,  Player.position.y, -10);
        }

        Flip *= -1;
        transform.Rotate(new Vector3(0, 0, GameObject.Find("GameManager").GetComponent<GameManager>().AlcoholBarSlider.value * 180) * Flip * Time.deltaTime);
    }
}
