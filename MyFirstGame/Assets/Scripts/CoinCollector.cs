using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private AudioClip _coinSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Coin coin = gameObject.GetComponent<Coin>();

        if (coin != null)
        {
            AudioSource.PlayClipAtPoint(_coinSound, transform.position);
            Destroy(gameObject);
        }
    }
}
