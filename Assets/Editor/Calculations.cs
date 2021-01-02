using UnityEngine;

public static class Calculations
{
    public static int numberOfObjects; //{ get; set; }
    public static float gapSize;
    public static float radius = 5;
    public static int boxSize;

    public static void CirclePreSet()
    {
        float circ = 2 * Mathf.PI * radius;
        float objSizeWithGaps = boxSize + boxSize * (boxSize / radius * gapSize);
        numberOfObjects = (int)(circ / objSizeWithGaps);
    }

    public static Vector3 CircleCalc(int step)
    {
        Vector3 cCalc;
        float angle = step * Mathf.PI * 2 / numberOfObjects;
        cCalc.x = Mathf.Cos(angle) * radius;
        cCalc.z = Mathf.Sin(angle) * radius;
        cCalc.y = -angle * Mathf.Rad2Deg;
        return cCalc;
    }
}
