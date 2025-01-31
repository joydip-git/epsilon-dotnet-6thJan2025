using ProductManagementSystem.Entities;
using System.Data;

namespace ProductManagementSystem.Repository
{
    //Primary constructor
    public class ProductRepository(EpsilonDbContext _context) : IEpsilonDbRepository<Product, int>
    {
        //use primary constructor technique instead
        //private readonly EpsilonDbContext _context;
        //public ProductRepository(EpsilonDbContext _context)
        //{
        //    _context = _context;
        //}

        private Product GetExistingProduct(int id)
        {
            try
            {
                Product found = _context.Products.Where(p => p.Id == id).First();
                if (found != null)
                {
                    return found;
                }
                else
                    throw new Exception($"Product with id:{id} does nt exist");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var found = GetExistingProduct(id);
                _context.Products.Remove(found);
                var result = _context.SaveChanges();
                return result > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product Fetch(int id)
        {
            try
            {
                var found = GetExistingProduct(id);
                return found;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Product> FetchAll()
        {
            try
            {
                //return _context.Products.ToList();
                return [.. _context.Products];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insert(Product entity)
        {
            try
            {
                _context.Products.Add(entity);
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(int id, Product entity)
        {
            try
            {
                var found = GetExistingProduct(id);
                found.Name = entity.Name;
                found.Description = entity.Description;
                found.Price = entity.Price;
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
