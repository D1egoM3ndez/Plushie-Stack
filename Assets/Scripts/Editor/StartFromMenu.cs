using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public static class StartFromMenu
{
    static StartFromMenu()
    {
        EditorSceneManager.playModeStartScene =
            AssetDatabase.LoadAssetAtPath<SceneAsset>("Assets/Scenes/Menu.unity");
    }
}