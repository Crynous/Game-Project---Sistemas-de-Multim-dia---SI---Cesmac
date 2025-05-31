using UnityEngine;
using UnityEngine.UI;

public class MiniGameCozinha : MonoBehaviour
{
    public Slider sliderTemperatura;
    public Button botaoMexer;
    public Text textoFeedback;

    private float tempoCozinhando = 0f;
    private float tempoMaximo = 15f;
    private float tempoSemMexer = 0f;
    private float limiteSemMexer = 3f;

    private bool cozinhando = false;

    void OnEnable()
    {
        // Reinicia tudo ao abrir
        sliderTemperatura.value = 50;
        tempoCozinhando = 0f;
        tempoSemMexer = 0f;
        textoFeedback.text = "Mantenha a temperatura ideal e mexa a panela!";
        cozinhando = true;

        // Adiciona evento no botão
        botaoMexer.onClick.AddListener(MexerPanela);
    }

    void OnDisable()
    {
        // Remove evento ao fechar
        botaoMexer.onClick.RemoveListener(MexerPanela);
    }

    void Update()
    {
        if (!cozinhando) return;

        tempoCozinhando += Time.unscaledDeltaTime;
        tempoSemMexer += Time.unscaledDeltaTime;

        // Verifica se a temperatura está na faixa ideal (40-60)
        if (sliderTemperatura.value < 40 || sliderTemperatura.value > 60)
        {
            textoFeedback.text = "Atenção! Ajuste a temperatura!";
        }
        else
        {
            textoFeedback.text = "Ótimo! Temperatura perfeita!";
        }

        // Se não mexer a panela por muito tempo
        if (tempoSemMexer > limiteSemMexer)
        {
            textoFeedback.text = "A comida está queimando!";
        }

        // Finaliza o mini-game
        if (tempoCozinhando >= tempoMaximo)
        {
            FinalizarMiniGame();
        }
    }

    void MexerPanela()
    {
        tempoSemMexer = 0f;
        textoFeedback.text = "Panela mexida!";
    }

    void FinalizarMiniGame()
    {
        cozinhando = false;
        textoFeedback.text = "Prato pronto!";
        Time.timeScale = 1f;
        gameObject.SetActive(false);

        // Aqui pode adicionar feedback final, som, etc.
        Debug.Log("Mini-game de cozinha concluído!");
    }
}
