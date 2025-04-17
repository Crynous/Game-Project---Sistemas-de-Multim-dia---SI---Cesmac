using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    public void FadeAndLoadScene(string sceneName)
    {
        StartCoroutine(FadeInThenLoad(sceneName));
    }

    private IEnumerator FadeInThenLoad(string sceneName)
    {
        // Fade in (ficando preto)
        yield return StartCoroutine(Fade(0, 1));

        // Troca de cena
        SceneManager.LoadScene(sceneName);

        // Espera uma pequena pausa
        yield return new WaitForSeconds(0.1f);

        // Fade out (voltando ao normal)
        yield return StartCoroutine(Fade(1, 0));
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float t = 0;
        Color color = fadeImage.color;

        while (t < 1)
        {
            t += Time.deltaTime / fadeDuration;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, t);
            fadeImage.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }
    }
}
