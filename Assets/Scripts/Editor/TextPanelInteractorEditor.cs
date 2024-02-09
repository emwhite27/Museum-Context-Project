using UnityEditor;
using UnityEngine;

namespace Editor{
    [CustomEditor(typeof(TextPanelInteractor))]
    public class TextPanelInteractorEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            TextPanelInteractor textPanelInteractor = target as TextPanelInteractor;
            if (textPanelInteractor == null) return;
            if (GUILayout.Button("Update Text"))
            {
                Debug.Log("Updating text, please wait...");
                textPanelInteractor.UpdateText();
            }
            if (GUILayout.Button("Add Model"))
            {
                if (ModelExists(textPanelInteractor))
                {
                    Debug.LogWarning("Models Detected, please remove them first");
                }
                else
                {
                    Debug.Log("Creating model, please wait...");
                    InstantiatePrefab(textPanelInteractor);
                }
            }

            if (GUILayout.Button("Delete Model"))
            {
                if (!ModelExists(textPanelInteractor))
                {
                    Debug.LogWarning("No Models Detected!");
                }
                else
                {
                    DeleteModels(textPanelInteractor);
                }
            }

            DrawDefaultInspector();
        }
        
        private static bool ModelExists(TextPanelInteractor textPanelInteractor) 
        {
            foreach (Transform child in textPanelInteractor.transform) {
                if (!child.CompareTag($"TextPanel")) {
                    return true;
                }
            }
            return false;
        }

        private static void DeleteModels(TextPanelInteractor textPanelInteractor)
        {
            foreach (Transform child in textPanelInteractor.transform) {
                if (child.CompareTag($"TextPanel")) continue;
                Debug.Log("Destroying "+child.name);
                DestroyImmediate(child.gameObject);
                return;
            }
        }

        private static void InstantiatePrefab(TextPanelInteractor textPanelInteractor)
        {
            if (textPanelInteractor.Model != null)
            {
                GameObject model = Instantiate(textPanelInteractor.Model, textPanelInteractor.transform.position, Quaternion.identity);

                model.transform.parent = textPanelInteractor.transform;

                model.transform.localPosition = Vector3.zero;
                model.transform.localRotation = Quaternion.identity;
                model.transform.localScale = Vector3.one;

                Undo.RegisterCreatedObjectUndo(model, "Instantiate Model");
            }
            else
            {
                Debug.LogWarning("Model is not assigned in the TextPanelInteractor script.");
            }
        }
    }
}
