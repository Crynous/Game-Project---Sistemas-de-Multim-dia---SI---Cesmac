using UnityEngine;
using UnityEngine.UI; // ou TMPro se usar TextMeshPro

public class InteracaoArmario : MonoBehaviour
{
    public GameObject promptUI; // arrastar o TextoInteracaoArmario aqui no Inspector
    public float tempoInteracao = 5f; // tempo necessário segurando E
    private float tempoAtual = 0f;
    private bool jogadorProximo = false;
    private bool interagindo = false;
    private bool armarioAberto = false;

    void Update()
    {
        if (jogadorProximo && !armarioAberto)
        {
            if (Input.GetKey(KeyCode.E))
            {
                interagindo = true;
                tempoAtual += Time.deltaTime;

                if (tempoAtual >= tempoInteracao)
                {
                    // Interação completa
                    promptUI.GetComponent<Text>().text = "O armário foi aberto!";
                    armarioAberto = true;
                }
            }
            else
            {
                if (interagindo)
                {
                    // Se parou de apertar antes de completar
                    tempoAtual = 0f;
                    interagindo = false;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorProximo = true;
            if (!armarioAberto)
                promptUI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorProximo = false;
            promptUI.SetActive(false);
            tempoAtual = 0f; // reseta o progresso se sair
            interagindo = false;
        }
    }
}
