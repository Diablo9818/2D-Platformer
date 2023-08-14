using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class ColliderBehavior : MonoBehaviour
{
    [SerializeField] private List<Collider2D> _ignoredColliders;
    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    void Start()
    {
        foreach (var collider in _ignoredColliders)
        {
            Physics2D.IgnoreCollision(collider, _collider, true);
        }
    }
}
