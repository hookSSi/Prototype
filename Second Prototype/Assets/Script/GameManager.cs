using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

    public GameObject PlayerUI;
    public GameObject Player;
    public GameObject GameOverUI;
    public Text ScoreText;
    public Text FinalScore;
    public bool PlayerLife = true;
    public bool[] MusicBool;
    public AudioSource Music;
    private float TimeScore = 0;

	void Start () 
    {
        MusicBool[0] = true;
        MusicBool[1] = true;
	}
	
	void Update () 
    {
        if (GameObject.Find("UIManager").GetComponent<UIScript>().StartTrigger)
        {
            if (!PlayerLife)
            {
                Music.Stop();
                Destroy(Player);
                Destroy(PlayerUI);
                GameOverUI.SetActive(!PlayerLife);
                Time.timeScale = 0;
                FinalScore.text = "Music Continued : " + Convert.ToInt32(TimeScore) + "초";
            }

            else if(Music.volume != 0)
            {
                TimeScore += Time.deltaTime;
                ScoreText.text = "Music Continued : " + Convert.ToInt32(TimeScore) + "초";
            }

           /* if (Input.GetMouseButtonDown(0))
            {
                MusicBool[0] = !MusicBool[0];
                if (!MusicBool[0])
                    Music.volume -= 0.5f;
                else
                    Music.volume += 0.5f;
            }

            if (Input.GetMouseButtonDown(1))
            {
                MusicBool[1] = !MusicBool[1];
                if (!MusicBool[1])
                    Music.volume -= 0.5f;
                else
                    Music.volume += 0.5f;
            }*/

            if (Music.volume == 0)
                Music.Pause();
            else
                Music.UnPause();
        }  
	}

    public void Left()
    {
        MusicBool[0] = !MusicBool[0];
        if (!MusicBool[0])
            Music.volume -= 0.5f;
        else
            Music.volume += 0.5f;
    }

    public void Right()
    {
        MusicBool[1] = !MusicBool[1];
        if (!MusicBool[1])
            Music.volume -= 0.5f;
        else
            Music.volume += 0.5f;
    }
}
