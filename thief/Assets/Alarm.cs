using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
     private float _duration = 1f;
    private float _duringTime;
    private float _stratTime;

    private void Start()
    {
        _alarm.volume = 0f;
    }

    private void OnTriggerStay(Collider other)
    {
        _duringTime += Time.deltaTime;
        _alarm.volume = Mathf.MoveTowards(_stratTime, _duringTime, _duration * Time.deltaTime);
        _duration += 0.05f;
        Debug.Log(_alarm.volume);
    }

    private void OnTriggerEnter(Collider other)
    {
        _alarm.Play();
        _alarm.volume = 0f;
    }

    private void OnTriggerExit(Collider other)
    {
        _alarm.Stop();
        _alarm.volume = 0f;
    }
}
