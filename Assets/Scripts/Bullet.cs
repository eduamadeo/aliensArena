using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody bullet;
    public float destructionTime = 6.0f;
    public GameObject explosionParticlesPrefab;

    private void Start()
    {
        bullet = GetComponent<Rigidbody>();
        Destroy(gameObject, destructionTime);
    }

    private void Update()
    {
        if(bullet.position.y > 7.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
        {
            if (explosionParticlesPrefab)
            {
                GameObject explosion = (GameObject)Instantiate(explosionParticlesPrefab, transform.position, explosionParticlesPrefab.transform.rotation);
                Destroy(explosion, explosion.GetComponent<ParticleSystem>().main.startLifetimeMultiplier);
            }
            Destroy(gameObject);
        }
    }
}
