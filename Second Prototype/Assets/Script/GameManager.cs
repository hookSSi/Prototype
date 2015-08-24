using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public System.IO.DirectoryInfo di;
    public FileInfo[] info;
    public GameObject PlayerUI;
    public GameObject Player;
    public GameObject GameOverUI;
    public Text ScoreText;
    public Text FinalScore;
    public bool PlayerLife = true;
    public bool[] MusicBool;
    public AudioSource Music;
    public WWW ReadMusic;
    public string[] FileName;
    private string SongPath;
    public string Path;
    private float TimeScore = 0;
    private float WT = 0;
    LinkedListNode<WWW> MusicNode;


    void Start()
    {
        
        MusicInit();
        MusicBool[0] = true;
        MusicBool[1] = true;
    }

    void Update()
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
                FinalScore.text = "Music Continued : " + (int)TimeScore + "초";
            }

            else if (Music.volume != 0)
            {
                TimeScore += Time.deltaTime;
                ScoreText.text = "Music Continued : " + (int)TimeScore + "초";
            }

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

    public void MusicInit()
    {
        Path = "/storage/external_SD/CRWM/Music/";

        int i = 0;

        di = new System.IO.DirectoryInfo(Path);

        if(di.Exists == false)
        {
            di.Create();
        }

        info = di.GetFiles("*.mp3");
        FileName = new string[info.Length];

        foreach (System.IO.FileInfo f in di.GetFiles("*.mp3"))
        {
            FileName[i] = f.Name;
            i++;
        }

        StartCoroutine("MusicSelect");
    }

    IEnumerator MusicSelect()
    {
        
            SongPath = Path + FileName[Random.Range(0, FileName.Length)];
            ReadMusic = new WWW("file://" + SongPath);
            Debug.Log(SongPath);    

            yield return ReadMusic;
            
            Music.clip = ReadMusic.audioClip;
            Music.Play();
            Debug.Log(2);
            yield return new WaitForSeconds(Music.clip.length);
            Debug.Log(3);
            StartCoroutine("MusicSelect");
    }

      WWW NodeAdd()
    {
        return MusicNode.Value;
    }
}