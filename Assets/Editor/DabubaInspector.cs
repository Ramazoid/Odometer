using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(Dabuba))]
public class DabubaInspector : Editor
{

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        Dabuba script = (Dabuba)target;

        if (GUILayout.Button("Set Start"))
            script.a = script.gameObject.transform.position;
        if (GUILayout.Button("Set End"))
            script.b = script.gameObject.transform.position;

        DrawDefaultInspector();
    }
}
