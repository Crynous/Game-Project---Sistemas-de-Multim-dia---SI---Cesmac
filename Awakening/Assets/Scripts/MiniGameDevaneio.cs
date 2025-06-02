using UnityEngine;
using TMPro;

public class MiniGameDevaneio : MonoBehaviour
{
    public TMP_Text textoFilosofico;
    public TMP_Text textoFinal;
    public float tempoDevaneio = 3f;
    public float tempoExibicaoDevaneio = 2f;

    private float contador = 0f;
    private bool devaneioAtivo = false;

    // Sequência de frases
    private static int indiceFrase = 0;
    private string[] frasesFilosoficas = new string[]
    {
        "Quem veio primeiro, o ovo ou a galinha?",
        "Se uma árvore cai na floresta e ninguém escuta, ela faz barulho?",
        "O que vemos é real ou apenas uma ilusão de nossos sentidos?"
    };

    void Start()
    {
        textoFilosofico.gameObject.SetActive(false);
        textoFinal.gameObject.SetActive(false);
        devaneioAtivo = true;
        contador = 0f;
    }

    void Update()
    {
        if (devaneioAtivo)
        {
            contador += Time.unscaledDeltaTime;

            if (contador >= tempoDevaneio)
            {
                devaneioAtivo = false;
                ExibirFilosofia();
            }
        }

        // Jogador pode sair da filosofia pressionando ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FecharDevaneio();
        }
    }

    void ExibirFilosofia()
    {
        textoFilosofico.gameObject.SetActive(true);
        textoFilosofico.text = frasesFilosoficas[indiceFrase];

        // Avança para a próxima frase
        indiceFrase = (indiceFrase + 1) % frasesFilosoficas.Length;

        // Aguarda a frase sumir e exibir a mensagem final
        Invoke(nameof(EsconderFilosofia), 2f); // Duração de exibição da frase (2 segundos)
    }

    void EsconderFilosofia()
    {
        textoFilosofico.gameObject.SetActive(false);
        ExibirMensagemFinal();
    }

    void ExibirMensagemFinal()
    {
        textoFinal.gameObject.SetActive(true);
        textoFinal.text = "Você teve um devaneio ao observar a planta.";

        // Mensagem final desaparece após 2 segundos
        Invoke(nameof(FecharDevaneio), tempoExibicaoDevaneio);
    }

    void FecharDevaneio()
    {
        Destroy(gameObject);
    }
}
