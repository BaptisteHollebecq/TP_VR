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
            Debug.Log("ground");

            Vector3 position = collision.contacts[0].point;
            position.y += height;

            playerRig.transform.position = position;
            if (handController.LeftHand.Object != null)
            {
                if (handController.LeftHand.Object.TryGetComponent<Torch>(out Torch t))
                {
                    if (t.On)
                        t.Switch();
                }
            }

            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Water")
        {
            waterTouched = true;
        }

    }
}
