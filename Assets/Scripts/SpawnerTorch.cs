using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTorch : MonoBehaviour
{
    public Transform spawner;
    public GameObject Torch;
    public float respawnTime = 5;
    public int childcountTarget = 2;

    private bool respawning = false;

    private void Update()
    {
        if (transform.childCount != childcountTarget && !respawning)
        {
            respawning = true;
            StartCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnTime);

        var inst = Instantiate(Torch, spawner.position, spawner.rotation);
        inst.transform.SetParent(transform);
        Rigidbody rb = inst.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = true;

        respawning = false;
    }
}
