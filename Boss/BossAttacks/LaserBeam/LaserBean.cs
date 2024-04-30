using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LaserBean : MonoBehaviour
#region
{
    [SerializeField] BossHealth bossHealth;
    [SerializeField] BossShooting bossShooting;
    [SerializeField] float beamCondition;
    [SerializeField] float chargeLimit;
    [SerializeField] float beamDischargeDuration;
    [SerializeField] bool beamDischarged;
    [SerializeField] GameObject laserBeam;
    [SerializeField] AudioSource chargeSoundEffect;
    #endregion

    void Start()
    #region
    {
        beamDischarged = false;
    }
    #endregion

    void Update()
    #region
    {
        if (bossHealth.enemyHealth <= beamCondition && beamDischarged == false)
        {
            bossShooting.shootingTime = false;
            if (chargeSoundEffect.isPlaying == false)
            {
                chargeSoundEffect.Play();
            }
            if (bossShooting.shootingTime == false)
            {
                StartCoroutine(ActivateLaserBeam());
            }
        }
        if (bossHealth.enemyHealth <= beamCondition && beamDischarged)
        {
            bossShooting.shootingTime = true;
            StopAllCoroutines();
        }
    }
    #endregion

    private IEnumerator ActivateLaserBeam()
    {
        yield return new WaitForSeconds(chargeLimit);
        laserBeam.SetActive(true);
        yield return new WaitForSeconds(beamDischargeDuration);
        laserBeam.SetActive(false);
        beamDischarged = true;
    }
}
