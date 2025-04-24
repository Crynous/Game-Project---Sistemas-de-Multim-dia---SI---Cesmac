using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaCena : MonoBehaviour
{
    public string nomeCenaDestino;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Garante que o PlayerManager est� dispon�vel antes de tentar us�-lo
            if (PlayerManager.instance != null)
            {
                PlayerManager.instance.SetPlayerSpawnPosition(other.transform.position);
            }

            SceneManager.LoadScene(nomeCenaDestino, LoadSceneMode.Single);
        }
    }
}
