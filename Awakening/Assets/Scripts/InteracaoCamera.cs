using UnityEngine;
using UnityEngine.UI;

public class InteracaoCama : MonoBehaviour
{
    public float tempoNecessario = 3f;
    private float tempoSegurando = 0f;
    private bool jogadorPerto = false;
    private bool camaArrumada = false;

    public GameObject promptUI; // Referência ao texto na tela (ex: "Segure E para arrumar a cama")

    void Update()
    {
        if (jogadorPerto && !camaArrumada)
        {
            if (Input.GetKey(KeyCode.E))
            {
                tempoSegurando += Time.deltaTime;

                if (tempoSegurando >= tempoNecessario)
                {
                    ArrumarCama();
                }
            }
            else
            {
                tempoSegurando = 0f; // reset se soltar
            }
        }
    }

    void ArrumarCama()
    {
        camaArrumada = true;
        promptUI.SetActive(false);
        Debug.Log("Cama arrumada!");
        // aqui você pode trocar sprite, ativar algo, tocar som etc.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jogadorPerto = true;
            if (!camaArrumada)
                promptUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jogadorPerto = false;
            tempoSegurando = 0f;
            promptUI.SetActive(false);
        }
    }
}
