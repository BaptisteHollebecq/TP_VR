using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIMenu : MonoBehaviour
{
    public GameObject menu;

    [SerializeField]
    private InputActionReference m_ActionReference;

    public InputActionReference actionReference { get => m_ActionReference; set => m_ActionReference = value; }

    private bool isShown = false;
    private bool canPress = true;

    private void Awake()
    {
        actionReference.action.Enable();
        menu.SetActive(false);
    }

    void Update()
    {

        if (actionReference != null && actionReference.action != null)
        {
            float value = actionReference.action.ReadValue<float>();
            if (value > .99f && canPress)
            {
                if (!isShown)
                {
                    canPress = false;
                    isShown = true;
                    menu.SetActive(true);
                }
                else
                {
                    canPress = false;
                    isShown = false;
                    menu.SetActive(false);
                }
            }
            if (value < .5f && !canPress)
                canPress = true;
        }
    }
}
