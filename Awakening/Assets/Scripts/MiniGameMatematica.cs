using UnityEngine;
using TMPro;

public class MiniGameMatematica : MonoBehaviour
{
    public TMP_Text perguntaTexto;
    public TMP_InputField respostaInput;
    public TMP_Text feedbackTexto;

    private int numero1;
    private int numero2;
    private int resultadoEsperado;
    private int contadorAcertos = 0;
    private int totalPerguntas = 3;

    void OnEnable()
    {
        contadorAcertos = 0;
        feedbackTexto.text = "";
        respostaInput.text = "";
        GerarPergunta();
        respostaInput.ActivateInputField();
    }

    void GerarPergunta()
    {
        numero1 = Random.Range(1, 10);
        numero2 = Random.Range(1, 10);
        resultadoEsperado = numero1 + numero2;
        perguntaTexto.text = $"Pergunta {contadorAcertos + 1}/{totalPerguntas}: Quanto é {numero1} + {numero2}?";
    }

    public void VerificarResposta()
    {
        int resposta;
        if (int.TryParse(respostaInput.text, out resposta))
        {
            if (resposta == resultadoEsperado)
            {
                contadorAcertos++;
                feedbackTexto.text = "Correto!";

                if (contadorAcertos >= totalPerguntas)
                {
                    // Minigame concluído!
                    FindFirstObjectByType<InteracaoMesaEstudo>().ConcluirEstudo();
                    gameObject.SetActive(false);
                }
                else
                {
                    // Nova pergunta!
                    respostaInput.text = "";
                    GerarPergunta();
                    respostaInput.ActivateInputField();
                }
            }
            else
            {
                feedbackTexto.text = "Errado. Tente novamente!";
                respostaInput.text = "";
                respostaInput.ActivateInputField();
            }
        }
        else
        {
            feedbackTexto.text = "Digite um número!";
            respostaInput.text = "";
            respostaInput.ActivateInputField();
        }
    }
}
