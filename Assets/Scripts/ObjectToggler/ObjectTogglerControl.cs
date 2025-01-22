using UnityEngine;

namespace App.ObjectToggler
{
    [CreateAssetMenu(menuName = "ObjectTogglerMenu/ObjectTogglerControl")]
    public class ObjectTogglerControl : ScriptableObject
    {
        public ObjectToggler TargetObjectToggler { get; set; }

        public void DisableAll() => TargetObjectToggler.DisableAll();

        public void Toggle(string caseName) => TargetObjectToggler.Toggle(caseName);
        public void ToggleBackward(string caseName) => TargetObjectToggler.ToggleBackward(caseName);
    }
}