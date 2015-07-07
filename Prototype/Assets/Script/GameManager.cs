using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private float ftime = 0f;
    private float Timer = 0f;
    public GameObject Vomit;
    public GameObject LoadingImage;
    public bool GunMan = false;
    public int DEADcount = 0;
    public int Money = 0;
    public float ALCOHOL = 100;
    public Transform CallPolice;
    public Text GameOver;
    public Text Money_text;
    public Text Alive;
    public Text AliveTime;
    public Slider AlcoholBarSlider;
    public bool PlayerDEAD = false;
    public bool Call = false;

	void Start () 
    {
        StartCoroutine("AlcoholUpdate");
        StartCoroutine("ALCOHOLreduce");
        StartCoroutine("DeltaTime");
        Screen.SetResolution(1600, 480, true);
	}

    IEnumerator ALCOHOLreduce()
    {
        if (AlcoholBarSlider.value > 0)
            AlcoholBarSlider.value -= 0.003f;
        Timer += Time.deltaTime;
        yield return new WaitForSeconds(0.1f);
        StartCoroutine("ALCOHOLreduce");
    }

    IEnumerator DeltaTime()
    {
        if (!PlayerDEAD)
        {
            ftime += 0.5f;
            Money_text.text = Money + " $";
            Alive.text = "Alive TIme: " + (int)ftime + "s";
        }

        yield return new WaitForSeconds(0.5f);

        StartCoroutine("DeltaTime");
    }
	
	void Update () 
    {
        if (PlayerDEAD)
        {
            StartCoroutine("EndGame");
        }

        if(AlcoholBarSlider.value == 0)
        {
            GameObject.Find("Player").GetComponent<DeadOrAlive>().DEAD = true;
        }       

        if(GameObject.Find("Player").GetComponent<DeadOrAlive>().DEAD == true)
        {
            PlayerDEAD = true;
            GameObject.Find("Player").GetComponent<DeadOrAlive>().DEAD = true;
        }
	}
    void FixedUpdate()
    {
        ALCOHOLreduce();
    }

    IEnumerator EndGame()
    {
        AliveTime.text = "Alive TIme: " + (int)ftime + "s";
        GameOver.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        Application.LoadLevel(0);
    }

    void AlcoholPower(int i,float HowMuch)
    {
        switch(i)
        {
            case 0: GameObject.Find("Player").GetComponent<PlayerController>().Speed = 2;
                    StartCoroutine("SlowSpeed");
                break;
            case 1: StartCoroutine("Twist");
                break;
            case 2: StartCoroutine("Twist");
                break;
            case 3: StartCoroutine("Twist");
                break;
        }
    }

    IEnumerator SlowSpeed()
    {
        yield return new WaitForSeconds(1 / AlcoholBarSlider.value);
        GameObject.Find("Player").GetComponent<PlayerController>().Speed = 5f;
    }

    IEnumerator OddController()
    {
        yield return new WaitForSeconds(1 / AlcoholBarSlider.value);
        GameObject.Find("Player").GetComponent<PlayerController>().Speed = 5f;
    }

    IEnumerator Twist()
    {
        GameObject.Find("Player").GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-50, 50), Random.Range(-50, 50)) * AlcoholBarSlider.value * 10);
        yield return new WaitForSeconds(1.5f - AlcoholBarSlider.value);
        StartCoroutine("Twist");
    }

    IEnumerator AlcoholPowerSelect()
    {
        AlcoholPower(Random.Range(0, 3), AlcoholBarSlider.value);
        yield return new WaitForSeconds(1 / AlcoholBarSlider.value);
    }

     IEnumerator AlcoholUpdate()
    {
        if (AlcoholBarSlider.value >= 0.8)
        {
            StartCoroutine("AlcoholPowerSelect");
        }

        else if (AlcoholBarSlider.value >= 0.5)
        {
            StartCoroutine("AlcoholPowerSelect");
        }

        else if (AlcoholBarSlider.value >= 0.3)
        {
            StartCoroutine("AlcoholPowerSelect");
        }
        yield return new WaitForSeconds(3 - AlcoholBarSlider.value * 2);

        StartCoroutine("AlcoholUpdate");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        StartCoroutine("LoadingGame");
        Application.LoadLevel(1);
    }

    IEnumerator LoadingGame()
    {
        LoadingImage.SetActive(true);
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(1);
        LoadingImage.SetActive(false);
    }
}
