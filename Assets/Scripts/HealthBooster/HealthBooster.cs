using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBooster : MonoBehaviour
{
    [SerializeField] private int _healthToIncrease;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerHealth health))
        {
            health.IncreaseHealth(_healthToIncrease);
            Destroy(gameObject);
        }
    }
}
