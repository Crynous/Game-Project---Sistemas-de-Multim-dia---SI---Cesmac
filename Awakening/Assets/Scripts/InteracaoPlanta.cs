using UnityEngine;

public class InteracaoPlanta : MonoBehaviour
{
    [Header("Referências")]
    public GameObject promptUI;
    public GameObject miniGameDevaneioPrefab;

    [Header("Configuração do cooldown")]
    public float tempoCooldown = 5f; // Tempo que a interação fica bloqueada após uso
    private bool jogadorPerto = false;
    private bool podeInteragir = true;

    void Update()
    {
        if (jogadorPerto && podeInteragir && Input.GetKeyDown(KeyCode.E))
        {
            IniciarDevaneio();
            podeInteragir = false;
            Invoke(nameof(ReativarInteracao), tempoCooldown);
        }
    }

    void IniciarDevaneio()
    {
        // Instancia o prefab do minigame e coloca no Canvas
        GameObject devaneioGO = Instantiate(miniGameDevaneioPrefab);
        devaneioGO.transform.SetParent(GameObject.Find("Canvas").transform, false);
        devaneioGO.SetActive(true);

        // Esconde o prompt de interação
        promptUI.SetActive(false);
    }

    void ReativarInteracao()
    {
        podeInteragir = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
            promptUI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
            promptUI.SetActive(false);
        }
    }
}
