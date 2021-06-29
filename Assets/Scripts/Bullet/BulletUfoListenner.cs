using UnityEngine;

public class BulletUfoListenner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
}
