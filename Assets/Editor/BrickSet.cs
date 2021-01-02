using UnityEngine;

public class BrickSet
{
    Calculations shape = new Calculations();
    int objectSize;
    Color _boxColor;

    public void CircleSet(float radius, float gapSize, int objectSize, Object matt, Color _boxColor)
    {
        this.objectSize = objectSize;
        this._boxColor = _boxColor;
        int numberOfObjects = shape.CirclePreSet(radius, gapSize, objectSize);
        SetBoxes(numberOfObjects, matt);
    }

    void SetBoxes(int numberOfObjects, Object matt)
    {
        GameObject parentObj = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        GameObject[] boxes = new GameObject[numberOfObjects];

        for (int i = 0; i < boxes.Length; i++)
        {
            Vector3 shapeData = shape.CircleCalc(i);
            boxes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);

            Vector3 pos = boxes[i].transform.position + new Vector3(shapeData.x, 0, shapeData.z);

            Quaternion rot = Quaternion.Euler(0, shapeData.y, 0);

            boxes[i].transform.position = pos;
            boxes[i].transform.rotation = rot;
            boxes[i].transform.localScale = new Vector3(objectSize, objectSize, objectSize);
            boxes[i].GetComponent<MeshRenderer>().material = (Material)matt;
            boxes[i].GetComponent<MeshRenderer>().sharedMaterial.color = _boxColor;
            boxes[i].transform.SetParent(parentObj.transform, false);
        }
    }
}
