
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Image healthbarSprite;

    public void UpdateHealthBar(float maxPlayerHealth, float playerHealth)
    {
        healthbarSprite.fillAmount = playerHealth / maxPlayerHealth;
    }
}