using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{

    private Transform boardHolder;

    private int a = 0, b = 0;
    public int columns = 11;
    public int rows = 11;
    public int Limit = 0;
    public int count = 0;
    public Transform Player;
    public GameObject PeopleIsComing;
    public GameObject LoadingImage;
    public GameObject[] People;
    public GameObject RoadTile;
    public GameObject[] BulidingTile;

    void Start()
    {
        StartCoroutine("LoadingGame");

        Limit = Random.Range(50, 80);
        PeopleSet();
        BoardSet();

            for (; a != 25; a += 5)
       {
           for(;b!=25;b+=5)
               BoardSet();
           for (b = 0; b != -25; b -= 5)
               BoardSet();
       }

        for (; a != -25; a -= 5)
        {
            for (; b != 25; b += 5)
                BoardSet();
            for (b = 0; b != -25; b -= 5)
                BoardSet();
        }
        StartCoroutine("OneDeadTwoLife");
    }

    void BoardSet()
    {
        for (int x = -5 + a; x < columns - 5 + a; x++)
        {
            for (int y = -5 + b; y < rows - 5 + b; y++)
            {
                if (x == 0 + a || y == 0 + b)
                {
                    GameObject toInstantiate1 = RoadTile;
                    Instantiate(toInstantiate1, new Vector3((x + a) * 1.55f, (y + b) * 1.4f, 0), toInstantiate1.transform.rotation);
                }

                else if (x == Random.Range(-5+a,columns - 5 + a))
                {
                    GameObject toInstantiate1 = BulidingTile[Random.Range(0, BulidingTile.Length)];
                    Instantiate(toInstantiate1, new Vector3( (x + a) * 1.78f, (y + b) * 1.84f, 0), toInstantiate1.transform.rotation);
                }

                if(x == 0 + a && y == 0 + b)
                {
                    GameObject toInstantiate3 = PeopleIsComing;
                    Instantiate(toInstantiate3, new Vector3(x,y,0), toInstantiate3.transform.rotation);
                }
            }
        }
    }

    void PeopleSet()
    {
        for (int x = -80 + a; x < 80; x++)
        {
            for (int y = -80 + b; y < 80; y++)
            {
                if (x == Random.Range(-80, 80))
                {
                    GameObject toInstantiate2 = People[Random.Range(0, People.Length)];
                    Instantiate(toInstantiate2, new Vector3(x, y, 0), toInstantiate2.transform.rotation);
                    count++;
                }

                if (Limit == count)
                {
                    return;
                }
            }
        }
    }

    IEnumerator OneDeadTwoLife()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().DEADcount > 1)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject toInstantiate = People[Random.Range(0, People.Length)];
                Instantiate(toInstantiate, new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0), toInstantiate.transform.rotation);
            }
            GameObject.Find("GameManager").GetComponent<GameManager>().DEADcount = 0;
        }

        yield return new WaitForSeconds(2);
        StartCoroutine("OneDeadTwoLife");
    }

    IEnumerator LoadingGame()
    {
        LoadingImage.SetActive(true);
        yield return new WaitForEndOfFrame();
        LoadingImage.SetActive(false);
    }
}