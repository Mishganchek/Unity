using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private float _smoothing = 5f; 
    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - _target.position;
    }

    void FixedUpdate()
    {   
        Vector3 targetCamPos = _target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, _smoothing * Time.deltaTime);
    }
}

