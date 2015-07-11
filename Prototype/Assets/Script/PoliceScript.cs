using UnityEngine;
using System.Collections;
using System.Timers;

public class PoliceScript : MonoBehaviour {

    private bool SirenBool = false;
    private bool SirenBool_1 = false;
    public bool Equip = false;
    public GameObject PoliceMove;
    public GameObject Gun;
    public GameObject Bullet;
    public GameObject FirePosition;
    bool isSearch = false;
    public float ftime = 0f;

    void Update() 
    {
	    if(isSearch==true)
        {
            if ((GameObject.Find("GameManager").GetComponent<GameManager>().GunMan == true || SirenBool_1) && !GameObject.Find("Player").GetComponent<DeadOrAlive>().DEAD)
            {
                PoliceMove.SetActive(SirenBool);
                lookAtPlayer();
                SirenBool_1 = true;
                Gun.SetActive(!Equip);
                Attack(); 
            } 

            else
            {
                Gun.SetActive(Equip);
            }
        }
		    			

	    else
        {
            Gun.SetActive(Equip);
            Search(); 
        }
    }

    void Search()
    {
        float distance = Vector2.Distance(GameObject.Find("PlayerPosition").GetComponent<Transform>().position, transform.position);

        if (distance <= 8)
            isSearch = true;

        if(distance > 20)
            PoliceMove.SetActive(SirenBool);
        else
            PoliceMove.SetActive(!SirenBool);
    }

    void Attack()
    {
        float distance = Vector2.Distance(GameObject.Find("PlayerPosition").GetComponent<Transform>().position, transform.position);
        ftime += Time.deltaTime;  

        if (distance > 10)
            isSearch = false;

       if (ftime < 2) return;

       Fire();
       ftime = 0;
    }

    void Fire()
    {
        Instantiate(Bullet,FirePosition.transform.position,FirePosition.transform.rotation);
    }

    void lookAtPlayer()
    {
        Vector3 TargetPosition = GameObject.Find("PlayerPosition").GetComponent<Transform>().position;
        TargetPosition = TargetPosition - transform.position;
        float angle = Mathf.Atan2(TargetPosition.y, TargetPosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
