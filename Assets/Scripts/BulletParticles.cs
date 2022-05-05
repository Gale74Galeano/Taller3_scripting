using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticles : MonoBehaviour
{
    private float speed = 20f;

    private Rigidbody rb;
    private MeshRenderer mesh;
    private CapsuleCollider colCap;
    private ParticleSystem particles;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        particles = GetComponentInChildren<ParticleSystem>();
        mesh = GetComponentInChildren<MeshRenderer>();
        colCap = GetComponentInChildren<CapsuleCollider>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.left * speed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collider"))
        {
            particles.Play();
            mesh.enabled = false;
            colCap.enabled = false;
            StartCoroutine(DisableBullet());
        }

        if (collision.gameObject.CompareTag("Limits"))
        {
            gameObject.SetActive(false);

        }
    }

    IEnumerator DisableBullet()
    {
        yield return new WaitForSeconds(0.3f);
        particles.Stop();
        gameObject.SetActive(false);
        mesh.enabled = true;
        colCap.enabled = true;
    }
}
