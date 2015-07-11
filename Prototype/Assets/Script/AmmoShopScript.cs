using UnityEngine;
using System.Collections;

public class AmmoShopScript : MonoBehaviour {

    public GameObject CashSound;
    public GameObject Effect;
    public Transform AmmoShopPosition;
    private bool In = false;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (GameObject.Find("Player").GetComponent<PlayerController>().PistolAmmo != 15 && GameObject.Find("GameManager").GetComponent<GameManager>().Money > 99 && !In)
            {
                In = true;
                StartCoroutine("BuyingAmmo");
            }
        }
    }


    IEnumerator BuyingAmmo()
    {
        Instantiate(CashSound);
        Instantiate(Effect, AmmoShopPosition.position, AmmoShopPosition.rotation);

        if (GameObject.Find("GameManager").GetComponent<GameManager>().Money < 100 * (15 - GameObject.Find("Player").GetComponent<PlayerController>().PistolAmmo))
        {
            while (GameObject.Find("GameManager").GetComponent<GameManager>().Money - 100 >= 0)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Money -= 100;
            } 
        }    

        else
            GameObject.Find("GameManager").GetComponent<GameManager>().Money -= 100 * (15 - GameObject.Find("Player").GetComponent<PlayerController>().PistolAmmo);

        GameObject.Find("Player").GetComponent<PlayerController>().PistolAmmo = 15;
        GameObject.Find("Player").GetComponent<PlayerController>().AmmoText.text = "15 / " + GameObject.Find("Player").GetComponent<PlayerController>().PistolAmmo;
        yield return new WaitForSeconds(1f);
        In = false;
    }
}
