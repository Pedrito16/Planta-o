using System.Collections;
using UnityEngine;

public class WeedScript : MonoBehaviour
{
    [SerializeField] float timeToGrow = 0.5f; // Time in minutes for the weed to grow
    float timeElapsed = 0f;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public IEnumerator GrowEnumerator()
    {
        float timeInSeconds = timeToGrow * 60f;
        float iterador = 0f;
        while(iterador < 1)
        {
            iterador += Time.deltaTime;
            yield return null;
        }

    }
}
