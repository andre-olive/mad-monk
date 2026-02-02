using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 1)]
public class LevelSO : ScriptableObject
{
    public int index;
    public string displayName;
    public List<HexCellSO> hexcellList;
}
