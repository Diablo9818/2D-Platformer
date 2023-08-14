using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector2 _offset = new Vector2(0, 2);
    [SerializeField] private float _smoothSpeed = 0.1f; 

    private Vector3 velocity = Vector3.zero; 

    void LateUpdate()
    {
        if (_target != null)
        {
            Vector3 targetPosition = new Vector3(_target.position.x + _offset.x, _target.position.y + _offset.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, _smoothSpeed);
        }
    }
}
