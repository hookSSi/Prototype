using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

    public GameObject Player;
    public GameObject GameOverUI;
    public Text ScoreText;
    public bool PlayerLife = true;
    private float TimeScore = 0;

	void Start () 
    {
	    
	}
	
	void Update () 
    {
        if (GameObject.Find("UIManager").GetComponent<UIScript>().StartTrigger)
        {
            if (!PlayerLife)
            {
                Destroy(Player);
                GameOverUI.SetActive(!PlayerLife);
            }

            else
            {
                TimeScore += Time.deltaTime;
                ScoreText.text = "Music Continued : " + Convert.ToInt32(TimeScore) + "초";
            }
        }
	}
}
