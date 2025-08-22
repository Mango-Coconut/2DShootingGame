using UnityEngine;
using TMPro;

public class StageNoticeUI : MonoBehaviour
{
    private TMP_Text text;
    private CanvasGroup canvasGroup;
    private float duration = 2f;
    private float timer;

    public static void Show(int stage)
    {
        GameObject obj = new GameObject("StageNoticeUI");
        Canvas canvas = obj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        StageNoticeUI notice = obj.AddComponent<StageNoticeUI>();
        notice.Setup(stage);
    }

    private void Setup(int stage)
    {
        canvasGroup = gameObject.AddComponent<CanvasGroup>();

        GameObject textObj = new GameObject("Text");
        textObj.transform.SetParent(transform);
        text = textObj.AddComponent<TextMeshProUGUI>();
        text.text = $"Stage {stage}";
        text.fontSize = 48f;
        text.alignment = TextAlignmentOptions.Top;

        RectTransform rt = text.rectTransform;
        rt.anchorMin = new Vector2(0.5f, 1f);
        rt.anchorMax = new Vector2(0.5f, 1f);
        rt.pivot = new Vector2(0.5f, 1f);
        rt.anchoredPosition = new Vector2(0f, -50f);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        float alpha = 1f - timer / duration;
        canvasGroup.alpha = alpha;
        if (timer >= duration)
            Destroy(gameObject);
    }
}
