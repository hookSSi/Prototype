using UnityEngine;
using System.Collections;
using System.Timers;

public class BulletMove_Player : MonoBehaviour
{
    public float Speed = 1f;
    public GameObject Sound;

	void Start () 
    {
        Instantiate(Sound);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = mousePosition - transform.position;
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        int objectAngle = 90; // Default Angle of an Object
        transform.rotation = Quaternion.AngleAxis(angle - objectAngle, Vector3.forward);
        GetComponent<Rigidbody2D>().AddForce(mousePosition * Speed);
	}
	

	void Update() 
    {
        Invoke("Destroy_Me", 2f);
	}

    void Destroy_Me()
    {
        Destroy(this.gameObject);
    }
}
