using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public GameObject fire;
    public Light torchLight;

    public bool On = true;

    private void Start()
    {
        if (!On)
        {
            torchLight.enabled = false;
            fire.SetActive(false);
        }
    }

    public void Switch()
    {
        if (!On)
        {
            On = true;
            torchLight.enabled = true;
            fire.SetActive(true);
        }
        else
        {
            On = false;
            torchLight.enabled = false;
            fire.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Light")
        {
            other.transform.parent.GetComponent<Torch>().Switch();
        }
    }

}
