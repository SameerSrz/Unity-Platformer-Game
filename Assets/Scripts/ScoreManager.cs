using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    #region "SingleTon" 
    public static ScoreManager Instance;
    #endregion
    public Text DisplayCrates;
    public int currentCrates;
    

    void Awake()
    {
        Instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("TotalCrates"))
        {
            currentCrates = PlayerPrefs.GetInt("TotalCrates");
        }
        DisplayCrates.text = ""+currentCrates;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setCrates()
    {
        currentCrates++;
       
        PlayerPrefs.SetInt("TotalCrates", currentCrates);
        
        DisplayCrates.text = ""+currentCrates;
    }

}
