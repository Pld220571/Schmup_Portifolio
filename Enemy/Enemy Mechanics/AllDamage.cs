using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDamage : MonoBehaviour
{
    public PlayerHealth ph;
    public ScreenShake screenShake;

    private void Start()
    {
        ph = FindObjectOfType<PlayerHealth>();
        screenShake = FindObjectOfType<ScreenShake>();
    }

    public void TakeDamage(int damage)
    {
        screenShake.startScreenShake = true;
        ph.playerHealth -= damage;
    }
}
