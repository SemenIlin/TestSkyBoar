using UnityEngine;

public class BulletUfoListenner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            var flashing = other.GetComponent<Flashing>();
            flashing.DisableCollider();
            flashing.ResetTimers();

            FindObjectOfType<GameLogic>().RestartPlayer(other);
        }
    }
}
