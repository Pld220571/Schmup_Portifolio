using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    private float _horizontal;
    private float _vertical;
    private Rigidbody _rb;    
    [SerializeField] private float _MoveSpeed;
    private bool _canDash = true;
    [SerializeField] private float _DashingPower;
    [SerializeField] private float _DashingTime;
    [SerializeField] private float _DashingCooldown;
    [SerializeField] private TrailRenderer _Tr;
    public Transform Player;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {        
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
        MoveShip();
        if (Input.GetKeyDown(KeyCode.LeftShift) && _canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private void MoveShip()
    {
        _rb.velocity = new Vector3(_horizontal * _MoveSpeed, _vertical * _MoveSpeed, 0);
    }

    private IEnumerator Dash()
    {
        _canDash = false;
        _rb.velocity = new Vector3(_horizontal * _DashingPower, _vertical * _DashingPower, 0);
        _Tr.emitting = true;
        yield return new WaitForSeconds(_DashingTime);
        _Tr.emitting = false;
        yield return new WaitForSeconds(_DashingCooldown);
        _canDash = true;
    }
}