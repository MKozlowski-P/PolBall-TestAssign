using UnityEngine;

public class BrickSet
{
    private readonly Material boxMaterial;
    private Color boxColor;
    private GameObject mainParentObject;
    private GameObject parentObject;

    public BrickSet(GameObject parentObject, Material boxMaterial, Color boxColor)
    {
        this.boxMaterial = boxMaterial;
        this.boxColor = boxColor;
        mainParentObject = parentObject;
    }
    public BrickSet(Material boxMaterial, Color boxColor)
    {
        this.boxMaterial = boxMaterial;
        this.boxColor = boxColor;
    }
    public BrickSet(Color boxColor)
    {
        this.boxColor = boxColor;
    }

    public void SetBoxes()
    {
        Calculations.ShapePreSet();
        if (mainParentObject == null)
        {
            mainParentObject = new GameObject("Circle Main Parent object");
            parentObject = new GameObject("Circle Parent object");
        }
        else
        {
            parentObject = new GameObject("Circle Parent object");
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
            if (boxMaterial != null)
            {
                boxes[i].GetComponent<MeshRenderer>().material = boxMaterial;
            }
            else
            {
                boxes[i].GetComponent<MeshRenderer>().sharedMaterial.color = boxColor;
                //boxes[i].GetComponent<Renderer>().material.color = _boxColor;
            }

            boxes[i].transform.SetParent(parentObject.transform, false);
        }

        parentObject.transform.SetParent(mainParentObject.transform, false);
    }
}
