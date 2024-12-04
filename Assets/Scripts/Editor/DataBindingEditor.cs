using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DataBinding), true)]
public class DataBindingEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawDefaultInspector();

        var dataBinding = (DataBinding)target;

        // AutoRefreshDataID�� Ȱ��ȭ�Ǿ� �ְ� DataID�� ������Ʈ �̸��� �ٸ��� ����
        if (dataBinding.AutoRefreshDataID && !dataBinding.DataID.Equals(dataBinding.gameObject.name))
        {
            dataBinding.DataID = dataBinding.gameObject.name;
            serializedObject.ApplyModifiedProperties();
        }
    }
}
