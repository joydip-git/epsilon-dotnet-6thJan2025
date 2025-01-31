namespace ProductManagementSystem.UserInterface.Models
{
    public class ProductAPIManager : IAPIManager
    {
        private readonly IConfiguration _configuration;
        private readonly string _productApiUrl = string.Empty;

        public ProductAPIManager(IConfiguration configuration)
        {
            _configuration = configuration;
            //_productApiUrl = _configuration.GetSection("APIRequestUrls").GetValue<string>("ProductAPIUrl") ?? "http://localhost:5030/api/productapi";
            _productApiUrl = _configuration["APIRequestUrls:ProductAPIUrl"] ?? "http://localhost:5030/api/productapi";
        }

        public async Task<IEnumerable<ProductQueryViewModel>?> SendRequestToFetchProducts()
        {
            try
            {
                var client = new HttpClient();
                var records = await client.GetFromJsonAsync<IEnumerable<ProductQueryViewModel>>($"{_productApiUrl}/all");
                //Dispose() disconnects the HttpClient instance from any unmanaged resource (such as WebSocket of the machine, which is not managed by .NET runtime), before garbage collector can decide to destroy the HttpClient instance
                client.Dispose();
                return records;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ProductQueryViewModel?> SendRequestToFetchProductById(int id)
        {
            ProductQueryViewModel? product = null;
            try
            {
                //Dispose() method of HttpClinet is called at the end of the "using" block
                using (var client = new HttpClient())
                {
                    product = await client.GetFromJsonAsync<ProductQueryViewModel>($"{_productApiUrl}/get/{id}");
                }
                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> SendRequestToAddProduct(ProductCommandViewModel product)
        {
            try
            {
                using var client = new HttpClient();
                HttpResponseMessage response = await client.PostAsJsonAsync<ProductCommandViewModel>($"{_productApiUrl}/add", product);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> SendRequestToUpdateProduct(int id, ProductCommandViewModel product)
        {
            try
            {
                using var client = new HttpClient();
                HttpResponseMessage response = await client.PutAsJsonAsync<ProductCommandViewModel>($"{_productApiUrl}/update/{id}", product);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> SendRequestToDeleteProduct(int id)
        {
            try
            {
                using var client = new HttpClient();
                HttpResponseMessage response = await client.DeleteAsync($"{_productApiUrl}/delete/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
