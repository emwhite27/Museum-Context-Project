using UnityEditor;
using UnityEngine;

namespace Editor{
    [CustomEditor(typeof(TextInteractor))]
    public class TextInteractorEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            TextInteractor textInteractor = target as TextInteractor;
            if (textInteractor == null) return;
            if (GUILayout.Button("Update Text"))
            {
                Debug.Log("Updating text, please wait...");
                textInteractor.UpdateText();
            }
            GUILayout.Space(5);
            if (GUILayout.Button("Add Model"))
            {
                if (ModelExists(textInteractor))
                {
                    Debug.LogWarning("Models Detected, please remove them first");
                }
                else
                {
                    Debug.Log("Creating model, please wait...");
                    InstantiatePrefab(textInteractor);
                }
            }
            GUILayout.Space(5);
            if (GUILayout.Button("Delete Model"))
            {
                if (!ModelExists(textInteractor))
                {
                    Debug.LogWarning("No Models Detected!");
                }
                else
                {
                    DeleteModels(textInteractor);
                }
            }
            GUILayout.Space(5);
            DrawDefaultInspector();
        }
        
        private static bool ModelExists(TextInteractor textPanelInteractor) 
        {
            foreach (Transform child in textPanelInteractor.transform) {
                if (!child.CompareTag($"TextPanel")) {
                    return true;
                }
            }
            return false;
        }

        private static void DeleteModels(TextInteractor textPanelInteractor)
        {
            foreach (Transform child in textPanelInteractor.transform) {
                if (child.CompareTag($"TextPanel")) continue;
                Debug.Log("Destroying "+child.name);
                DestroyImmediate(child.gameObject);
                return;
            }
        }

        private static void InstantiatePrefab(TextInteractor textPanelInteractor)
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
