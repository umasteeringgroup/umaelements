using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using UMAElements;


[CustomEditor(typeof(ElementsLibrary))]
[CanEditMultipleObjects]


public class ElementsLibraryEditor : Editor
{
	private ElementsLibrary thistarget;
	private bool sortByID = true;
	
	
	void OnEnable()
	{
		// set the target
		thistarget = (ElementsLibrary)target;	
		// do a validate
		thistarget.Validate();
	}
	
	
	public override void OnInspectorGUI()
	{
		// get the dictionary
		Dictionary<int,ElementData> tmpElements = thistarget.GetDictionary();
		
		// do the sort
		List<int> keylist = new List<int>(tmpElements.Keys);
		if(sortByID)
		{
			keylist.Sort();
		} else {
			int maxiter = 1000000;
			while(--maxiter > 0)
			{
				bool haschanged = false;
				for(int i = 0; i < keylist.Count-1; i++)
				{
					
					if(String.Compare(tmpElements[keylist[i]].Name, tmpElements[keylist[i+1]].Name) > 0)
					{
						int tmp = keylist[i+1];
						keylist[i+1] = keylist[i];
						keylist[i] = tmp;
						haschanged = true;
					}
				}
				if(!haschanged) break;
			}
		}
		
		// the title
		GUILayout.Label("Elements Library List", EditorStyles.boldLabel);
		
		// the 3 buttons
		GUILayout.BeginHorizontal();
		if(GUILayout.Button ("Order By Name"))
		{
			sortByID = false;
			Repaint();
		}
		if(GUILayout.Button ("Order By ID"))
		{
			sortByID = true;
			Repaint();
		}
		if(GUILayout.Button ("Rebuild List"))
		{
			thistarget.RebuildList();
			Repaint();
		}
		
		
		GUILayout.EndHorizontal();
		
		// the drop area
		GUILayout.Space(20);
		Rect dropArea = GUILayoutUtility.GetRect(0.0f, 50.0f, GUILayout.ExpandWidth(true));
		GUI.Box(dropArea, "Drag Elements here");
		GUILayout.Space(20);
		
		// the titles
		GUILayout.BeginHorizontal();
		GUILayout.Label("ID", GUILayout.Width(40));
		GUILayout.Label("Element Name");
		GUILayout.EndHorizontal();
		
		// now show the list
		foreach(int idx in keylist)
		{
			//KeyValuePair<int,ElementData> entry = tmpElements[idx];
			
			// start the layout
			GUILayout.BeginHorizontal();
			
			// show the id
			GUILayout.TextField(""+idx, GUILayout.Width(40));
			
			// show the object
			EditorGUILayout.ObjectField(tmpElements[idx], typeof(ElementData), true);
			
			if(GUILayout.Button("-", GUILayout.Width(20)))
			{
				thistarget.Remove(idx);
			}
			
			// end the layout
			GUILayout.EndHorizontal();
			GUILayout.Space(4);
		}
		
		// do the drop area
		DropAreaGUI(dropArea);
	}
	
	
	
	private void DropAreaGUI(Rect dropArea)
	{
		var evt = Event.current;
		if(evt.type == EventType.DragUpdated)
		{
			if(dropArea.Contains(evt.mousePosition))
			{
				DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
			}
		}
		if(evt.type == EventType.DragPerform)
		{
			if(dropArea.Contains(evt.mousePosition))
			{
				DragAndDrop.AcceptDrag();
				UnityEngine.Object[] draggedObjects = DragAndDrop.objectReferences as UnityEngine.Object[];
				for(int i = 0; i < draggedObjects.Length; i++)
				{
					if(draggedObjects[i])
					{
						ElementData tempElementData = draggedObjects[i] as ElementData;
						if(tempElementData)
						{
							thistarget.Add(tempElementData);
							continue;
						}
						var path = AssetDatabase.GetAssetPath(draggedObjects[i]);
						if(System.IO.Directory.Exists(path))
						{
							var assetFiles = System.IO.Directory.GetFiles(path, "*.asset");
							foreach(var assetFile in assetFiles)
							{
								tempElementData = AssetDatabase.LoadAssetAtPath(assetFile, typeof(ElementData)) as ElementData;
								if(tempElementData)
								{
									thistarget.Add(tempElementData);
								}
							}
						}
					}
				}
			}
		}
	}
	
	
}
