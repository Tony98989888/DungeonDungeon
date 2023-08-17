using DialogEditor;
using UnityEngine.UIElements;

namespace DialogEditor
{
    public class DEDialogNode : DESimpleNode
    {
        TextField m_textField;
        public string Content => m_textField.value;

        public DEDialogNode() : base()
        {
            title = "SingleChoiceDialogNode";
            m_textField = new TextField();
            mainContainer.Add(m_textField);
        }
    }
}

