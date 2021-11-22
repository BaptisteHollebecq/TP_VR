using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public GameObject fire;
    public Light torchLight;

    public bool On = true;
    public float maxIntesity = 1.5f;
    public float minIntesity = 0.5f;

    private float baseIntensity;

    private void Start()
    {
        if (!On)
        {
            torchLight.enabled = false;
            fire.SetActive(false);
        }
        else
        {
            baseIntensity = torchLight.intensity;
            StartCoroutine(DoFlicker());
        }
    }

    public void Switch()
    {
        if (!On)
        {
            On = true;
            torchLight.enabled = true;
            fire.SetActive(true);
            baseIntensity = torchLight.intensity;
            StartCoroutine(DoFlicker());
        }
        else
        {
            On = false;
            torchLight.enabled = false;
            fire.SetActive(false);
            StopCoroutine(DoFlicker());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Light")
        {
            Torch t = other.transform.parent.GetComponent<Torch>();
            if (t != this)
                t.Switch();
        }
    }

    private IEnumerator DoFlicker()
    {
        while (true)
        {
            torchLight.intensity = Mathf.Lerp(torchLight.intensity, Random.Range(baseIntensity - minIntesity, baseIntensity + maxIntesity), 300 * Time.deltaTime);
            yield return new WaitForSeconds(.1f);
        }
    }

}
