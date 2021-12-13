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

    private void Awake()
    {
        actionReference.action.Enable();
        menu.SetActive(false);
    }

    void Update()
    {

        if (actionReference != null && actionReference.action != null)
        {
            bool value = actionReference.action.ReadValue<bool>();
            if (value && !isShown)
            {
                isShown = true;
                menu.SetActive(true);
            }
            else
            {
                isShown = false;
                menu.SetActive(false);
            }
        }
    }
}
