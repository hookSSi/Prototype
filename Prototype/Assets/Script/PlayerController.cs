using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public bool VomitBool = false;
    public float Speed = 5f;
    public float ftime = 0;
    public Animator right;
    public Animator left;
    public GameObject Gun;
    public GameObject Hands;
    public GameObject Vomit;
    public Transform FirePosition;
    public GameObject Bullet;
    public Text AmmoText;
    public Slider Stemina;
    public Slider Alchol;
    public int PistolAmmo = 15;
    private bool Equip2 = false;
    private bool Equip1 = true;
    private bool rightBool = false;
    private bool leftBool = false;
    
	void Start () 
    {
       
	}

    void FixedUpdate()
    {
        ftime += Time.deltaTime;
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");

        if (Speed == 8f)
            Stemina.value -= (0.4f - Alchol.value * 0.1f) * Time.deltaTime;
        else
            Stemina.value += 0.1f * Time.deltaTime;

        Vector3 MoveMent = new Vector3(dirX, dirY, 0);
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

        if(!VomitBool)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && Stemina.value > 0)
            {
                Speed = 8f;
                Stemina.gameObject.SetActive(true);
            }

            else if (Stemina.value < 0.05)
            {
                VomitBool = true;
            }

            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Speed = 5f;
                Stemina.gameObject.SetActive(false);
            }
        }
           

        if (Input.GetMouseButtonDown(0) && Equip2 && distance >= 2 && PistolAmmo > 0)
        {
          if(ftime > 0.5f)
          {
              Fire();
              ftime = 0;
          }
        }

        if(VomitBool)
        {
            StartCoroutine("StartVomit");
        }

        if (Equip1)
        {
            if (Input.GetMouseButtonDown(0))
                left.Play("Attackleft");

            if (Input.GetMouseButtonDown(1))
                right.Play("Attackright");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
            EquipGun();
        if (Input.GetKeyDown(KeyCode.Alpha1))
            EquipHands();
    }

    void EquipGun()
    {
        Equip2 = !Equip2;
        Equip1 = !Equip1;
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

    IEnumerator StartVomit()
    {
        Speed = 0;
        Instantiate(Vomit, transform.position, transform.rotation);
        yield return new WaitForSeconds(3f);
        VomitBool = false;
        Speed = 5f;
    }
}
