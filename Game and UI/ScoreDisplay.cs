using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    private GameManager game;
    private TextMeshProUGUI textfield;

    private void Awake()
    {
        game = FindObjectOfType<GameManager>();
        textfield = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateScoreDisplay()
    {
        textfield.text = game.GetScore().ToString();
    }
}
