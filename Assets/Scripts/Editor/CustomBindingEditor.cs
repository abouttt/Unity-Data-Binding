using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CustomBinding), true)]
public class CustomBindingEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawDefaultInspector();

        // Ÿ�� �̸����� ������Ʈ ã��
        var customBinding = (CustomBinding)target;

        if (!string.IsNullOrEmpty(customBinding.TypeName))
        {
            customBinding.Target = customBinding.GetComponent(customBinding.TypeName);
            if (customBinding.Target == null)
            {
                EditorGUILayout.HelpBox($"Invalid type name: {customBinding.TypeName}", MessageType.Error);
            }
        }
        else
        {
            EditorGUILayout.HelpBox("Type Name is empty.", MessageType.Info);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
