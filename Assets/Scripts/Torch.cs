using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public GameObject fire;
    public Light torchLight;
    public Collider sphere;

    public bool On = true;
    public bool dinamite = false;
    public float timeBeforeExplosion = 3f;
    public float explosionRadius = 2f;
    public float explosionForce = 50f;

    Coroutine explosion;

    private void Start()
    {
        if (dinamite)
            On = false;
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
            if (dinamite)
                explosion = StartCoroutine(CavaPeter());
        }
        else
        {
            On = false;
            torchLight.enabled = false;
            fire.SetActive(false);
            if (dinamite && explosion != null)
                StopCoroutine(explosion);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Light")
        {
            Torch t = other.transform.parent.GetComponent<Torch>();
            if (On)
            {
                if (t != this && !t.On)
                    t.Switch();
            }
            else
            {
                if (t != this && t.On)
                    Switch();
            }

        }
    }

    IEnumerator CavaPeter()
    {
        yield return new WaitForSeconds(timeBeforeExplosion);
        Explode();
    }

    private void Explode()
    {
        Collider[] touched = Physics.OverlapSphere(transform.position, explosionRadius);
        if (touched.Length > 0)
        {
            foreach(var item in touched)
            {
                if (item.gameObject.TryGetComponent<DestructibleWall>(out DestructibleWall dw))
                {
                    dw.Explode(transform.position, explosionForce, explosionRadius + 1);
                }
                if (item.gameObject.TryGetComponent<GrabManager>(out GrabManager gm))
                {
                    gm.Death();
                }
            }
        }
         
        Destroy(gameObject);
    }
}
