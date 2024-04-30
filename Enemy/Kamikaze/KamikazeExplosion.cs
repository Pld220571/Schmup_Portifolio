using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeExplosion : MonoBehaviour
{
    public GameObject exp;
    public float countdown;
    public float delay;
    public float expForce, radius;
    public Boundaries boundaries;
    public ParticleSystem explosion;

    //Score
    [SerializeField] private GameManager game;
    [SerializeField] private int points;

    private void Start()
    {
        countdown = delay;
    }

    private void Update()
    {
        if (boundaries.InFrame == true)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0f)
            {
                Explosion();
            }
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
            //Score
            game.AddScore(points);
            Explosion();
        }
    }

    void Explosion()
    {
        //GameObject _exp = Instantiate(exp, transform.position, transform.rotation);
        Instantiate(explosion, transform.position, transform.rotation);
        //explosion.Play();
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
