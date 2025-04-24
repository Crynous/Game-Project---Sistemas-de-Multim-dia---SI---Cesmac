using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public Vector2 playerSpawnPosition;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Armazena a posição do player antes da troca de cena
    public void SetPlayerSpawnPosition(Vector2 newPosition)
    {
        playerSpawnPosition = newPosition;
    }
}
