using UnityEngine;

public class InteracaoMesaEstudo : MonoBehaviour
{
    public GameObject promptUI;
    public GameObject miniGameCanvas;
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

        // Cancela o mini-game ao apertar ESC
        if (miniGameCanvas.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            CancelarMiniGame();
        }
    }

    void IniciarMiniGame()
    {
        miniGameCanvas.SetActive(true);
        Time.timeScale = 0f;
        promptUI.SetActive(false);
    }

    public void ConcluirEstudo()
    {
        estudoConcluido = true;
        miniGameCanvas.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("Estudo concluído!");
    }

    void CancelarMiniGame()
    {
        miniGameCanvas.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("Mini-game cancelado!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
            if (!estudoConcluido)
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
