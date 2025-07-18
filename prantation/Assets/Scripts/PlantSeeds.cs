using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlantSeeds : MonoBehaviour
{
    [SerializeField] GameObject plantToInstantiate;
    [SerializeField] Transform firstSpawn;
    [SerializeField] int maxTiles;
    [SerializeField] float spacing;
    [SerializeField] List<Transform> plants;
    public int plantQuantity = -1;
    public static PlantSeeds instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }
    public bool CheckIfHasSpace()
    {
        return plantQuantity <= maxTiles;
    }
    public void Plant(PlantInfo plantInfo)
    {
        if (!CheckIfHasSpace()) return;
        plantQuantity += 1;
        GameObject plant = Instantiate(plantToInstantiate, transform);
        plant.GetComponent<GrowScript>().Setup(plantInfo);
        float y = Random.Range(0, 0.2f);
        plant.transform.position = firstSpawn.position + new Vector3(Mathf.Abs(spacing * plantQuantity), y, 0);
        plants.Add(plant.transform);
    }
    void Update()
    {
        
    }
}
