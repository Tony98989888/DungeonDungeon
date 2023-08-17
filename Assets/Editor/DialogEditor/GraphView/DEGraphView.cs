using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace DialogEditor
{
    public class DEGraphView : GraphView
    {
        public DEGraphView() : base()
        {
            SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
            Insert(0, new GridBackground());

            var root = new DERootNode();
            AddElement(root);

            this.AddManipulator(new SelectionDragger());

            nodeCreationRequest += context =>
            {
                AddElement(new DEDialogNode());
            };

        }

    }
}

