using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuControl : MonoBehaviour
{
    public bool IsInOptions = false;
    public bool IsInCareer = false;
    public GameObject MainMenuUI;
    public GameObject OptionsMenuUI;
    public GameObject CareerSelectionUI;
    public TextMeshProUGUI MissionsText;
    public string[] Missions = new string[100];
    public int MissSelected = 0;


    void Start()
    {
        for(int i = 0; i < 100; i++)
        {
            Missions[i] = "Mission" + i;
        }
        MissionsText.text = Missions[MissSelected];
    }

    //Load Career Selection
    public void CareerSelection()
    {
        IsInCareer = true;
        MainMenuUI.SetActive(false);
        CareerSelectionUI.SetActive(true);
    }

    //Choose Mission
    public void MissRight()
    {
        if(MissSelected < Missions.Length - 1)
        {
            MissionsText.text = Missions[(MissSelected += 1)];
        }     
    }

    //Choose Mission
    public void MissLeft()
    {
        if (MissSelected > 0)
        {
            MissionsText.text = Missions[MissSelected -= 1];
        }      
    }



    //Load Sandbox
    public void LoadSandbox()
    {
        //SceneManager.LoadScene("SampleScene");
        Debug.Log("Sorry, we don't support Sandbox yet!");
    }

    //Quit Application
    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        //Exit OptionMenu
        if (Input.GetKeyDown(KeyCode.Escape) && IsInOptions)
        {
            IsInOptions = false;
            OptionsMenuUI.SetActive(false);
            MainMenuUI.SetActive(true);
        }     
        
        //Exit Career Selection
        if (Input.GetKeyDown(KeyCode.Escape) && IsInCareer)
        {
            IsInCareer = false;
            MainMenuUI.SetActive(true);
            CareerSelectionUI.SetActive(false);
        }  
    }

    //Open Options
    public void Options()
    {
        IsInOptions = true;
        MainMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(true);
    }

    public void Back()
    {
        //Exit Options
        if (IsInOptions)
        {
            IsInOptions = false;
            OptionsMenuUI.SetActive(false);
            MainMenuUI.SetActive(true);
        }

        //Exit CareerSelection
        else if (IsInCareer)
        {
            IsInCareer = false;
            MainMenuUI.SetActive(true);
            CareerSelectionUI.SetActive(false);
        }
        
    }
}
