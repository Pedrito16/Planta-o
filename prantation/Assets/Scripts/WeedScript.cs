using System.Collections;
using UnityEngine;

public class WeedScript : MonoBehaviour
{
    [SerializeField] float timeToGrow = 0.5f; // Time in minutes for the weed to grow
    [SerializeField] Sprite[] spritesToChange = new Sprite[4];
    [Tooltip("Os sprites para diferentes tipos de tamanho (0%,50%, 75%, 100%")]
    SpriteRenderer spriteRenderer;
    float lastGrowth;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spritesToChange[0];
        StartCoroutine(GrowEnumerator());
    }
    void Update()
    {
        
    }
    private IEnumerator GrowEnumerator()
    {
        float timeInSeconds = timeToGrow * 60f;
        float iterador = 0f;
        while(iterador < timeInSeconds)
        {
            iterador += Time.deltaTime;
            CheckPercent(timeInSeconds, iterador);
            print(iterador);
            yield return null;
        }
    }
    public IEnumerator Bobbing(float duration)
    {
        float iterador = 0;
        float dividedDuration = duration / 2;
        Vector2 initialPos = transform.localScale;
        Vector2 newPos = new Vector2(initialPos.x + 0.1f, initialPos.y + 0.1f);
        while (iterador < dividedDuration)
        {
            iterador += Time.deltaTime;
            transform.localScale = Vector2.Lerp(transform.localScale, newPos, iterador / dividedDuration);
            yield return null;
        }
        print("SEgunda parte");
        iterador = 0;
        while(iterador < dividedDuration)
        {
            iterador += Time.deltaTime;
            transform.localScale = Vector2.Lerp(transform.localScale, initialPos, iterador / dividedDuration);
            yield return null;
        }
    }
    void CheckPercent(float numberToDiscover, float numberToApplyPercent)
    {
        float percent = (numberToApplyPercent / numberToDiscover) * 100;
        if (percent < 50f) return;
        else if (percent >= 50 && percent < 75f && lastGrowth == 0)
        {
            lastGrowth += 1;
            spriteRenderer.sprite = spritesToChange[1];
            StartCoroutine(Bobbing(0.25f));
        }
        else if(percent >= 75f && percent < 100f && lastGrowth == 1)
        {
            lastGrowth += 1;
            spriteRenderer.sprite = spritesToChange[2];
            StartCoroutine(Bobbing(0.25f));
            return;
        }
        else if(percent >= 100f && lastGrowth == 2)
        {
            lastGrowth += 1;
            spriteRenderer.sprite = spritesToChange[3];
            StartCoroutine(Bobbing(0.25f));
            return;
        }
    }
}
