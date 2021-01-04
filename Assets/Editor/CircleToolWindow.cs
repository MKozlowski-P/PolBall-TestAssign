using UnityEngine;
using UnityEditor;

public class CircleToolWindow : EditorWindow
{
    private Color _boxColor = Color.green;
    private Material _matToUse;
    private CircleScriptObject _circleScriptObj;
    private GameObject _selectedObject;

    BrickSet shapeCreate;

    [MenuItem("CircleTool/CreatingCircle")]
    public static void OpenWindow()
    {
        CircleToolWindow window = (CircleToolWindow)GetWindow(typeof(CircleToolWindow));
        window.minSize = new Vector2(400, 350);
        window.Show();
    }

    private void OnGUI()
    {
        EditorGUILayout.Space();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Set values:");
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Circle Radius (2-50)");
        Calculations.radius = (int)EditorGUILayout.Slider(Calculations.radius, 2, 30, GUILayout.MaxWidth(265));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("BOX Size (1-2)");
        Calculations.boxSize = (int)EditorGUILayout.Slider(Calculations.boxSize, 1, 2, GUILayout.MaxWidth(150));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Gaps Size");
        Calculations.gapSize = (int)EditorGUILayout.Slider(Calculations.gapSize, 1, 10, GUILayout.MaxWidth(265));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Box Color");
        _boxColor = EditorGUILayout.ColorField(_boxColor);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Material");
        _matToUse = (Material)EditorGUILayout.ObjectField(_matToUse, typeof(Material), false);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space(10);

        if (GUILayout.Button("Create circle"))
        {
            _selectedObject = Selection.activeGameObject;
            shapeCreate = new BrickSet(_selectedObject, _matToUse, _boxColor);
            shapeCreate.SetBoxes();
        }

        EditorGUILayout.Space(50);

        if (GUILayout.Button("Save data to scriptableObject (Assets/Editor)"))
        {
            SaveToScriptObject();
        }

        EditorGUILayout.Space(10);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Scriptable Object Data");
        _circleScriptObj = (CircleScriptObject)EditorGUILayout.ObjectField(_circleScriptObj, typeof(ScriptableObject), false);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space(10);

        if (GUILayout.Button("Create Circle from scriptableObject data"))
        {
            LoadCreateFromScriptObject();
        }

        void SaveToScriptObject()
        {
            if (_circleScriptObj == null)
            {
                CircleScriptObject circScriptObj = CreateInstance<CircleScriptObject>();
                circScriptObj.radius = Calculations.radius;
                circScriptObj.gapSize = Calculations.gapSize;
                circScriptObj.objectSize = Calculations.boxSize;
                circScriptObj.material = _matToUse;
                circScriptObj.boxColor = _boxColor;
                AssetDatabase.CreateAsset(circScriptObj, "Assets/Editor/CircleData.asset");
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
            else
            {
                _circleScriptObj.radius = Calculations.radius;
                _circleScriptObj.gapSize = Calculations.gapSize;
                _circleScriptObj.objectSize = Calculations.boxSize;
                if (_circleScriptObj.material != null)
                {
                    _circleScriptObj.material = _matToUse;
                }
                _circleScriptObj.boxColor = _boxColor;
            }
        }

        void LoadCreateFromScriptObject()
        {
            if (_circleScriptObj != null)
            {
                _selectedObject = Selection.activeGameObject;
                Calculations.radius = _circleScriptObj.radius;
                Calculations.gapSize = _circleScriptObj.gapSize;
                Calculations.boxSize = _circleScriptObj.objectSize;
                if (_circleScriptObj.material != null)
                {
                    _matToUse = _circleScriptObj.material;
                }
                _boxColor = _circleScriptObj.boxColor;
                shapeCreate = new BrickSet(_selectedObject, _matToUse, _boxColor);
                shapeCreate.SetBoxes();
            }
            else
            {
                Debug.Log("No scriptableObject attached");
            }
        }
    }
}