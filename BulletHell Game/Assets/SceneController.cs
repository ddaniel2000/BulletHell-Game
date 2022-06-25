using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("StartGame");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

}
