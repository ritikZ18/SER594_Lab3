using UnityEngine;
using TMPro;
using System.Collections;

public class PopupMessageUI : MonoBehaviour
{
    public static PopupMessageUI Instance;

    public TextMeshProUGUI messageText;
    public CanvasGroup canvasGroup;

    public float showDuration = 2f;
    public float fadeSpeed = 2f;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowMessage(string message)
    {
        StopAllCoroutines();
        StartCoroutine(DisplayMessage(message));
    }

    IEnumerator DisplayMessage(string message)
    {
        messageText.text = message;

        // Fade in
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }

        yield return new WaitForSeconds(showDuration);

        // Fade out
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }
}
