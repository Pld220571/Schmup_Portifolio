using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] float fireRate;
    [SerializeField] private float fireBurstRate;
    [SerializeField] private int bulletAmount;
    private float fireTime;
    public GameObject laser;
    public Transform laserPos;    
    public Boundaries boundaries;
    [SerializeField] private AudioSource shootSoundEffect;

    void Update()
    {
        if (GameManager.instance.gameOver == true || boundaries.InFrame == false)
        {
            return;
        }

        fireTime += Time.deltaTime;
        if (fireTime >= fireRate)
        {
            fireTime = 0;
            StartCoroutine(FireBurst());
        }
    }

    private IEnumerator FireBurst()
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            Shoot();
            yield return new WaitForSeconds(fireBurstRate);
        }

        void Shoot()
        {
            Instantiate(laser, laserPos.position, Quaternion.identity);
            shootSoundEffect.Play();
        }
    }
}
