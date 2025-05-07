using UnityEngine;
using UnityEngine.UI;

public class InteracaoArmario : MonoBehaviour
{
    public float tempoInteracao = 5f;
    private float tempoSegurando = 0f;
    private bool jogadorProximo = false;
    private bool armarioArrumado = false;

    public GameObject promptUI; // Objeto de texto para interação

    void Update()
    {
        if (jogadorProximo && !armarioArrumado)
        {
            if (Input.GetKey(KeyCode.E))
            {
                tempoSegurando += Time.deltaTime;

                if (tempoSegurando >= tempoInteracao)
                {
                    ArrumarArmario();
                }
            }
            else
            {
                tempoSegurando = 0f; // reset se soltar
            }
        }
    }

    void ArrumarArmario()
    {
        armarioArrumado = true;
        promptUI.SetActive(false);
        Debug.Log("Armário arrumado!");
        // Aqui você pode adicionar efeitos, som, mudar sprite etc.
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorProximo = true;
            if (!armarioArrumado)
                promptUI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorProximo = false;
            tempoSegurando = 0f;
            promptUI.SetActive(false);
        }
    }
}
