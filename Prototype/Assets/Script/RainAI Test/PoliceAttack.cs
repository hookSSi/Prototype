using UnityEngine;
using System.Collections;

public class PoliceAttack : MonoBehaviour 
{

    private bool SirenBool = false;
    public bool Equip = false;
    public GameObject Gun;
    public GameObject Siren;
    public GameObject Bullet;
    public GameObject FirePosition;
    private float ftime = 0f;

    void Update()
    {
        Siren.SetActive(!SirenBool);
        Gun.SetActive(!Equip);
        Attack(); //공격기능   
    }

    void Attack()
    {
        ftime += Time.deltaTime;

        lookAtPlayer();
        if (ftime < 2) return;

        Fire();
        ftime = 0;
    }

    void Fire()
    {
        Instantiate(Bullet, FirePosition.transform.position, FirePosition.transform.rotation);
    }

    void lookAtPlayer()
    {
        Vector3 TargetPosition = GameObject.Find("PlayerPosition").GetComponent<Transform>().position;
        TargetPosition = TargetPosition - transform.position;
        float angle = Mathf.Atan2(TargetPosition.y, TargetPosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
