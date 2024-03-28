using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("WorkingButton");
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
