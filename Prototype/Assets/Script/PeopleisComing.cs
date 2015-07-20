using UnityEngine;
using System.Collections;

public class PeopleisComing : MonoBehaviour {

    public GameObject People;
    public float RespawnTime = 0;

	void Start () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
	    if(other.tag == "Player")
        {
            StartCoroutine("PeopleIsComing");
        }
	}

    IEnumerator PeopleIsComing()
    {
        yield return new WaitForSeconds(RespawnTime);
        Instantiate(People, new Vector3(Random.Range(this.gameObject.transform.position.x - 20, this.gameObject.transform.position.x + 20), this.gameObject.transform.position.y - 20, this.gameObject.transform.position.y + 20), this.gameObject.transform.rotation);
        StopCoroutine("PeopleIsComing");
    }
}
