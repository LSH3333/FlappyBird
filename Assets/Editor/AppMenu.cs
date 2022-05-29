using UnityEngine;
using UnityEditor;

public class AppMenu : MonoBehaviour
{
    static string packageFile = "FlappyBird.unitypackage";

    // Export package 
    [MenuItem("My Menu/Export Backup", false, 0)]
    static void action01()
    {
        string[] exportpaths = new string[]
        {
            "Assets/Animations",
            "Assets/Scenes",
            "Assets/Scripts",
            "Assets/Editor",
            "Assets/Fonts",
            "Assets/Plugins",
            "Assets/Resources",
            "Assets/Sprites",
            "ProjectSettings/TagManager.asset",
            "ProjectSettings/EditorBuildSettings.asset"
        };

        AssetDatabase.ExportPackage(exportpaths, packageFile,
            ExportPackageOptions.Interactive |
            ExportPackageOptions.Recurse |
            ExportPackageOptions.IncludeDependencies);

        print("Backup Export Complete!");
    }

    // Import package 
    [MenuItem("My Menu/Import Backup", false, 1)]
    static void action02()
    {
        AssetDatabase.ImportPackage(packageFile, true);
    }

    // 랭킹 리셋 
    [MenuItem("My Menu/Reset Ranking")]
    static void RestRanking()
    {
        PlayerPrefs.DeleteAll();
    }
    
}