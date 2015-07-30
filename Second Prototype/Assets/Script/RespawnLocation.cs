using UnityEngine;
using System.Collections;

public class RespawnLocation : MonoBehaviour {

    private float RandomTime;
    private GameObject ToInstance;
    private GameObject Instance;
    public GameObject[] Car;

	void Start () 
    {
        StartCoroutine("CarIsComing");
	}

    IEnumerator CarIsComing()
    {
        CarInstance();
        RandomTime = Random.RandomRange(1,8);
        yield return new WaitForSeconds(RandomTime);
        CarInstance();
        StartCoroutine("CarIsComing");
    }

    void CarInstance()
    {
        ToInstance = Car[Random.Range(0, Car.Length)];
        Instance = Instantiate(ToInstance, transform.position, Quaternion.identity) as GameObject;
        Instance.transform.SetParent(transform);
    }
}
