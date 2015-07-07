using UnityEngine;
using System.Collections;

public class BulletMove_Police : MonoBehaviour
{
    public float Speed = 10f;
    public GameObject Sound;

    void Start()
    {
        Instantiate(Sound);
        Vector3 TargetPosition = GameObject.Find("Player").GetComponent<Transform>().position;
        TargetPosition = TargetPosition - transform.position;
        float angle = Mathf.Atan2(TargetPosition.y, TargetPosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        GetComponent<Rigidbody2D>().AddForce (TargetPosition * Speed);
    }

    void Update()
    {
        Invoke("Destroy_Me", 1f);
    }

    void Destroy_Me()
    {
        Destroy(this.gameObject);
    }
}
