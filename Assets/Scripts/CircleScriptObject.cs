using UnityEngine;

[CreateAssetMenu(fileName = "CircleData", menuName = "ScriptableObjects/CircleToolScriptableObject", order = 1)]
public class CircleScriptObject : ScriptableObject
{
    [Range(2, 30)]
    public float radius = 3;
    [Range(1, 10)]
    public float gapSize = 1;
    [Range(1, 2)]
    public int objectSize = 1;
    public Material material;
    public Color boxColor = Color.green;
}
