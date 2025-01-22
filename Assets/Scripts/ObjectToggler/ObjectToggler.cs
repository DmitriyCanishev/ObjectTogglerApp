using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ObjectToggler.Transitions;
using UnityEngine;

namespace ObjectToggler
{
    [DisallowMultipleComponent]
    public class ObjectToggler : MonoBehaviour
    {
        [SerializeField] private ObjectTogglerControl _objectTogglerControl = null;
        [SerializeField] private string _enableOnInit = null;
        [SerializeField] private List<Case> _cases = null;

        private Case _currentSelection = null;

        private void Awake()
        {
            if (_objectTogglerControl)
            {
                _objectTogglerControl.TargetObjectToggler = this;
            }

            foreach (var @case in _cases)
            {
                var isEnabledOnInit = @case.CaseName == _enableOnInit;
                @case.CaseObject.gameObject.SetActive(isEnabledOnInit);
                if (isEnabledOnInit)
                {
                    _currentSelection = @case;
                }
            }
        }

        public void DisableAll()
        {
            foreach (var @case in _cases)
            {
                @case.CaseObject.gameObject.SetActive(false);
            }

            _currentSelection = null;
        }

        public void Toggle(string caseName)
        {
            Toggle(caseName, true);
        }

        public void ToggleBackward(string caseName)
        {
            Toggle(caseName, false);
        }

        private async void Toggle(string caseName, bool isForwardTransition)
        {
            if (_currentSelection?.CaseName == caseName)
            {
                return;
            }
            await Task.Delay(35);
            var targetCase = _cases.FirstOrDefault(it => it.CaseName == caseName);
            if (targetCase != null)
            {
                var targetTransition = isForwardTransition ? targetCase.Transition : _currentSelection?.BackTransition;
                if (_currentSelection != null && targetTransition != null)
                {
                    targetTransition.BeforeTransition(_currentSelection?.CaseObject, targetCase.CaseObject);
                    targetCase.CaseObject.gameObject.SetActive(true);

                    await targetTransition.Transition(_currentSelection.CaseObject, targetCase.CaseObject);

                    targetTransition.AfterTransition(_currentSelection.CaseObject, targetCase.CaseObject);
                    _currentSelection?.CaseObject.gameObject.SetActive(false);
                }
                else
                {
                    targetCase.CaseObject.gameObject.SetActive(true);
                    _currentSelection?.CaseObject.gameObject.SetActive(false);
                }

                _currentSelection = targetCase;
            }
            else
            {
                Debug.LogError($"This object doesn't exist. Check that the Name ({caseName}) field is correct");
            }
        }

        [Serializable]
        public class Case
        {
            [SerializeField] private string _caseName = null;
            [SerializeField] private Transform _caseObject = null;
            [SerializeField] private AbstractTogglerTransition _transition = null;
            [SerializeField] private AbstractTogglerTransition _backTransition = null;

            public string CaseName => _caseName;
            public Transform CaseObject => _caseObject;
            public AbstractTogglerTransition Transition => _transition;
            public AbstractTogglerTransition BackTransition => _backTransition;
        }
    }
}