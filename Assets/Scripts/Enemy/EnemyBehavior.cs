using System.Collections;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] float _moveSpeed;
    [SerializeField] ProjectileMove _projectile;

    private int _direction;
    private PlayerController Target;
    private Animator _animator;
    private string _currentState;

    const string ENEMY_RUN = "Run";
    const string ENEMY_IDLE = "Idle";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _direction = 1;
    }

    void Update()
    {
        if (Target ==null)
        {
            Move();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController playerController))
        {
            Target = null;
            
            if(_direction>0)
            {
                Quaternion rotation = Quaternion.Euler(0, 0, 0);
                transform.rotation = rotation;
            }
            else
            {
                Quaternion rotation = Quaternion.Euler(0, 180, 0);
                transform.rotation = rotation;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LeftPoint"))
        {
            _direction = 1;
            transform.Rotate(Vector3.up, 180.0f);
        }
        else if (collision.CompareTag("RightPoint"))
        {
            _direction = -1;
            transform.Rotate(Vector3.down, 180.0f);
        }

        if (collision.TryGetComponent(out PlayerController playerController))
        {
            Target = playerController;
            Rotate(Target.transform.position.z);
            ChangeAnimationState(ENEMY_IDLE);
            StartCoroutine(Shoot());
        }
    }

    private void Move()
    {
        ChangeAnimationState(ENEMY_RUN);
        _rigidbody.velocity = new Vector2(_direction * _moveSpeed, _rigidbody.velocity.y);
    }

    private void ChangeAnimationState(string newState)
    {
        if (_currentState == newState)
        {
            return;
        }
        _animator.Play(newState);
        _currentState = newState;
    }

    private void Rotate(float x)
    {
        Vector3 directionToTarget = Target.transform.position - transform.position;
        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.Euler(0f, angle, 0f);
        transform.rotation = newRotation;
    }

    private IEnumerator Shoot()
    {
        while (Target != null)
        {
            yield return new WaitForSeconds(2f);
            Instantiate(_projectile, transform.position, transform.rotation);
        }
    }
}
