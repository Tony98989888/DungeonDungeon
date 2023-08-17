using UnityEditor;
namespace DialogEditor
{
    public class DEDialogEditorWindow : EditorWindow
    {
        [MenuItem("Window/Dialog Editor Window")]
        public static void ShowWindow()
        {
            GetWindow<DEDialogEditorWindow>("DialogEditor");
        }

        private void OnEnable()
        {
            var dialogGraph = new DEGraphView()
            {
                style = { flexGrow = 1 }
            };
            rootVisualElement.Add(dialogGraph);
        }
    }
}

