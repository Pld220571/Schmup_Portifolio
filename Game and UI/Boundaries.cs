using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 _screenBounds;
    public bool InFrame;
    
    private void Update()
    {
        if (InFrame == true)
        {
            GetBounds();
        }
    }

    private void LateUpdate()
    {
        if (InFrame == true)
        {
            CheckBorder();
        }
    }

    private void GetBounds()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void CheckBorder()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.1f, 0.95f);
        pos.y = Mathf.Clamp(pos.y, 0.1f, 0.9f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
