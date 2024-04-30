using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
