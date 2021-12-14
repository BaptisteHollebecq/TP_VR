using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public static event System.Action<bool> TriggerPressed;
    public static event System.Action Trigger;

    [SerializeField]
    private InputActionReference m_ActionReference;
    [SerializeField]
    private InputActionReference M_MenuReference;

    public InputActionReference actionReference { get => m_ActionReference; set => m_ActionReference = value; }
    public InputActionReference menuReference { get => M_MenuReference; set => M_MenuReference = value; }

    public GameObject PlayerRig;
    public GameObject Orb;

    bool pressed = false;
    bool menu = false;
    bool canPress = true;

    private void Awake()
    {
        actionReference.action.Enable();
        menuReference.action.Enable();
    }


    void Update()
    {
        if (actionReference != null && actionReference.action != null)
        {
            float value = actionReference.action.ReadValue<float>();
            if (!menu)
            {
                if (value > 0.9f)
                {
                    pressed = true;
                    TriggerPressed?.Invoke(true);
                }
                if (value < .05f && pressed)
                {
                    pressed = false;
                    TriggerPressed?.Invoke(false);
                    var inst = Instantiate(Orb, transform.position, Quaternion.identity);
                    Orb b = inst.GetComponent<Orb>();

                    b.height = PlayerRig.transform.position.y;
                    b.playerRig = PlayerRig;
                    b.handController = PlayerRig.GetComponent<HandsController>();
                    Vector3 direction = transform.GetChild(0).transform.forward;
                    b.Shoot(direction);
                }
            }
            else
            {
                if (value > 0.9f && !pressed)
                {
                    Trigger?.Invoke();
                }
            }
        }

        if (menuReference != null && menuReference.action != null)
        {
            float valueb = menuReference.action.ReadValue<float>();
            if (valueb > .99f && canPress)
            {
                canPress = false;
                if (!menu)
                {
                    menu = true;
                    TriggerPressed?.Invoke(true);
                }
                else
                {
                    menu = false;
                    TriggerPressed?.Invoke(false);
                }
            }
            else if (valueb < .5f)
            {
                canPress = true;
            }
        }
    }

}

