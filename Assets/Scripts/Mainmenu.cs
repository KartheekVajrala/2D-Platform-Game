using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour {
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void play2()
    {
        SceneManager.LoadScene(2);
    }
    public void play3()
    {
        SceneManager.LoadScene(3);
    }
    public void play4() { SceneManager.LoadScene(4); }
    public void quitgame()
    {
        Application.Quit();
    }
}
