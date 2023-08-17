using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace DialogEditor 
{
    public class DESearchWindow : ScriptableObject, ISearchWindowProvider
    {
        DEGraphView m_parent;

        public void Initialize(DEGraphView graphView)
        {
            m_parent = graphView;
        }

        public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
        {
            var entries = new List<SearchTreeEntry>();
            entries.Add(new SearchTreeGroupEntry(new GUIContent("Create Node")));

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.IsClass && !type.IsAbstract && (type.IsSubclassOf(typeof(DENodeBase))) && type != typeof(DERootNode))
                    {
                        entries.Add(new SearchTreeEntry(new GUIContent(type.Name)) 
                        {
                            level = 1,
                            userData = type,
                        });
                    }
                }
            }
            return entries;
        }

        public bool OnSelectEntry(SearchTreeEntry SearchTreeEntry, SearchWindowContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}

