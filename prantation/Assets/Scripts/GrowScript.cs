using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GrowScript : MonoBehaviour
{
    public float timeToGrow = 45; // Time in seconds for the weed to grow
    public bool hasGrown = false;
    public Sprite[] spritesToChange = new Sprite[4];
    [Tooltip("Os sprites para diferentes tipos de tamanho (0%,50%, 75%, 100%")]
    public PlantInfo info;

    [Header("Game Juice")]
    [SerializeField] TextMeshProUGUI growText;
    [SerializeField] Image growBar;
    [SerializeField] ParticleSystem growParticle;
    //variaveis privadas
    [SerializeField] SpriteRenderer spriteRenderer;
    float lastGrowth;
    void Start()
    {
    }
    void Update()
    {
        
    }
    public void Setup(PlantInfo plantInfo)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        info = plantInfo;
        timeToGrow = info.timeToGrows;
        spritesToChange = info.plantGrowSprites;
        spriteRenderer.sprite = spritesToChange[0];
        StartCoroutine(GrowEnumerator());
    }
    private IEnumerator GrowEnumerator()
    {
        float iterador = 0f;
        while(iterador < timeToGrow)
        {
            iterador += Time.deltaTime;
            
            CheckPercent(timeToGrow, iterador);
            yield return null;
        }
    }
    void CheckPercent(float numberToDiscover, float numberToApplyPercent)
    {
        float percent = (numberToApplyPercent / numberToDiscover) * 100;
        growBar.fillAmount = percent / 100;
        growText.text = percent.ToString("F2") + "%";

        if (percent < 50f) return;

        else if (percent >= 50 && percent < 75f && lastGrowth == 0)
            Grow();
        else if(percent >= 75f && percent < 100f && lastGrowth == 1)
            Grow();
        else if(percent >= 100f && lastGrowth == 2)
        {
            Grow();
            hasGrown = true;
        }
    }
    void Grow()
    {
        growParticle.Play();
        lastGrowth += 1;
        spriteRenderer.sprite = spritesToChange[(int)lastGrowth];
        StartCoroutine(Bobbing(0.25f));
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

        iterador = 0;
        while (iterador < dividedDuration)
        {
            iterador += Time.deltaTime;
            transform.localScale = Vector2.Lerp(transform.localScale, initialPos, iterador / dividedDuration);
            yield return null;
        }
    }
}
