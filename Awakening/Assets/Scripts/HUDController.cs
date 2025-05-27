using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("Referências do HUD")]
    public Text clockText;
    public Text objectiveListText;

    [Header("Lista de Objetivos")]
    public string[] objetivos = {
        "Arrumar a cama",
        "Estudar as contas",
        "Cozinhar",
        "Cuidar do quintal"
    };

    private float timeCounter = 0f;
    private int hour = 8;  // Horário inicial: 8h

    void Start()
    {
        UpdateClock();
        AtualizarTabelaObjetivos();
    }

    void Update()
    {
        // Avança o horário a cada 10 segundos no jogo
        timeCounter += Time.deltaTime;
        if (timeCounter >= 10f)
        {
            hour++;
            timeCounter = 0f;

            if (hour >= 24) hour = 0;  // Reinicia o dia
            UpdateClock();
        }
    }

    void UpdateClock()
    {
        clockText.text = "Hora: " + hour.ToString() + "h";
    }

    public void AtualizarTabelaObjetivos()
    {
        objectiveListText.text = "Objetivos:\n";
        for (int i = 0; i < objetivos.Length; i++)
        {
            objectiveListText.text += "- " + objetivos[i] + "\n";
        }
    }

    public void MarcarObjetivoConcluido(string objetivo)
    {
        for (int i = 0; i < objetivos.Length; i++)
        {
            if (objetivos[i] == objetivo)
            {
                objetivos[i] += " (OK)";
                break;
            }
        }

        AtualizarTabelaObjetivos();
    }
}
