using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/*
[CustomEditor(typeof(PlatformObject))]
public class PlatformObjectEditor : Editor
{
    // Start is called before the first frame update
    private PlatformObject platformObject;

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        platformObject = (PlatformObject)target;

        SerializedObject serializedObject = new SerializedObject(platformObject);
        serializedObject.Update();

        SerializedProperty serializedPropertyList = serializedObject.FindProperty("platformEvent");

        Draw(serializedPropertyList);
    }

    private void Draw(SerializedProperty list)
    {
        EditorGUILayout.PropertyField(list);
    }
}
*/