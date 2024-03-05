using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed;
    private Vector3 direction = Vector3.zero;
    public Boundaries boundaries;
    private bool running = false;

    private void Update()
    {
        if (boundaries.InFrame == true && !running)
        {
            StartCoroutine(changeDirection(0.3f));
        }

        transform.position += direction * speed;
    }

    IEnumerator changeDirection(float timer)
    {
        running = true;
        yield return new WaitForSeconds(timer);
        direction.x = Random.Range(-0.19f, 0.88f);
        direction.y = Random.Range(-0.4f, 0.4f);
        running = false;
    }
}


//if (Time.timeScale == 0)
//{
//    speed = 0;
//}
//else
//{
//    speed = 4f;
//}

//public Transform camara;
//private float lastX;

//lastX = camara.position.x;