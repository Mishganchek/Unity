using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private AudioClip _coinSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(_coinSound, transform.position);
            Destroy(gameObject);
        }
    }
}
