using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int enemyHealth;
    [SerializeField] private int enemyMaxHealth;
    [SerializeField] private GameManager game;

    private void Start()
    {
        enemyHealth = enemyMaxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            enemyHealth--;
        }

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            game.ReportBossDeath();
        }
    }
}
