using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class InteractableNameLabel : MonoBehaviour
{
    [SerializeField] private Image nameLabel;
    [SerializeField] private TextMeshProUGUI nameText;
    private CanvasGroup canvasGroup;

    private bool isAppearing = false, isDisappearing = false;   //  To avoid calling both appear and disappear at the same time
    [SerializeField] private bool isVisible = false;            //  To check when to appear and when to disappear. E.g shouldn't call FadeOut if the label is already disappeared.
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private Vector3 fadeInEndPosition;
    [SerializeField] private Vector3 fadeOutEndPosition;

    //  For position animation
    private RectTransform rectTransform;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        canvasGroup.alpha = 0;
    }

    public void Appear(Interactable interactable)
    {
        //  Update name text
        nameText.text = interactable.DisplayName;

        if (!isAppearing && !isDisappearing && !isVisible)
        {
            StartCoroutine(FadeIn());
        }
    }

    public void Disappear()
    {
        if (!isAppearing && !isDisappearing && isVisible)
        {
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeIn()
    {
        isAppearing = true;

        float framesToAnimate = (fadeDuration / Time.deltaTime);
        for (float i = 0; i < framesToAnimate + 1; i++)
        {
            //  Fade in: Alpha 0 -> 1
            canvasGroup.alpha = Mathf.Lerp(0, 1, i / framesToAnimate);
            rectTransform.localPosition = Vector3.Lerp(fadeOutEndPosition, fadeInEndPosition, i / framesToAnimate);
            yield return null;
        }

        isAppearing = false;
        isVisible = true;
        yield return null;
    }

    private IEnumerator FadeOut()
    {
        isDisappearing = true;
        float framesToAnimate = (fadeDuration / Time.deltaTime);
        for (int i = 0; i < framesToAnimate + 1; i++)
        {
            //  Fade in: Alpha 0 -> 1
            canvasGroup.alpha = Mathf.Lerp(1, 0, i / framesToAnimate);
            rectTransform.localPosition = Vector3.Lerp(fadeInEndPosition, fadeOutEndPosition, i / framesToAnimate);
            yield return null;
        }

        isDisappearing = false;
        isVisible = false;
        yield return null;
    }
}
