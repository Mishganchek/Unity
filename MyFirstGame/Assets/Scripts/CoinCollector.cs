using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private AudioClip _coinSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            AudioSource.PlayClipAtPoint(_coinSound, transform.position);
            Destroy(gameObject);
        }
    }
}
