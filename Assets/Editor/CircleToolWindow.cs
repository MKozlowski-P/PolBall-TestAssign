using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public class CircleToolWindow : EditorWindow
{

    Color _boxColor = Color.green;
    Object[] _matToUse;
    //ScriptableObject circleScriptObj;

    string[] _matToChoose;
    int _matsChoiceIndex = 0;


    BrickSet shapeCreate;

    [MenuItem("CircleTool/CreatingCircle")]

    public static void OpenWindow()
    {
        CircleToolWindow window = (CircleToolWindow)GetWindow(typeof(CircleToolWindow));
        window.minSize = new Vector2(400, 300);
        window.Show();
    }

    private void OnEnable()
    {
        shapeCreate = new BrickSet();
        getMaterials();
    }

    private void OnGUI()
    {
        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Circle Radius (1-50)");
        Calculations.radius = (int)EditorGUILayout.Slider(Calculations.radius, 1, 50, GUILayout.MaxWidth(300));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("BOX Size (1-2)");
        Calculations.boxSize = (int)EditorGUILayout.Slider(Calculations.boxSize, 1, 2, GUILayout.MaxWidth(150));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Gaps Size");
        Calculations.gapSize = (int)EditorGUILayout.Slider(Calculations.gapSize, 1, 10, GUILayout.MaxWidth(150));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Box Color");
        _boxColor = EditorGUILayout.ColorField(_boxColor);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Resources_Material");
        _matsChoiceIndex = EditorGUILayout.Popup(_matsChoiceIndex, _matToChoose);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space(50);

        if (GUILayout.Button("Create circle"))
        {
            shapeCreate.SetBoxes(_matToUse[_matsChoiceIndex], _boxColor);
        }

    }


    private void getMaterials()
    {
        if (!Directory.Exists("Assets/Resources/Material"))
        {
            if (!Directory.Exists("Assets/Resources"))
            {
                AssetDatabase.CreateFolder("Assets", "Resources");
            }
            AssetDatabase.CreateFolder("Assets/Resources", "Material");
        }

        _matToUse = Resources.LoadAll("Material", typeof(Material));

        if (_matToUse == null || _matToUse.Length == 0)
        {
            Material newMat = new Material(Shader.Find("Specular"));
            AssetDatabase.CreateAsset(newMat, "Assets/Resources/Material/DefaultMaterial.mat");
            _matToUse = Resources.LoadAll("Material", typeof(Material));
        }

        _matToChoose = new string[_matToUse.Length];

        if (_matToChoose != null)
            for (int i = 0; i < _matToUse.Length; i++)
            {
                _matToChoose[i] = _matToUse[i].name;
            }
    }
}