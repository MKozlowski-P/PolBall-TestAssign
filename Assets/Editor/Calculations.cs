using UnityEngine;

public class Calculations
{
    int numberOfObjects;
    float radius;

    public int CirclePreSet(float radius, float gapSize, int objectSize)
    {
        this.radius = radius;
        float circ = 2 * Mathf.PI * radius;
        float objSizeWithGaps = objectSize + objectSize * (objectSize / radius * gapSize);
        return numberOfObjects = (int)(circ / objSizeWithGaps);
    }

    public Vector3 CircleCalc(int step)
    {
        Vector3 cCalc;
        float angle = step * Mathf.PI * 2 / numberOfObjects;
        cCalc.x = Mathf.Cos(angle) * radius;
        cCalc.z = Mathf.Sin(angle) * radius;
        cCalc.y = -angle * Mathf.Rad2Deg;
        return cCalc;

    }
}
