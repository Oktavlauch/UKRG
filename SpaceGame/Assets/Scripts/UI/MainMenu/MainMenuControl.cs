using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public bool IsInOptions = false;
    public bool IsInCareer = false;
    public GameObject MainMenuUI;
    public GameObject OptionsMenuUI;
    public GameObject CareerSelectionUI;


    public void CareerSelection()
    {
        IsInCareer = true;
        MainMenuUI.SetActive(false);
        CareerSelectionUI.SetActive(true);
    }

    public void LoadSandbox()
    {
        //SceneManager.LoadScene("SampleScene");
        Debug.Log("Sorry, we don't support Sandbox yet!");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && IsInOptions)
        {
            IsInOptions = false;
            OptionsMenuUI.SetActive(false);
            MainMenuUI.SetActive(true);
        }      

        if (Input.GetKeyDown(KeyCode.Escape) && IsInCareer)
        {
            IsInCareer = false;
            MainMenuUI.SetActive(true);
            CareerSelectionUI.SetActive(false);
        }  
    }

    public void Options()
    {
        IsInOptions = true;
        MainMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(true);
    }

    public void Back()
    {
        if (IsInOptions)
        {
            IsInOptions = false;
            OptionsMenuUI.SetActive(false);
            MainMenuUI.SetActive(true);
        }

        else if (IsInCareer)
        {
            IsInCareer = false;
            MainMenuUI.SetActive(true);
            CareerSelectionUI.SetActive(false);
        }
        
    }
}
