using UnityEngine;

[CreateAssetMenu(fileName = "PlantInfo", menuName = "Scriptable Objects/PlantInfo")]
public class PlantInfo : ScriptableObject
{
    public string Name;
    public int value;
    public int amountOfMoneyThatGives;
    public float timeToGrows;
    public PlantInfo cropTypeToUnlock;
    public int cropsUntilUnlock;
    public Sprite[] plantGrowSprites = new Sprite[4];
}
