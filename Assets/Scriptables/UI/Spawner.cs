using UnityEngine;


[CreateAssetMenu(fileName = "NewSpawnerButtonData", menuName = "Resources/Buttons/Spawner")]
public class SpawnerButtonData : ScriptableObject
{
    public string iconPath;
    public string name;
    public int cost;
    public GameObject tower;
}
