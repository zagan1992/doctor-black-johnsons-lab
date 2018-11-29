using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public GameObject canvasMenu;
    public GameObject canvasHistoria;
    public GameObject canvasCreditos;

    public void loadScene(string cena)
    {
        SceneManager.LoadScene(cena);
    }

    public void openCredits()
    {
        canvasMenu.SetActive(false);
        canvasCreditos.SetActive(true);
    }

    public void closeCredits()
    {
        canvasMenu.SetActive(true);
        canvasCreditos.SetActive(false);
    }

    public void openHistory()
    {
        canvasMenu.SetActive(false);
        canvasHistoria.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
