using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class DeadOrAlive : MonoBehaviour {

    public GameObject Money;
    public GameObject[] AnimatorDie;
    public int DEADcount = 0;
    public bool DEAD = false;
    public int RANDOM = 0;
	
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (DEAD)
        {
            RANDOM = Random.Range(1, 3);

            if (this.gameObject.tag == "Player")
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().DEADcount++;
                Instantiate(AnimatorDie[Random.Range(0, AnimatorDie.Length)], transform.position, transform.rotation);
                Instantiate(Money, this.gameObject.transform.position, this.gameObject.transform.rotation);
                GameObject.Find("GameManager").GetComponent<GameManager>().PlayerDEAD = true;
                this.gameObject.SetActive(false);
            }

            else
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().DEADcount++;
                Instantiate(AnimatorDie[Random.Range(0, AnimatorDie.Length)], transform.position, transform.rotation);
                Instantiate(Money, this.gameObject.transform.position, this.gameObject.transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Attack" && DEAD == false)
        {
            Destroy(other.gameObject);
            DEAD = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().DEADcount++;
        }

        if(other.gameObject.tag == "Hand-Attack" & DEAD == false)
        {
            DEAD = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().DEADcount++;
        }
	}
}