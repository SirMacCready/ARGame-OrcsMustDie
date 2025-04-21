using UnityEngine;
using System.IO;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MaterialCreator : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("Tools/Create URP Materials from Textures")]
    static void CreateMaterialsFromTextures()
    {
        string folderPath = EditorUtility.OpenFolderPanel("Select Texture Folder", "", "");
        if (string.IsNullOrEmpty(folderPath))
        {
            Debug.Log("Folder selection canceled.");
            return;
        }

        string[] textureFiles = Directory.GetFiles(folderPath, "*.png")
                                 .Concat(Directory.GetFiles(folderPath, "*.jpg"))
                                 .ToArray();

        if (textureFiles.Length == 0)
        {
            Debug.LogWarning("No PNG or JPG files found in the selected folder.");
            return;
        }

        Shader urpLitShader = Shader.Find("Universal Render Pipeline/Lit");
        if (urpLitShader == null)
        {
            Debug.LogError("URP Lit shader not found. Please ensure URP is set up correctly in your project.");
            return;
        }

        foreach (string textureFile in textureFiles)
        {
            string textureName = Path.GetFileNameWithoutExtension(textureFile);
            Debug.Log($"Processing texture: {textureName}");

            Material material = new Material(urpLitShader);
            material.name = textureName;

            Texture2D texture = new Texture2D(2, 2);
            byte[] fileData = File.ReadAllBytes(textureFile);
            if (!texture.LoadImage(fileData))
            {
                Debug.LogError($"Failed to load texture: {textureName}");
                continue;
            }

            // Ensure the texture is readable and not compressed
            texture.Apply(false, true);

            // Check if the texture is valid
            if (texture.width == 0 || texture.height == 0)
            {
                Debug.LogError($"Texture {textureName} is invalid (width: {texture.width}, height: {texture.height}).");
                continue;
            }

            material.SetTexture("_BaseMap", texture);

            string materialPath = Path.Combine("Assets/Materials", textureName + ".mat");
            Directory.CreateDirectory("Assets/Materials");
            AssetDatabase.CreateAsset(material, materialPath);
            Debug.Log($"Material created: {materialPath}");
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("Materials created successfully.");
    }
#endif
}