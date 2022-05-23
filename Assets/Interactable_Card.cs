using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEditor.UI;
using UnityEditor;
using UnityEngine.EventSystems;

public class Interactable_Card : Mesh_Interactable
{
  


}


[CustomEditor(typeof(Interactable_Card))]
[CanEditMultipleObjects]
public class Interactable_Card_Editor : Mesh_Interactable_Editor
{


    protected override void OnEnable()
    {
        base.OnEnable();
       // m_SelectedMaterial = serializedObject.FindProperty("SelectedMaterial");
       // m_Renderer = serializedObject.FindProperty("meshRenderer");
    }


    public override void OnInspectorGUI()
    {
        var Target = target as Mesh_Interactable;
        base.OnInspectorGUI();
       // EditorGUILayout.PropertyField(m_SelectedMaterial);
       // EditorGUILayout.PropertyField(m_Renderer);
        serializedObject.ApplyModifiedProperties();
    }


}