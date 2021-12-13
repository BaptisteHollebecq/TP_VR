using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenuQuit : MonoBehaviour
{
    public bool menu = false;

    public void Activate()
    {
        if (!menu)
            SceneManager.LoadScene(0);
        else
            Application.Quit();
    }
}
