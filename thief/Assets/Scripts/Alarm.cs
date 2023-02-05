using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    private float _speed = 0.05f;
    private float _maxVolume = 1.0f;
    private float _startVolume = 0.01f;
    private float _currentVolume = 0.01f;
    private bool _IsOut;

    private void Start()
    {
        _alarm.volume = 0f;
    }

    private void OnTriggerStay(Collider other)
    {
        _alarm.volume = Mathf.MoveTowards(_startVolume, _maxVolume, _speed * Time.deltaTime);
        _speed += 0.1f;

        Debug.Log(_alarm.volume);
        _currentVolume = _maxVolume;
    }

    private void OnTriggerEnter(Collider other)
    {
        _alarm.Play();
        _alarm.volume = 0f;
    }

    private void OnTriggerExit(Collider other)
    {
        _IsOut = true;
    }

    private void Update()
    {
        if (_IsOut)
        {
        _alarm.volume = Mathf.MoveTowards(_currentVolume, _startVolume, _speed * Time.deltaTime);
        _speed += 0.1f;

        }
    }
}
