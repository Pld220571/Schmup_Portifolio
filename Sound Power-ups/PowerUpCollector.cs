using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollector : MonoBehaviour
{
    [SerializeField] private AudioSource healSoundEffect;
    [SerializeField] private AudioSource shieldSoundEffect;
    [SerializeField] private AudioSource fireRateSoundEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("HealthPowerup"))
        {
            healSoundEffect.Play();
        }

        if (collision.gameObject.CompareTag("Shield"))
        {
            shieldSoundEffect.Play();
        }

        if (collision.gameObject.CompareTag("FireRate"))
        {
            fireRateSoundEffect.Play();
        }
    }
}