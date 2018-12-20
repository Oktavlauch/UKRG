using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public bool IsInOptions = false;
    public GameObject MainMenuUI;
    public GameObject OptionsMenuUI;


    public void LoadCareer()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadSandbox()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && IsInOptions)
        {
            OptionsMenuUI.SetActive(false);
            MainMenuUI.SetActive(true);
            IsInOptions = false;
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
        IsInOptions = false;
        OptionsMenuUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }
}
