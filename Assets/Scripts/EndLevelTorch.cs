using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelTorch : MonoBehaviour
{
    public GameObject Fire;
    public Light torchLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Light")
        {
            Torch t = other.transform.parent.GetComponent<Torch>();
            if (t.On)
            {
                Fire.SetActive(true);
                torchLight.enabled = true;

                //FIn du level
                StartCoroutine(EndLevel());
            }
        }
    }

    IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Success");
    }
}
