using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelTorch : MonoBehaviour
{
    public GameObject Fire;
    public Light torchLight;
    public float waitingtime = 1;

    public bool endGame = false;

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
        yield return new WaitForSeconds(waitingtime);
        if (!endGame)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(0);
    }
}
