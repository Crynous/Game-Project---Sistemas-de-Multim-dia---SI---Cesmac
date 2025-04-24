using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject playerPrefab;

    void Start()
    {
        GameObject pontoSpawn = GameObject.FindGameObjectWithTag("Respawn");

        if (pontoSpawn != null && playerPrefab != null)
        {
            Instantiate(playerPrefab, pontoSpawn.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Ponto de spawn ou prefab do player não encontrados.");
        }
    }
}
