using UnityEngine;

namespace App.View
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(RectTransform))]
    public class SafeAreaView : MonoBehaviour
    {
        private RectTransform _panel;
        private Rect _lastSafeArea = new Rect(0, 0, 0, 0);

        private void Awake()
        {
            _panel = GetComponent<RectTransform>();
            Refresh();
        }

        private void Update()
        {
            Refresh();
        }

        private void Refresh()
        {
            var safeArea = Screen.safeArea;

            if (safeArea != _lastSafeArea)
                ApplySafeArea(safeArea);
        }

        private void ApplySafeArea(Rect rect)
        {
            _lastSafeArea = rect;

            // Convert safe area rectangle from absolute pixels to normalised anchor coordinates
            Vector2 anchorMin = rect.position;
            Vector2 anchorMax = anchorMin + rect.size;
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            _panel.anchorMin = anchorMin;
            _panel.anchorMax = anchorMax;
        }
    }
}