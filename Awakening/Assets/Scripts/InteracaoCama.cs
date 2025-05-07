using UnityEngine;
using UnityEngine.UI;

public class InteracaoCama : MonoBehaviour
{
    public float tempoInteracao = 3f;
    private float tempoSegurando = 0f;
    private bool jogadorPerto = false;
    private bool camaArrumada = false;

    public GameObject promptUI; // Objeto de texto que aparece quando perto

    void Update()
    {
        if (jogadorPerto && !camaArrumada)
        {
            if (Input.GetKey(KeyCode.E))
            {
                tempoSegurando += Time.deltaTime;

                if (tempoSegurando >= tempoInteracao)
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
        // Aqui você pode adicionar efeitos visuais, sons, mudar sprites etc.
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
