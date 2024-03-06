using System.Collections;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Boundaries Boundaries;
    [SerializeField] private float _FireRate;
    [SerializeField] private float _FireBurstRate;
    [SerializeField] private int _BulletAmount;
    [SerializeField] private AudioSource _ShootSoundEffect;
    [SerializeField] private GameObject _Laser;
    [SerializeField] private Transform _laserPos;
    private float _fireTime;

    void Update()
    {
        if (GameManager.instance.gameOver == true || Boundaries.InFrame == false)
        {
            return;
        }

        _fireTime += Time.deltaTime;
        if (_fireTime >= _FireRate)
        {
            _fireTime = 0;
            StartCoroutine(FireBurst());
        }
    }

    private IEnumerator FireBurst()
    {
        for (int i = 0; i < _BulletAmount; i++)
        {
            Shoot();
            yield return new WaitForSeconds(_FireBurstRate);
        }

        void Shoot()
        {
            Instantiate(_Laser, _laserPos.position, Quaternion.identity);
            _ShootSoundEffect.Play();
        }
    }
}
