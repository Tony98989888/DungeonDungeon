using DialogEditor;
using UnityEditor.Experimental.GraphView;

namespace DialogEditor 
{
    public class DERootNode : DESimpleNode
    {
        public DERootNode() : base() 
        {
            title = "Root";
            capabilities -= UnityEditor.Experimental.GraphView.Capabilities.Deletable;

            inputContainer.Clear();
        }
    }
}

