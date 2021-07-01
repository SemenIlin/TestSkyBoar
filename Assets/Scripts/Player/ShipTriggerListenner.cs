using UnityEngine;

public class ShipTriggerListenner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UFO"))
        {
            FindObjectOfType<GameLogic>().RestartPlayer(GetComponent<Collider>());

            var flashing = GetComponent<Flashing>();
            flashing.DisableCollider();
            flashing.ResetTimers();

            Destroy(other.gameObject);
        }
    }
}
