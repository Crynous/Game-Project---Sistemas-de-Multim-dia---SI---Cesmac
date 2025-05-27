using UnityEngine;

public class InteracaoMesaEstudo : MonoBehaviour
{
    public GameObject promptUI; // Texto "Aperte E para estudar"
    public GameObject miniGameCanvas; // O Canvas do mini-game que você vai criar
    private bool jogadorPerto = false;
    private bool estudoConcluido = false;

    void Update()
    {
        if (jogadorPerto && !estudoConcluido)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                IniciarMiniGame();
            }
        }
    }

    void IniciarMiniGame()
    {
        // Sempre verificar se o objeto não é nulo antes de usá-lo
        if (miniGameCanvas != null)
        {
            miniGameCanvas.SetActive(true); // Ativa o mini-game
        }

        Time.timeScale = 0f; // Pausa o jogo enquanto o mini-game acontece

        if (promptUI != null)
        {
            promptUI.SetActive(false); // Esconde o prompt
        }
    }

    public void ConcluirEstudo()
    {
        estudoConcluido = true;

        if (miniGameCanvas != null)
        {
            miniGameCanvas.SetActive(false); // Fecha o mini-game
        }

        Time.timeScale = 1f; // Retoma o jogo

        Debug.Log("Estudo concluído!");
        // Aqui você pode adicionar efeitos, som, atualizar objetivos etc.
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;

            if (!estudoConcluido && promptUI != null)
            {
                promptUI.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;

            // Verificar se o promptUI existe antes de desativar
            if (promptUI != null)
            {
                promptUI.SetActive(false);
            }
        }
    }
}
