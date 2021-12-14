using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaguetteMagique : MonoBehaviour
{
    ButtonChangeLevel changeLevel = null;
    ButtonMenuQuit menuQuit = null;

    private void Awake()
    {
        Movement.Trigger += Pressed;
    }

    private void OnDestroy()
    {
        Movement.Trigger -= Pressed;
        
    }

    private void Pressed()
    {
        if (changeLevel != null)
        {
            changeLevel.Activate();
        }
        else if (menuQuit != null)
        {
            menuQuit.Activate();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<ButtonChangeLevel>(out ButtonChangeLevel bcl))
        {
            changeLevel = bcl;
            collision.gameObject.GetComponent<Image>().color = Color.red;
        }
        if (collision.gameObject.TryGetComponent<ButtonMenuQuit>(out ButtonMenuQuit bmq))
        {
            menuQuit = bmq;
            collision.gameObject.GetComponent<Image>().color = Color.red;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<ButtonChangeLevel>(out ButtonChangeLevel bcl))
        {
            changeLevel = null;
            collision.gameObject.GetComponent<Image>().color = Color.white;
        }
        if (collision.gameObject.TryGetComponent<ButtonMenuQuit>(out ButtonMenuQuit bmq))
        {
            menuQuit = null;
            collision.gameObject.GetComponent<Image>().color = Color.white;
        }
    }
}
