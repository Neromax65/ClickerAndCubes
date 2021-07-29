using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace Task2
{
    public class InputValidator : MonoBehaviour
    {
        private const float DefaultValue = 1f;
        public float InputValue { get; private set; } = DefaultValue;
        [SerializeField] private InputField inputField;


        private void OnValidate()
        {
            if (inputField == null)
                inputField = GetComponent<InputField>();
        }

        private void Awake()
        {
            if (inputField == null)
                inputField = GetComponent<InputField>();
            inputField.text = DefaultValue.ToString(CultureInfo.InvariantCulture.NumberFormat);
        }

        void Start()
        {
            inputField.onEndEdit.AddListener(OnEndEdit);
        }
        
        void OnEndEdit(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                float parsedValue = float.Parse(input, NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat);
                if (parsedValue < 0) 
                    parsedValue = InputValue;
                inputField.text = parsedValue.ToString(CultureInfo.InvariantCulture.NumberFormat);
                InputValue = parsedValue;
            }
            else
            {
                inputField.text = InputValue.ToString(CultureInfo.InvariantCulture.NumberFormat);
            }
        }
    }
}
