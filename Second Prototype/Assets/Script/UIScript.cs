using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour {

    public Animator SoundOnOffBool;
    public GameObject PlayerUI;
    public GameObject StartUI;
    public GameObject HowToPlayUI;
    public GameObject SettingUI;
    public GameObject CreditUI;
    public GameObject MenuUI;
    public bool Trigger = false;
    public bool StartTrigger = false;
    private float distance;

	void Start () 
    {
        
	}

    public void GetStart()
    {
        StartUI.SetActive(StartTrigger);
        StartTrigger = !StartTrigger;
        PlayerUI.SetActive(StartTrigger);
    }

    public void HowToPlay()
    {
        Trigger = !Trigger;
        HowToPlayUI.SetActive(Trigger);
    }

    public void Setting()
    {
        Trigger = !Trigger;
        SettingUI.SetActive(Trigger);
    }

    public void Credit()
    {
        Trigger = !Trigger;
        CreditUI.SetActive(Trigger);
    }

    public void Menu()
    {
        Trigger = !Trigger;
        MenuUI.SetActive(Trigger);

        if (Trigger)
            Time.timeScale = 0;
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
        Time.timeScale = 1;
        Application.LoadLevel("0"); 
    }
}