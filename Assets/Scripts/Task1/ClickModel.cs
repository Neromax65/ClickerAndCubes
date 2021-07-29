using System;

namespace Task1
{
    public class ClickModel
    {
        private int _clickCount;

        public int ClickCount
        {
            get => _clickCount;
            set
            {
                _clickCount = value;
                var eventHandler = ClickCountChanged;
                eventHandler?.Invoke(_clickCount);
            }
        }

        public event Action<int> ClickCountChanged;
    }
}