using UnityEngine;

public class InteractableWithKey : MonoBehaviour
{
    public GameObject menuToOpen;          // Painel de menu a abrir (opcional por enquanto)
    public float interactionRange = 2f;    // Distância máxima de interação

    private Transform player;
    private bool isPlayerNearby;

    void Start()
{
    GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
    if (playerObj != null)
    {
        player = playerObj.transform;
    }
    else
    {
        Debug.LogWarning("Nenhum objeto com a tag 'Player' foi encontrado na cena.");
    }
}

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        isPlayerNearby = distance <= interactionRange;

        if (isPlayerNearby)
        {
            Debug.Log("Jogador está próximo de: " + gameObject.name);
        }

        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Tecla E pressionada perto de: " + gameObject.name);
            ToggleMenu();
        }
    }

    void ToggleMenu()
    {
        if (menuToOpen != null)
        {
            bool isActive = menuToOpen.activeSelf;
            menuToOpen.SetActive(!isActive);
            Debug.Log("Menu " + (isActive ? "fechado" : "aberto"));
        }
        else
        {
            Debug.Log("Nenhum menu atribuído no Inspector para: " + gameObject.name);
        }
    }
}
