using UnityEngine;

public class BrickSet
{
    private Material _boxMaterial;
    private Color _boxColor;
    private GameObject _parentObject;

    public BrickSet(GameObject parentObject, Material boxMaterial, Color boxColor)
    {
        _boxMaterial = boxMaterial;
        _boxColor = boxColor;
        _parentObject = parentObject;
    }
    public BrickSet(Material boxMaterial, Color boxColor)
    {
        _boxMaterial = boxMaterial;
        _boxColor = boxColor;
    }
    public BrickSet(Color boxColor)
    {
        _boxColor = boxColor;
    }

    public void SetBoxes()
    {
        Calculations.CirclePreSet();
        if (_parentObject == null)
        {
            _parentObject = new GameObject("Circle Parent object");
        }

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
            if (_boxMaterial != null)
            {
                boxes[i].GetComponent<MeshRenderer>().material = _boxMaterial;
            }
            else
            {
                boxes[i].GetComponent<MeshRenderer>().sharedMaterial.color = _boxColor;
            }
            boxes[i].transform.SetParent(_parentObject.transform, false);
        }
    }
}
