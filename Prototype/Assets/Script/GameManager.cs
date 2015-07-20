using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private float ftime = 0f;
    private float Timer = 0f;
    public bool SirenBool = false;
    public Animator CameraWarning;
    public GameObject Vomit;
    public GameObject LoadingImage;
    public GameObject Siren;
    public GameObject HowToPlayUI;
    public bool GunMan = false;
    public bool Active = false;
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
        Screen.SetResolution(1600, 480, false);
        StartCoroutine("AlcoholUpdate");
        StartCoroutine("ALCOHOLreduce");
        StartCoroutine("DeltaTime");
	}

    IEnumerator ALCOHOLreduce()
    {
        if (AlcoholBarSlider.value > 0)
            AlcoholBarSlider.value -= 0.003f;
        Timer += Time.deltaTime;
        yield return new WaitForSeconds(0.1f);
        StartCoroutine("ALCOHOLreduce");
    }

    IEnumerator SirenCheck()
    {
        Siren.SetActive(SirenBool);
        yield return new WaitForSeconds(0.1f);
        StartCoroutine("SirenCheck");
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
        Siren.SetActive(SirenBool);
    }

    IEnumerator EndGame()
    {
        AliveTime.text = "Alive TIme: " + (int)ftime + "s";
        GameOver.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        Application.LoadLevel(0);
    }

     IEnumerator AlcoholUpdate()
    {
        if (AlcoholBarSlider.value >= 0.8)
        {
            CameraWarning.SetBool("Warning", false);
        }

        else if (AlcoholBarSlider.value >= 0.4)
        {
            CameraWarning.SetBool("Warning", false);
        }

        else if (AlcoholBarSlider.value >= 0.2)
        {
            CameraWarning.SetBool("Warning", true);
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

    public void HowToPlay()
    {
        Active = !Active;
        HowToPlayUI.SetActive(Active);
    }

    IEnumerator LoadingGame()
    {
        LoadingImage.SetActive(true);
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(1);
        LoadingImage.SetActive(false);
    }
}
