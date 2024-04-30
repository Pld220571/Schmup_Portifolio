using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankyHealth : MonoBehaviour
{
    public Boundaries boundaries;

    //Health
    [SerializeField] private EnemyHealthBar enemyHealthBar;
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;

    //Score
    [SerializeField] private GameManager game;
    [SerializeField] private int points;

    [SerializeField] private Object healthPowerup;
    [SerializeField] private Object shieldPowerup;
    private float randomNumber;

    public ParticleSystem boom;

    private void Start()
    {
        health = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            if (boundaries.InFrame == true)
            {
                health--;
                enemyHealthBar.UpdateHealthBar(maxHealth, health);
            }
        }

        if (health <= 0)
        {
            //Score
            game.AddScore(points);
            Instantiate(boom, transform.position, transform.rotation);
            SpawnPowerup();

            Destroy(gameObject);
        }
    }

    private void SpawnPowerup()
    {
        randomNumber = Random.Range(0f, 1f);
        Debug.Log(randomNumber);
        if (randomNumber < 0.35f)
        {
            Instantiate(healthPowerup, transform.position, transform.rotation);
        }
        if (randomNumber > 0.65)
        {
            Instantiate(shieldPowerup, transform.position, transform.rotation);
        }
        else
        {
            return;
        }
    }
}