namespace DTWorld.Core.Items
{
    public abstract class BaseItem
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public BaseItem(string name)
        {
            this.name = name;
        }
    }
}
