using UnityEngine;

[CreateAssetMenu(fileName = "HexCell", menuName = "ScriptableObjects/HexCell", order = 1)]
public class HexCellSO : ScriptableObject
{
    public int index;
    public string displayName;
    public Sprite sprite_bg;
    public Sprite sprite_front;
}
