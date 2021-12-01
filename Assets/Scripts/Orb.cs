using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public GameObject playerRig;
    public HandsController handController;
    public float height = 1.65f;
    public float Power = 10f;

    private Rigidbody _rb;
    public bool waterTouched = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Shoot(Vector3 direction)
    {
        _rb.AddForce(direction * Power, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

            Vector3 position = collision.contacts[0].point;
            position.y += height;

            playerRig.transform.position = position;
            if (waterTouched)
            {
                GrabManager gm = playerRig.GetComponent<GrabManager>();
                if (gm.leftHand.inHand != null && gm.leftHand.grip)
                {
                    if (gm.leftHand.inHand.TryGetComponent<Torch>(out Torch t))
                    {
                        if (t.On)
                            t.Switch();
                    }
                }
                if (gm.rightHand.inHand != null && gm.rightHand.grip)
                {
                    if (gm.rightHand.inHand.TryGetComponent<Torch>(out Torch t))
                    {
                        if (t.On)
                            t.Switch();
                    }
                }
            }
            Destroy(gameObject);
        }

    }
}
