using System.Collections;
using UnityEngine;
using System;

public class Door : MonoBehaviour
{
    public event Action Entered;
    public event Action Exited;

    private void OnTriggerEnter(Collider other)
    {
        Entered?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        Exited?.Invoke();
    }
}
