using UnityEngine;

public class BrickSet
{
    public void SetBoxes(Object matt, Color _boxColor)
    {
        Calculations.CirclePreSet();
        GameObject parentObj = new GameObject("Circle Parent object");
        GameObject[] boxes = new GameObject[Calculations.numberOfObjects];

        for (int i = 0; i < boxes.Length; i++)
        {
            Vector3 shapeData = Calculations.CircleCalc(i);

            boxes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);

            Vector3 pos = boxes[i].transform.position + new Vector3(shapeData.x, 0, shapeData.z);

            Quaternion rot = Quaternion.Euler(0, shapeData.y, 0);

            boxes[i].transform.position = pos;
            boxes[i].transform.rotation = rot;
            boxes[i].transform.localScale = new Vector3(Calculations.boxSize, Calculations.boxSize, Calculations.boxSize);
            boxes[i].GetComponent<MeshRenderer>().material = (Material)matt;
            boxes[i].GetComponent<MeshRenderer>().sharedMaterial.color = _boxColor;
            boxes[i].transform.SetParent(parentObj.transform, false);
        }
    }
}
