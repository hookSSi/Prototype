using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float Speed = 2f;
    public GameObject Gun;
    public Transform FirePosition;
    public GameObject Bullet;
    private bool Equip = false;

	void Start () 
    {
	
	}
	
	void FixedUpdate () 
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");
        
        Vector3 MoveMent = new Vector3 (dirX,dirY,0);

        GetComponent<Rigidbody2D>().velocity = MoveMent * Speed;
	}

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = mousePosition - transform.position;
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        int objectAngle = 90; // Default Angle of an Object
        transform.rotation = Quaternion.AngleAxis(angle - objectAngle, Vector3.forward);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            EquipWeapon();

        if (Input.GetMouseButtonDown(0) && Equip)
            Fire();
    }

    bool EquipWeapon()
    {
        Equip = !Equip;
        Gun.SetActive(Equip);

        return Equip;
    }

    void Fire()
    {
        Instantiate(Bullet, FirePosition.position, FirePosition.rotation);
    }
}
