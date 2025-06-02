using UnityEngine;
using UnityEngine.UI;

public class MiniGameCozinha : MonoBehaviour
{
    public Slider temperaturaSlider;
    public Text feedbackTexto;

    public float tempoJogo = 10f;
    private float tempoAtual;

    private float velocidadeOscilacao = 2f;
    private bool jogoAtivo = false;

    void OnEnable()
    {
        tempoAtual = tempoJogo;
        temperaturaSlider.value = 0.5f;
        feedbackTexto.text = "Equilibre a temperatura!";
        jogoAtivo = true;
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (!jogoAtivo) return;

        float direcao = Random.Range(-1f, 1f);
        temperaturaSlider.value += direcao * velocidadeOscilacao * Time.unscaledDeltaTime;
        temperaturaSlider.value = Mathf.Clamp01(temperaturaSlider.value);

        if (Input.GetKey(KeyCode.A))
            temperaturaSlider.value -= 0.5f * Time.unscaledDeltaTime;
        if (Input.GetKey(KeyCode.D))
            temperaturaSlider.value += 0.5f * Time.unscaledDeltaTime;

        if (Input.GetKeyDown(KeyCode.Escape))
            CancelarMinigame();

        if (temperaturaSlider.value > 0.7f)
            feedbackTexto.text = "Comida queimando!";
        else if (temperaturaSlider.value < 0.3f)
            feedbackTexto.text = "Temperatura baixa!";
        else
            feedbackTexto.text = "Temperatura ok!";

        tempoAtual -= Time.unscaledDeltaTime;
        if (tempoAtual <= 0f)
        {
            jogoAtivo = false;
            AvaliarResultado();
        }
    }

    void AvaliarResultado()
    {
        if (temperaturaSlider.value >= 0.4f && temperaturaSlider.value <= 0.6f)
            feedbackTexto.text = "Prato pronto! Sucesso!";
        else
            feedbackTexto.text = "Prato falhou! Tente de novo!";

        // Espera 2 segundos em tempo real antes de fechar
        StartCoroutine(FecharMinigameDepoisDe(2f));
    }

    System.Collections.IEnumerator FecharMinigameDepoisDe(float segundos)
    {
        yield return new WaitForSecondsRealtime(segundos);
        FecharMinigame();
    }

    void CancelarMinigame()
    {
        jogoAtivo = false;
        FecharMinigame();
    }

    void FecharMinigame()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
