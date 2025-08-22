using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    private TMP_Text text;
    private float duration = 1f;
    private float timer;
    private float moveSpeed = 1f;

    public static void Create(int amount, Vector3 position)
    {
        GameObject obj = new GameObject("DamageText");
        obj.transform.position = position;
        DamageText dmgText = obj.AddComponent<DamageText>();
        dmgText.Setup(amount);
    }

    private void Awake()
    {
        text = gameObject.AddComponent<TextMeshPro>();
        text.fontSize = 4;
        text.color = Color.white;
        text.alignment = TextAlignmentOptions.Center;
    }

    private void Setup(int amount)
    {
        text.text = amount.ToString();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        float alpha = 1f - timer / duration;
        Color c = text.color;
        c.a = alpha;
        text.color = c;
        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }
}
