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
            miniGameCozinha.SetActive(true);
            Time.timeScale = 0f;
            promptUI.SetActive(false);
        }
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
