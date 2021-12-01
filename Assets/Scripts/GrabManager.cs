using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrabManager : MonoBehaviour
{
    public Grab leftHand;
    public Grab rightHand;


    public void Death()
    {
        // WHALLA FAIRE LES MENU
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
