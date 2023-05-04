using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEditor.UI;
using UnityEditor;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Mesh_Interactable : Selectable
{
    public Material SelectedMaterial;
    public bool highlighted = false;
    public bool selected = false;
    [SerializeField]Renderer meshRenderer;
    public bool InteractableOverride = false;

    public UnityEvent OnLeftClick = new UnityEvent();
    public UnityEvent OnMiddleClick = new UnityEvent();
    public UnityEvent OnRightClick = new UnityEvent();

    public override bool IsInteractable()    
    {
        switch (InteractableOverride)
        {
            default:
                return interactable;

            case true:
                return false;              
        }

        
    }
   

    public virtual void EditorSelect(Material SelectMaterial)
    {
        if (selected == false && interactable)
        {
            selected = true;
            Material[] newMaterialArray = meshRenderer.materials;
            List<Material> newMaterials = newMaterialArray.ToList<Material>();
            newMaterials.Add(SelectMaterial);
            meshRenderer.materials = newMaterials.ToArray();
            print("OBJECT SELECTED");
        }
    }

    public virtual void EditorDeselect()
    {

        if (selected == true)
        {
            Material[] newMaterialArray = meshRenderer.materials;
            List<Material> newMaterials = newMaterialArray.ToList<Material>();
            newMaterials.RemoveAt(newMaterials.Count - 1);
            meshRenderer.materials = newMaterials.ToArray();

            selected = false;
            print("OBJECT DESELECTED");
        }
    }




    #region Interactable_Intermediaries
    private void OnMouseEnter()
    {
        OnPointerEnter(new PointerEventData(EventSystem.current));
        EditorSelect(SelectedMaterial);
    }

    private void OnMouseExit()
    {
        OnPointerExit(new PointerEventData(EventSystem.current));
        EditorDeselect();
    }

    private void OnMouseDown()
    {
        OnPointerDown(new PointerEventData(EventSystem.current));
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        print("Pointer down firing");
        base.OnPointerDown(eventData);
        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                OnLeftClick.Invoke();
                break;
            case PointerEventData.InputButton.Middle:
                OnMiddleClick.Invoke();
                break;
            case PointerEventData.InputButton.Right:
                OnRightClick.Invoke();
                break;

        }
    }



    #endregion


    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        print("pointer entered");
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
    }


    private IEnumerator ScaleObject(Vector3 newSize, float time)
    {

        yield return null;
    }
}

[CustomEditor (typeof (Mesh_Interactable))]
[CanEditMultipleObjects]
public class Mesh_Interactable_Editor : SelectableEditor
{

    internal SerializedProperty m_SelectedMaterial;
    internal SerializedProperty m_Renderer;

    internal SerializedProperty m_LeftClickEvent;
    internal SerializedProperty m_RightClickEvent;
    internal SerializedProperty m_MiddleClickEvent;

    protected override void OnEnable()
    {
        base.OnEnable();
        m_SelectedMaterial = serializedObject.FindProperty("SelectedMaterial");
        m_Renderer = serializedObject.FindProperty("meshRenderer");
        m_LeftClickEvent = serializedObject.FindProperty("OnLeftClick");
        m_RightClickEvent = serializedObject.FindProperty("OnRightClick");
        m_MiddleClickEvent = serializedObject.FindProperty("OnMiddleClick");
    }
   

     public override void OnInspectorGUI()
    {
        var Target = target as Mesh_Interactable;
        base.OnInspectorGUI();

        EditorGUILayout.PropertyField(m_SelectedMaterial);
        EditorGUILayout.PropertyField(m_Renderer);
        EditorGUILayout.PropertyField(m_LeftClickEvent);
        EditorGUILayout.PropertyField(m_RightClickEvent);
        EditorGUILayout.PropertyField(m_MiddleClickEvent);
        serializedObject.ApplyModifiedProperties();
    }


}


