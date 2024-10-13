using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameData", menuName = "Resources/Game/Data")]
public class GameData : ScriptableObject {
    public float money;
    public float lives;
    public GameObject[] placedTowers;
}
