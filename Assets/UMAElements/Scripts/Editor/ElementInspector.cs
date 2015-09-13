using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;


namespace UMAElements
{
	[CustomEditor(typeof(ElementData))]
	public class ElementInspector : Editor
	{
		[MenuItem("Assets/Create/UMA Element")]
		public static void CreateElementMenuItem()
		{
			CreateAsset<ElementData>();
		}
		
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
		}
		
		public static void CreateAsset<T>() where T : ScriptableObject
		{
			T asset = ScriptableObject.CreateInstance<T>();
			string path = AssetDatabase.GetAssetPath(Selection.activeObject);

			if(path == "")
			{
				path = "Assets";
			} else if(File.Exists(path)) {
				path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
			}
			
			string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/New " + typeof(T).Name + ".asset");
			
			AssetDatabase.CreateAsset(asset, assetPathAndName);
			
			AssetDatabase.SaveAssets();
			EditorUtility.FocusProjectWindow();
			Selection.activeObject = asset;
		}
		
		protected ElementData element;
		
		public void OnEnable()
		{
			element = target as ElementData;
		}
		
	}
}
