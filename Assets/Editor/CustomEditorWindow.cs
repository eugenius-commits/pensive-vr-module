using UnityEngine;
using UnityEditor;

public class CustomEditorWindow : EditorWindow
{
    private GameObject selectedObject;

    [MenuItem("Window/Custom Editor Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(CustomEditorWindow));
    }

    private void OnGUI()
    {
        GUILayout.Label("Select a GameObject in the scene:");
        selectedObject = EditorGUILayout.ObjectField(selectedObject, typeof(GameObject), true) as GameObject;

        if (GUILayout.Button("Print Selected Object Name"))
        {
            if (selectedObject != null)
            {
                Debug.Log("Selected Object: " + selectedObject.name);
            }
            else
            {
                Debug.LogWarning("No object selected!");
            }
        }
    }
}
