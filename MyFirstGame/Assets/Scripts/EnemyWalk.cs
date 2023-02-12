using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _radius = 2.0f;

    private float _startPosition;
    private bool _movingRight = true;

    private void Start()
    {
        _startPosition = transform.position.x;
    }

    private void Update()
    {
        float newX = transform.position.x + (_movingRight ? _speed : -_speed) * Time.deltaTime;

        if (Mathf.Abs(newX - _startPosition) > _radius)
        {
            _movingRight = !_movingRight;
        }

        transform.position = new Vector2(newX, transform.position.y);
    }
}





