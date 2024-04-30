using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //Health
    [SerializeField] private int enemyHealth;

    //Score
    [SerializeField] private GameManager game;
    [SerializeField] private int points;

    private void Awake()
    {
        game = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyHealth--;            
        }

        if (collision.gameObject.tag == "PlayerBullet")
        {
            enemyHealth--;
        }

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            enemyHealth--;

            //Score
            game.AddScore(points);
        }
    }
}
