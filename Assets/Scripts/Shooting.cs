using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 30f;
    public float fireRate = 1.5F;
    private float nextFire = 0.0F;

    private AudioSource audioSource;
    public AudioClip shootClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        int i = 0;
        while(i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            if (Time.time > nextFire && t.position.x > Screen.width / 2)
            {
                nextFire = Time.time + fireRate;
                Shoot();
            }
            i++;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        audioSource.clip = shootClip;
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.Play();
    }
}
