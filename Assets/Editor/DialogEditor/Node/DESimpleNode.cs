using UnityEditor.Experimental.GraphView;

namespace DialogEditor
{
    public class DESimpleNode : DENodeBase
    {
        public DESimpleNode()
        {

            var inputPort = Port.Create<Edge>(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(Port));
            var outputPort = Port.Create<Edge>(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(Port));

            inputPort.portName = "In";
            outputPort.portName = "Out";

            inputContainer.Add(inputPort);
            outputContainer.Add(outputPort);
        }
    }
}

