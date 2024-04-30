using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
#region
{
    public BossHealth bossHealth;
    public BossShooting bossShooting;
    [SerializeField] float rocketCondition;
    [SerializeField] int rocketShootPoint = 0;
    [SerializeField] float rocketFireRate;
    [SerializeField] float deactivationTimer;
    [SerializeField] bool rocketsLaunched;
    [SerializeField] GameObject rocket;
    [SerializeField] Transform rocketSpawner1;
    [SerializeField] Transform rocketSpawner2;
    [SerializeField] Coroutine shooter;

    #endregion
    void Start()
    {
        rocketsLaunched = false;
    }

    void Update()
    {
        if (bossHealth.enemyHealth <= rocketCondition && rocketsLaunched == false)
        {
            bossShooting.shootingTime = false;
            if (bossShooting.shootingTime == false)
            {
                if (shooter == null)
                {
                    StartCoroutine(DeactivateRocketSpawner());
                    shooter = StartCoroutine(ActivateRocketSpawner());
                }
            }
        }
        if (bossHealth.enemyHealth <= rocketCondition && rocketsLaunched)
        {
            bossShooting.shootingTime = true;
            StopAllCoroutines();            
        }
    }

    private void ShootRocket()
    {
        if (rocketShootPoint == 0)
        {
            Rocket1();
        }
        else if (rocketShootPoint == 1)
        {
            Rocket2();
        }

        rocketShootPoint++;
        if (rocketShootPoint >= 2)
        {
            rocketShootPoint = 0;
        }
    }

    private void Rocket1()
    {
        Instantiate(rocket, rocketSpawner1.position, Quaternion.identity);
    }
    private void Rocket2()
    {
        Instantiate(rocket, rocketSpawner2.position, Quaternion.identity);
    }

    private IEnumerator ActivateRocketSpawner()
    {
        while (true)
        {
            ShootRocket();
            yield return new WaitForSeconds(rocketFireRate);
        }
    }

    private IEnumerator DeactivateRocketSpawner()
    {
        yield return new WaitForSeconds(deactivationTimer);
        rocketsLaunched = true;
        shooter = null;
    }
}



//Quaternion rocketRotation = new Quaternion(0, 0, 90, 0);