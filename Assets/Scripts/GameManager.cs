using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region     "Instance"
    public static GameManager Instance;

    public void Awake()
    {
        Instance = this;
    }
    #endregion

    public GameObject Player;
    public GameObject[] Enemies;
    public GameObject StartMenu;
    public GameObject GameOverPanel;
    public Image HealthBar;
    public GameObject deathEffect_2;
    public GameObject HealthBarFiller;

    //public bool isGameOver = false;

    public bool IsGameplay;
    // Start is called before the first frame update
    void Start()
    {
        //IsGameplay = true;
        if(IsGameplay)
        {
            SoundManager.PlayMusic(SoundManager.Instance.musicsGame);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void GameOver()
    {
        if(IsGameplay==false)
        {
            Time.timeScale = 0f;
            GameOverPanel.SetActive(true);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void HealthBarColor()
    {
        //HealthBar.GetComponent<Renderer>().material.SetColor("_color", Color.black);
        HealthBar.GetComponent<Image>().color = new Color(0,0,0,25);
        HealthBarFiller.SetActive(false);
    }
    public void PlayButton()
    {
        IsGameplay = true;
        StartMenu.SetActive(false);
        Player.SetActive(true);
        for(int i=0; i <Enemies.Length;i++)
        {
            Enemies[i].SetActive(true);
        }
    }



}
