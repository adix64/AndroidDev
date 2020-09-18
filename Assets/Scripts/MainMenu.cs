using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    //fiecre functie este un callback atasat butonului corespunzator din scena meniu
    public void Open3rdPersonArena()
    {
        SceneManager.LoadScene("3rdPersonArena");
    }

    public void OpenTextButtonSelection()
    {
        SceneManager.LoadScene("TextButtonSelection");
    }

    public void OpenTextTouchSelection()
    {
        SceneManager.LoadScene("TextTouchSelection");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
