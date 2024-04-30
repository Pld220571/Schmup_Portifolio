using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] private float force;
    private Rigidbody rb;

    void Start()
    {
        Destroy(gameObject, 4f);
        rb = GetComponent<Rigidbody>();
        GameManager.instance.player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = GameManager.instance.player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}

