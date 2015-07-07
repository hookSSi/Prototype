using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    Animator anim;
    public float Speed = 5f;
    public float ftime = 0;
    public GameObject Gun;
    public GameObject Hands;
    public Transform FirePosition;
    public GameObject Bullet;
    public Text AmmoText;
    public int PistolAmmo = 15;
    private bool Equip2 = false;
    private bool Equip1 = false;

	void Start () 
    {
        anim = GameObject.Find("Player-Hands").GetComponent<Animator>();
	}
	
	void FixedUpdate () 
    {
        ftime += Time.deltaTime;
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");
        
        Vector3 MoveMent = new Vector3 (dirX,dirY,0);

        GetComponent<Rigidbody2D>().velocity = MoveMent * Speed;
	}

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 MP = mousePosition;
        mousePosition = mousePosition - transform.position;
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        int objectAngle = 90; // Default Angle of an Object
        transform.rotation = Quaternion.AngleAxis(angle - objectAngle, Vector3.forward);
        float distance = Vector2.Distance(MP, GameObject.Find("Player").GetComponent<Transform>().position);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            EquipGun();
        if (Input.GetKeyDown(KeyCode.Alpha1))
            EquipHands();

        if (Input.GetMouseButtonDown(0) && Equip2 && distance >= 2 && PistolAmmo > 0)
        {
          if(ftime > 0.5f)
          {
              Fire();
              ftime = 0;
          }
        }

        if (Input.GetMouseButtonDown(0) && Equip1)
            FistAttack();
    }

    void EquipGun()
    {
        Equip2 = !Equip2;
        Equip1 = false;
        Gun.SetActive(Equip2);
        Hands.SetActive(Equip1);
        GameObject.Find("GameManager").GetComponent<GameManager>().GunMan = Equip2;
        AmmoText.gameObject.SetActive(Equip2);
        AmmoText.text = "15 / " + PistolAmmo; 
    }

    void EquipHands()
    {
        Equip2 = false;
        Equip1 = true;
        Hands.SetActive(Equip1);
        Gun.SetActive(Equip2);
        GameObject.Find("GameManager").GetComponent<GameManager>().GunMan = Equip2;
        AmmoText.gameObject.SetActive(Equip2);
    }

    void Fire()
    {
        Instantiate(Bullet, FirePosition.position, FirePosition.rotation);
        PistolAmmo -= 1;
        AmmoText.text = "15 / " + PistolAmmo; 
    }

    void FistAttack()
    {
        float ftime = 0;
        ftime += Time.deltaTime;
        anim.SetBool("EquipHands", true);

        if(ftime>2)
            anim.SetBool("EquipHands", false);
    }
}
