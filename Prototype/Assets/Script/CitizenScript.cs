using UnityEngine;
using System.Collections;
using System.Timers;

public class CitizenScript : MonoBehaviour {

    private bool ScreamingBool = false;
    public bool isSearch = false;
    public GameObject Screaming;
    public GameObject RunningAI;

    void OntriggerEnter(Collider2D other)
    {
        Search();

        if (isSearch == true)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().CallPolice = this.GetComponent<Transform>();
            GameObject.Find("GameManager").GetComponent<GameManager>().Call = true;
            Screaming.SetActive(!ScreamingBool);
            RunningAI.SetActive(!ScreamingBool);
        }


        else
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Call = false;
            Screaming.SetActive(ScreamingBool);
            RunningAI.SetActive(ScreamingBool);
        }
    }

    void Search()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().GunMan == true)
        {
            float distance = Vector2.Distance(GameObject.Find("PlayerPosition").transform.position, transform.position);

            if (distance >= 10)
                isSearch = false;
            else
            {
                if (Vector2.Distance(GameObject.FindWithTag("PlayerPosition").transform.position, transform.position) < 10)
                    isSearch = true;
            }
        }
    }
}
