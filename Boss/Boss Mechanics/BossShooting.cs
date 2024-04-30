using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    [SerializeField] GameObject laser;
    [SerializeField] Transform canonPos1;
    [SerializeField] Transform canonPos2;
    [SerializeField] Transform canonPos3;
    private int shootPoint = 0;
    public bool shootingTime;
    private float shootingTimer;
    [SerializeField] float fireRate;
    public Boundaries boundaries;
    [SerializeField] AudioSource shootSoundEffect;

    void Update()
    {
        if (GameManager.instance.gameOver == true || boundaries.InFrame == false)
        {
            return;
        }
        if (shootingTime)
        {
            shootingTimer += Time.deltaTime;
            if (shootingTimer >= fireRate)
            {
                ShootLaser();
                shootingTimer = 0;
            }
        }
    }

    private void ShootLaser()
    {
        if (shootPoint == 0)
        {
            Shoot();
        }
        else if (shootPoint == 1)
        {
            Shoot2();
        }
        else if (shootPoint == 2)
        {
            Shoot3();
        }
        shootPoint++;
        if (shootPoint >= 3)
        {
            shootPoint = 0;
        }
    }

    void Shoot()
    {
        Instantiate(laser, canonPos1.position, Quaternion.identity);
        shootSoundEffect.Play();
    }
    void Shoot2()
    {
        Instantiate(laser, canonPos2.position, Quaternion.identity);
        shootSoundEffect.Play();
    }
    void Shoot3()
    {
        Instantiate(laser, canonPos3.position, Quaternion.identity);
        shootSoundEffect.Play();
    }
}

