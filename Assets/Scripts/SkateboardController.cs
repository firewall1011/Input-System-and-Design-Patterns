using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SkateboardController : MonoBehaviour
{
    [SerializeField] private float accelerationScale;
    [SerializeField] private float breakScale;
    [SerializeField] private float turnScale;
    
    private float _acceleration;
    private float _break;
    private float _turn;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(transform.forward * _acceleration * accelerationScale, ForceMode.Acceleration);
        _rigidbody.AddForce(-transform.forward * _break * breakScale, ForceMode.Acceleration);
        _rigidbody.AddTorque(transform.up * _turn * turnScale, ForceMode.Acceleration);
    }


    public void SetAcceleration(float value) => _acceleration = value;
    public void Break(float value) => _break = value;
    public void Turn(float direction) => _turn = direction;
}
