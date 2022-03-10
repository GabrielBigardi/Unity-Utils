using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HierarchySeparator))]
[CanEditMultipleObjects]
public class HierarchySeparatorEditor : Editor
{
    private SerializedProperty _outlineSize;
    private SerializedProperty _outlineColor;
    private SerializedProperty _barColor;
    private SerializedProperty _textColor;

    public void OnEnable()
    {
        _outlineSize = serializedObject.FindProperty("m_OutlineSize");
        _outlineColor = serializedObject.FindProperty("m_OutlineColor");
        _barColor = serializedObject.FindProperty("m_BarColor");
        _textColor = serializedObject.FindProperty("m_TextColor");
    }
    
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.LabelField("Outline Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_outlineSize);
        EditorGUILayout.PropertyField(_outlineColor);

        EditorGUILayout.Space(10);

        EditorGUILayout.LabelField("Bar Settings", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_barColor);
        EditorGUILayout.PropertyField(_textColor);

        serializedObject.ApplyModifiedProperties();
        //
    }
}