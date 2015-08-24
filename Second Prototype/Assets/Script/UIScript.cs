using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour {

    public Animator SoundOnOffBool;
    public GameObject[] MainMenu;
    public GameObject PlayerUI;
    public GameObject StartUI;
    public GameObject HowToPlayUI;
    public GameObject SettingUI;
    public GameObject CreditUI;
    public GameObject MenuUI;
    public AudioSource Music;
    public bool Trigger = false;
    public bool StartTrigger = false;
    private float distance;

	void Start () 
    {
        
	}

    public void GetStart()
    {
        Time.timeScale = 1;
        StartUI.SetActive(StartTrigger);
        StartTrigger = !StartTrigger;
        PlayerUI.SetActive(StartTrigger);
    }

    public void HowToPlay()
    {
        Trigger = !Trigger;
        HowToPlayUI.SetActive(Trigger);

        for (int i = 0; i < MainMenu.Length; i++)
            MainMenu[i].SetActive(!Trigger);
    }

    public void Setting()
    {
        Trigger = !Trigger;
        SettingUI.SetActive(Trigger);

        for (int i = 0; i < MainMenu.Length; i++)
            MainMenu[i].SetActive(!Trigger);
    }

    public void Credit()
    {
        Trigger = !Trigger;
        CreditUI.SetActive(Trigger);

        for (int i = 0; i < MainMenu.Length; i++)
            MainMenu[i].SetActive(!Trigger);
    }

    public void Menu()
    {
        Trigger = !Trigger;
        MenuUI.SetActive(Trigger);

        if (Trigger)
        {
            Time.timeScale = 0;
            Music.Stop();
        }
       
        else
            Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public AudioSource Sound;
    public int volume = 100;

    public void Home()
    {
        Time.timeScale = 1;
        Application.LoadLevel("0");
    }

    public void SoundOnOff()
    {
        volume = -1 * volume;
        Sound.volume += volume;

        if (Sound.volume > 0)
            SoundOnOffBool.Play("Normal");
        else
            SoundOnOffBool.Play("Pressed");
    }

    public void Restart()
    {
        GameObject.Find("UIManager").GetComponent<UIScript>().StartTrigger = true;
        Application.LoadLevel("0"); 
    }
}