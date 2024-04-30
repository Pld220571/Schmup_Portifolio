using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    public Vector3 direction = Vector3.zero;
    Vector3 destination;
    public Boundaries boundaries;
    public bool running = false;
    public bool stopCam;
    [SerializeField] float directionTimer;
    [SerializeField] float posYMin;
    [SerializeField] float posYMax;

    private void Update()
    {
        if (boundaries.InFrame == true && !running)
        {
            stopCam = true;
            StartCoroutine(changeDirection());
        }

        transform.position += direction * speed;
    }

    IEnumerator changeDirection()
    {

        running = true;
        yield return new WaitForSeconds(directionTimer);
        //direction.x = Random.Range(0, 0.9f);
        direction.y = Random.Range(posYMin, posYMax);
        running = false;
    }
}
