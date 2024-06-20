using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainPannel;
    public GameObject instructionsPannel;

    private void Awake()
    {
        instructionsPannel.SetActive(false);
        mainPannel.SetActive(true);
    }

    public void LoadlLevel(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }

    public void PanelHowToPlay()
    {
        mainPannel.SetActive(false);
        instructionsPannel.SetActive(true);
    }

    public void BackToMenu()
    {
        instructionsPannel.SetActive(false);
        mainPannel.SetActive(true);
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
