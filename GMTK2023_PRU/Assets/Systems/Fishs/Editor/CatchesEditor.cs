using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Fish), true)]
public class CatchesEditor : Editor
{
    Fish item;

    private void OnEnable()
    {
        item = target as Fish;
    }

    public override void OnInspectorGUI()
    {
        if (item.preyIcon == null)
        {
            base.OnInspectorGUI();
            return;
        }

        Texture2D texture = AssetPreview.GetAssetPreview(item.preyIcon);
        GUILayout.Label("", GUILayout.Height(80), GUILayout.Width(80));
        GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
        base.OnInspectorGUI();
    }
}