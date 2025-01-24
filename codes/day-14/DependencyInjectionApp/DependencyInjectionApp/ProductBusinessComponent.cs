namespace DependencyInjectionApp
{
    class ProductBusinessComponent : IBusinessComponent
    {
        private IDataAccessComponent _component;

        public ProductBusinessComponent(IDataAccessComponent component)
        {
            this._component = component;
        }
        public string FetchData()
        {
            string fetchedData = _component.GetData();
            return fetchedData.ToUpper();
        }
    }
}
