using UnityEngine;
using System.Collections;

public class NoBuliding : MonoBehaviour {

    private int life = 10;
    public GameObject Explode;
    public GameObject Item;
    public GameObject[] Fire;

	void Start () 
    {
	
	}

    void Update()
    {
      
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Building")
        {
            Destroy(other.gameObject);
        }
        
        if(this.tag == "Building" && other.tag =="Attack")
        {
            Destroy(other.gameObject);
            life--;
        }

        switch (life)
        {
            case 9: Fire[Random.Range(0, Fire.Length)].SetActive(true);
                break;
            case 5: Fire[Random.Range(0, Fire.Length)].SetActive(true);
                break;
            case 3: Fire[Random.Range(0, Fire.Length)].SetActive(true);
                break;
            case 0: Destroy(this.gameObject);
                for (int i = 0; i < Random.Range(5,8);i++)
                    Instantiate(Item, this.gameObject.transform.position , this.gameObject.transform.rotation);
                Instantiate(Explode, this.gameObject.transform.position, this.gameObject.transform.rotation);
                break;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Building")
        {
            Destroy(other.gameObject);
        }
    }
}
