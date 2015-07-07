using UnityEngine;
using System.Collections;

public class PeopleisComing : MonoBehaviour {

    public GameObject People;

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
        yield return new WaitForSeconds(10f);
        Instantiate(People, new Vector3(Random.Range(this.gameObject.transform.position.x - 5, this.gameObject.transform.position.x + 5), this.gameObject.transform.position.y - 5, this.gameObject.transform.position.y + 5), this.gameObject.transform.rotation);
        StopCoroutine("PeopleIsComing");
    }
}
