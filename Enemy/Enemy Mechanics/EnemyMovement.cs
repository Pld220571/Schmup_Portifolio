using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Boundaries boundaries;
    [SerializeField] private float _Speed;
    [SerializeField] private float _MinX, _MaxX, _MinY, _MaxY;
    [SerializeField] private float _ChangeCountdown;
    private Vector3 _direction = Vector3.zero;
    private bool _running;

    private void Update()
    {
        if (boundaries.InFrame == true && !_running)
        {
            StartCoroutine(changeDirection(_ChangeCountdown));
        }

        transform.position += _direction * _Speed;
    }

    IEnumerator changeDirection(float timer)
    {
        _running = true;
        yield return new WaitForSeconds(timer);
        _direction.x = Random.Range(_MinX, _MaxX);
        _direction.y = Random.Range(_MinY, _MaxY);
        _running = false;
    }
}