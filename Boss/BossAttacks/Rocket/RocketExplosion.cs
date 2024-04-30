using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplosion : MonoBehaviour
{
    [SerializeField] ParticleSystem explosion;
    [SerializeField] float delay;
    [SerializeField] float expForce;
    [SerializeField] float radius;
    public Boundaries boundaries;

    void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0f)
        {
            Explosion();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Explosion();
        }

        if (collision.gameObject.tag == "PlayerBullet")
        {
            Explosion();
        }
    }

    void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        knockBack();
    }

    void knockBack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearby in colliders)
        {
            Rigidbody rigg = nearby.GetComponent<Rigidbody>();
            if (rigg != null)
            {
                rigg.AddExplosionForce(expForce, transform.position, radius);
            }
        }
    }
}
