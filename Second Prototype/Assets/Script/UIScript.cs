using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour {

    public GameObject PlayerUI;
    public GameObject StartUI;
    public GameObject HowToPlayUI;
    public GameObject SetUpUI;
    public GameObject CreditUI;
    public GameObject MenuUI;
    public bool Trigger = false;
    public bool StartTrigger = false;

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

    public void SetUp()
    {
        Trigger = !Trigger;
        SetUpUI.SetActive(Trigger);
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
    }
}
