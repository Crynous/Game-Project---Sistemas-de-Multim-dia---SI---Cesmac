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

    void OnEnable()
    {
        GerarPergunta();
        feedbackTexto.text = "";
        respostaInput.text = "";
        respostaInput.ActivateInputField();
    }

    void GerarPergunta()
    {
        numero1 = Random.Range(1, 10);
        numero2 = Random.Range(1, 10);
        resultadoEsperado = numero1 + numero2;
        perguntaTexto.text = $"Quanto é {numero1} + {numero2}?";
    }

    public void VerificarResposta()
    {
        int resposta;
        if (int.TryParse(respostaInput.text, out resposta))
        {
            if (resposta == resultadoEsperado)
            {
                feedbackTexto.text = "Correto!";
                FindFirstObjectByType<InteracaoMesaEstudo>().ConcluirEstudo();
            }
            else
            {
                feedbackTexto.text = "Errado. Tente novamente!";
            }
        }
        else
        {
            feedbackTexto.text = "Digite um número!";
        }
    }
}
