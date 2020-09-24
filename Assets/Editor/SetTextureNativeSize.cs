using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class SetTextureNativeSize
    {
        //.jpg
        //.png
        [MenuItem("Tools/SetTextureNativeSize")]
        public static void Execute()
        {
            var p = @"Z:/PhygiRepos/supersecretrepo/";
            var root = @"Assets/XzibitMaterials/Materials/New";

            var res = GetSubFoldersRecursive(root);
            foreach (var path in res)
            {
                var s = Path.Combine(p, path);
                var ress = Directory.GetFiles(s);
                foreach (var f in ress)
                {
                    if (f.EndsWith(".jpg") || f.EndsWith(".png") || f.EndsWith(".jpeg"))
                    {
                        var temp = f.Replace(p, String.Empty);
                        TextureImporter importer = (TextureImporter)TextureImporter.GetAtPath(temp);
                        try
                        {
                            importer.alphaIsTransparency = true;
                            importer.npotScale = TextureImporterNPOTScale.None;
                            importer.textureCompression = TextureImporterCompression.Uncompressed;
                            EditorUtility.SetDirty(importer);
                            importer.SaveAndReimport();
                        }
                        catch (Exception e)
                        {
                            Debug.Log(e);
                        }

                    }
                }
            }
        }
        
        private static string[] GetSubFoldersRecursive(string root)
        {
            var paths = new List<string>();

            // If there are no further subfolders then AssetDatabase.GetSubFolders returns 
            // an empty array => foreach will not be executed
            // This is the exit point for the recursion
            foreach (var path in AssetDatabase.GetSubFolders(root))
            {
                // add this subfolder itself
                paths.Add(path);

                // If this has no further subfolders then simply no new elements are added
                paths.AddRange(GetSubFoldersRecursive(path));
            }

            return paths.ToArray();
        }
    }
}