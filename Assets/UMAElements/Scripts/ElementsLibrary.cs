using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UMA;

namespace UMAElements
{
	public class ElementsLibrary : MonoBehaviour
	{
		// the static version of the dictionary
		public static Dictionary<int,ElementData> Elements;
		
		// local instance variables - this list will persist - dictionaries dont persist
		public List<ElementData> ElementList;
		public int nextID = 0;

		void Awake()
		{
			Validate();
		}

		public void Validate()
		{
			if(ElementList == null)
			{
				// if the dictionaries don't exist, then create them
				ElementList = new List<ElementData>();
				nextID = 1;
			} else 
			{
				// iterate through the dictionary and find the highest nextID used
				nextID = 0;
				foreach(ElementData ed in ElementList)
				{
					if(ed.Index > nextID) 
						nextID = ed.Index;
				}
				nextID++;
			}
			UpdateStatic();
		}
	
#if UNITY_EDITOR
		public void Add(ElementData ed)
		{
			ed.Index = nextID++;
			UnityEditor.EditorUtility.SetDirty(ed);
			ElementList.Add(ed);
			UpdateStatic();
		}

		public void Remove(int index)
		{
			int listindex = -1;
			for(int i = 0; i < ElementList.Count; i++)
			{
				if(ElementList[i].Index == index)
				{
					listindex = i;
					ElementList[i].Index = 0;
					UnityEditor.EditorUtility.SetDirty(ElementList[i]);
				}
			}
			ElementList.RemoveAt(listindex);
			UpdateStatic();
		}
#endif	

		public void RebuildList()
		{
			// get all ElementData objects in this project
			ElementData[] found = Resources.FindObjectsOfTypeAll<ElementData>();
			
			// delete the current dictionary
			ElementList.Clear();
			
			// fill the dictionary with all found elements that have an ID > 0
			foreach(ElementData e in found)
			{
				if(e.Index > 0) 
					ElementList.Add(e);
			}
		
			// iterate through the dictionary and find the highest nextID used
			nextID = 0;
			foreach(ElementData ed in ElementList)
			{
				if(ed.Index > nextID) 
					nextID = ed.Index;
			}
			nextID++;
			UpdateStatic();
		}

		public Dictionary<int,ElementData> GetDictionary()
		{
			return Elements;
		}
	
		public void UpdateStatic()
		{
			// build the dictionary from the list
			if(Elements == null)
			{
				Elements = new Dictionary<int, ElementData>();
			} 
			else 
			{
				Elements.Clear();
			}
			
			foreach(ElementData ed in ElementList)
			{
				Elements.Add(ed.Index, ed);
			}
		}
	}
}
