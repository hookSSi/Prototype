using UnityEngine;
using System.Collections;
using System.Timers;

public class BulletMove : MonoBehaviour {

    float Speed = 20f;

	void Start () 
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = mousePosition - transform.position;
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        int objectAngle = 90; // Default Angle of an Object
        transform.rotation = Quaternion.AngleAxis(angle - objectAngle, Vector3.forward);
        GetComponent<Rigidbody2D>().velocity = mousePosition * Speed;
	}
	

	void Update() 
    {
        Invoke("Destroy_Me", 2f);
	}

    void Destroy_Me()
    {
        Object.Destroy(this.gameObject);
    }
}
