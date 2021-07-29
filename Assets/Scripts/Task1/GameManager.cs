using UnityEngine;
using UnityEngine.UI;

namespace Task1
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private ClickView clickView;

        [SerializeField] private Button clickButton;

        private ClickModel _clickModel;
        private ClickController _clickController;
    
        void Start()
        {
            _clickModel = new ClickModel();
            clickButton.onClick.AddListener(() => _clickModel.ClickCount++);
            _clickController = new ClickController(_clickModel, clickView);
        }
    }
}
