using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 1.5f)] private float fireRate = 0.3f;
    [SerializeField] [Range(1, 10)] private int damage = 1;
    // [SerializeField] private Transform firePoint;
    [SerializeField] private AudioSource gunFireSource;
    [SerializeField] private ParticleSystem muzzelParticle;


    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                FireGun();
            }
        }
    }

    private void FireGun()
    {
        muzzelParticle.Play();
        gunFireSource.Play();

        // Ray ray = new Ray(firePoint.position, firePoint.forward);
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            // Destroy(hitInfo.collider.gameObject);
            var health = hitInfo.collider.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
                // Debug.Log("making damage");
            }
        }
    }
}
