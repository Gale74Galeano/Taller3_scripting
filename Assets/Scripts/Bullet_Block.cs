using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Block : MonoBehaviour
{
    private float speed = 20f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.left * speed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collider"))
        {
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            ObjectPool.instance.canShoot = false;
            ObjectPool.instance.EnableShoot(collision.gameObject);
            ObjectPool.instance.DisableBullets();

        }

        if (collision.gameObject.CompareTag("Limits"))
        {
            gameObject.SetActive(false);

        }
    }

    
}
