using UnityEngine;
using UnityEngine.UI;

public class MiniGameEstudo : MonoBehaviour
{
    public GameObject miniGameUI;
    public Text perguntaText;
    public InputField respostaInput;
    public Text feedbackText;

    private string[] perguntas = { "2 + 2", "3 + 5", "10 - 4" };
    private string[] respostas = { "4", "8", "6" };

    private int perguntaAtual = 0;
    private bool miniGameAtivo = false;

    public float tempoInteracaoCancelar = 1.5f;
    private float tempoSegurando = 0f;

    void Update()
    {
        if (miniGameAtivo && Input.GetKey(KeyCode.E))
        {
            tempoSegurando += Time.deltaTime;

            if (tempoSegurando >= tempoInteracaoCancelar)
            {
                CancelarMiniGame();
            }
        }
        else
        {
            tempoSegurando = 0f;
        }
    }

    public void IniciarMiniGame()
    {
        miniGameAtivo = true;
        miniGameUI.SetActive(true);
        GerarPergunta();
    }

    void GerarPergunta()
    {
        perguntaText.text = perguntas[perguntaAtual];
        respostaInput.text = "";
        feedbackText.text = "";
    }

    public void EnviarResposta()
    {
        if (respostaInput.text == respostas[perguntaAtual])
        {
            feedbackText.text = "Correto!";
            miniGameAtivo = false;
            miniGameUI.SetActive(false);
            Debug.Log("Mini game concluído com sucesso.");
            // Aqui você pode adicionar efeitos ou recompensa
        }
        else
        {
            feedbackText.text = "Resposta incorreta. Tente novamente.";
        }
    }

    void CancelarMiniGame()
    {
        miniGameAtivo = false;
        miniGameUI.SetActive(false);
        respostaInput.text = "";
        feedbackText.text = "";
        Debug.Log("Mini game cancelado.");
    }
}
