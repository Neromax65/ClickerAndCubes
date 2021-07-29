using UnityEngine;
using UnityEngine.UI;

namespace Task1
{
    public class ClickView : MonoBehaviour
    {
        private Text _clickCountText;

        private void Awake()
        {
            _clickCountText = GetComponent<Text>();
        }

        public void UpdateClickCount(int value)
        {
            _clickCountText.text = value.ToString();
        }
    }
}
