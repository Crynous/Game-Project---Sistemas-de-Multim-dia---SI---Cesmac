using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Usado para acessar Text (Legacy)

public class TrocaCena : MonoBehaviour
{
    public string nomeCenaDestino;
    public Text textoInteracao; // Agora usando o tipo Text (Legacy)

    private bool jogadorNaArea = false;
    private Transform jogadorTransform;

    private void Update()
    {
        if (jogadorNaArea && Input.GetKeyDown(KeyCode.E))
        {
            if (PlayerManager.instance != null && jogadorTransform != null)
            {
                PlayerManager.instance.SetPlayerSpawnPosition(jogadorTransform.position);
            }

            SceneManager.LoadScene(nomeCenaDestino, LoadSceneMode.Single);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorNaArea = true;
            jogadorTransform = other.transform;

            if (textoInteracao != null)
                textoInteracao.gameObject.SetActive(true); // Mostra o texto na tela
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorNaArea = false;
            jogadorTransform = null;

            if (textoInteracao != null)
                textoInteracao.gameObject.SetActive(false); // Esconde o texto
        }
    }
}
