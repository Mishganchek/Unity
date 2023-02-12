using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerMovement : MonoBehaviour
{
    private const string IsOnPlatform = "isOnPlatform";
    private const string MoveX = "moveX";

    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private float _jumpForce = 0.5f;
    [SerializeField] private float _checRadius;
    [SerializeField] private Transform _platformChecer;
    [SerializeField] private LayerMask _platform;

    private bool _isOnPlatform;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidBody;
    private bool _faceRight;
    private Vector2 _moveVector;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Walk();
        Jump();
        Reflect();
        PlatformChecer();
    }

    private void Walk()
    {
        _moveVector.x = Input.GetAxis("Horizontal");
        _rigidBody.velocity = new Vector2(_moveVector.x * _speed, _rigidBody.velocity.y);
        _animator.SetFloat(MoveX, Mathf.Abs(_moveVector.x));
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isOnPlatform)
        {
            _rigidBody.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void PlatformChecer()
    {
        _isOnPlatform = Physics2D.OverlapCircle(_platformChecer.position, _checRadius, _platform);
        _animator.SetBool(IsOnPlatform, _isOnPlatform);

    }

    private void Reflect()
    {
        if ((_moveVector.x < 0 && !_faceRight) || (_moveVector.x > 0 && _faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            _faceRight = !_faceRight;
        }
    }
}