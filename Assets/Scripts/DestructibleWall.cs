using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    public float timeBeforeDecay = 4;
    public List<Rigidbody> wallParts = new List<Rigidbody>();

    public void Explode(Vector3 position, float power, float radius)
    {
        foreach(Rigidbody rb in wallParts)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
            //position.y += 1;
            rb.AddExplosionForce(power, position, radius);
            Destroy(rb.gameObject, timeBeforeDecay);
        }
    }
}
