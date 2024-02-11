using UnityEditor;
using UnityEngine;

namespace Editor{
    [CustomEditor(typeof(AudioInteractor))]
    public class AudioInteractorEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            AudioInteractor audioInteractor = target as AudioInteractor;
            if (audioInteractor == null) return;
            if (GUILayout.Button("Add Model"))
            {
                if (ModelExists(audioInteractor))
                {
                    Debug.LogWarning("Models Detected, please remove them first");
                }
                else
                {
                    Debug.Log("Creating model, please wait...");
                    InstantiatePrefab(audioInteractor);
                }
            }
            GUILayout.Space(5);
            if (GUILayout.Button("Delete Model"))
            {
                if (!ModelExists(audioInteractor))
                {
                    Debug.LogWarning("No Models Detected!");
                }
                else
                {
                    DeleteModels(audioInteractor);
                }
            }
            GUILayout.Space(5);
            DrawDefaultInspector();
        }
        
        private static bool ModelExists(AudioInteractor audioInteractor) 
        {
            foreach (Transform child in audioInteractor.transform) {
                if (!child.CompareTag($"TextPanel")) {
                    return true;
                }
            }
            return false;
        }

        private static void DeleteModels(AudioInteractor audioInteractor)
        {
            foreach (Transform child in audioInteractor.transform) {
                if (child.CompareTag($"TextPanel")) continue;
                Debug.Log("Destroying "+child.name);
                DestroyImmediate(child.gameObject);
                return;
            }
        }

        private static void InstantiatePrefab(AudioInteractor audioInteractor)
        {
            if (audioInteractor.Model != null)
            {
                GameObject model = Instantiate(audioInteractor.Model, audioInteractor.transform.position, Quaternion.identity);

                model.transform.parent = audioInteractor.transform;

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
