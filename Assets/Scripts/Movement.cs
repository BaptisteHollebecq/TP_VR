using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private InputActionReference m_ActionReference;
    public InputActionReference actionReference { get => m_ActionReference; set => m_ActionReference = value; }

    public GameObject PlayerRig;
    public GameObject Orb;

    bool pressed = false;

    private void Awake()
    {
        actionReference.action.Enable();
    }

    void Update()
    {
        if (actionReference != null && actionReference.action != null)
        {
            float value = actionReference.action.ReadValue<float>();
            if (value > 0.9f)
                pressed = true;
            if (value < .05f && pressed)
            {
                pressed = false;
                var inst = Instantiate(Orb, transform.position, Quaternion.identity);
                Orb b = inst.GetComponent<Orb>();

                b.height = PlayerRig.transform.position.y;
                b.playerRig = PlayerRig;
                b.handController = PlayerRig.GetComponent<HandsController>();
                Vector3 direction = transform.GetChild(0).transform.forward;
                b.Shoot(direction);
            }
        }
    }

}

