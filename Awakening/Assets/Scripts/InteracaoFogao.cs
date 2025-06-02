using UnityEngine;

public class InteracaoFogao : MonoBehaviour
{
    public GameObject promptUI;
    public GameObject miniGameCozinha;

    private bool jogadorPerto = false;

    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            IniciarMiniGame();
        }
    }

    void IniciarMiniGame()
    {
        miniGameCozinha.SetActive(true);
        Time.timeScale = 0f; // pausa o jogo
        promptUI.SetActive(false);
    }

    public void ReiniciarMiniGame()
    {
        promptUI.SetActive(true);
        Time.timeScale = 1f; // retoma o jogo
        miniGameCozinha.SetActive(false);
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

            // verifica se o promptUI existe antes de acessar
            if (promptUI != null)
            {
                promptUI.SetActive(false);
            }
        }
    }

}
