using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [Header("Destino do Teleporte")]
    public Vector3 teleportDestination = new Vector3(10f, 5f, 0f);

    private bool isPlayerInside = false;
    private GameObject Player;

    void Update()
    {
        if (isPlayerInside && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressionado: Teleportando player...");
            Player.transform.position = teleportDestination;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            Player = other.gameObject;
            Debug.Log("Player entrou na área da porta.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            Player = null;
            Debug.Log("Player saiu da área da porta.");
        }
    }
}
