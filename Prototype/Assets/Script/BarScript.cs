using UnityEngine;
using System.Collections;

public class BarScript : MonoBehaviour {

    public GameObject DrinkingSound;
    public GameObject CashSound;
    public GameObject Effect;
    public Transform BarPosition;
    private bool In = false;

	void Start () 
    {
	
	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (GameObject.Find("GameManager").GetComponent<GameManager>().Money >= 100 && !In)
            {
                In = true;
                StartCoroutine("BuyingDrink");    
            }
        }
    }

    IEnumerator BuyingDrink()
    {
        Instantiate(CashSound);
        Instantiate(DrinkingSound);
        Instantiate(Effect, BarPosition.position,BarPosition.rotation);
        while (GameObject.Find("GameManager").GetComponent<GameManager>().Money >= 100)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Money -= 100;
            GameObject.Find("GameManager").GetComponent<GameManager>().AlcoholBarSlider.value += 0.05f;
        }    
        yield return new WaitForSeconds(1f);
        In = false;
    }
}
