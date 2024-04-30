using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    public bool inFrame;

    private void Update()
    {
        if (inFrame == true)
        {
            GetBounds();
        }
    }

    private void LateUpdate()
    {
        if (inFrame == true)
        {
            CheckBorder();
        }
    }

    private void GetBounds()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void CheckBorder()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.58f, 0.95f);
        pos.y = Mathf.Clamp(pos.y, 0.15f, 0.85f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
