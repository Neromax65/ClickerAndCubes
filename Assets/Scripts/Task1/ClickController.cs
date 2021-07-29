namespace Task1
{
    public class ClickController
    {
        public ClickController(ClickModel clickModel, ClickView clickView)
        {
            clickModel.ClickCountChanged += clickView.UpdateClickCount;
        }
    }
}
