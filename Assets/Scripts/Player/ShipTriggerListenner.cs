using UnityEngine;

public class ShipTriggerListenner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UFO"))
        {
            var gameLogic = FindObjectOfType<GameLogic>();
            gameLogic.RestartPlayer(GetComponent<Collider>());

            var flashing = GetComponent<Flashing>();
            flashing.DisableCollider();
            flashing.ResetTimers();

            Destroy(other.gameObject);
        }
    }
}
