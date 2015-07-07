using UnityEngine;
using System.Collections;

public class BeerRain : MonoBehaviour {

    public float ftime = 0;
    private Transform boardHolder;
    public GameObject Beer;

	void Start () 
    {
	
	}
	
	void Update () 
    {
        BeerDrop();
	}

    void BeerDrop()
    {
        ftime += Time.deltaTime;
        if (ftime < 3) return;
        ftime = 0;

        boardHolder = new GameObject("Board").transform;

        for (int x = -50; x <50 ; x++)
        {
            for (int y = 50; y <65 ; y++)
            {
                    GameObject toInstantiate = Beer;
                    GameObject instance = Instantiate(toInstantiate, new Vector3((Random.Range(-50,49)) * Random.Range(1,9) * 0.1f, (Random.Range(50,99)  * Random.Range(1,9) * 0.1f), 0), toInstantiate.transform.rotation) as GameObject;
                    instance.transform.SetParent(boardHolder);
            }
        }
    }
}
