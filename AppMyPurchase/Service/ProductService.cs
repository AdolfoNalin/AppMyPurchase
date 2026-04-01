using AppMyPurchase.Models;
using SQLite;

namespace AppMyPurchase.Service
{
    public class ProductService
    {
        private SQLiteAsyncConnection _connect;

        public ProductService(string path)
        {
            _connect = new SQLiteAsyncConnection(path);
            _connect.CreateTableAsync<Product>().Wait();
        }

        #region Insert
        /// <summary>
        /// Cadastra o produto no banco de dados SqLite
        /// </summary>
        /// <param name="product"></param>
        public async Task<int> Insert(Product product)
        {
            try
            {
                return await _connect.InsertAsync(product);
            }
            catch (Exception)
            {
                return  0;
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// Atualiza os dados do Produto no banco de dados SqLite
        /// </summary>
        /// <param name="product"></param>
        public async Task<List<Product>> Update(Product product)
        {
            try
            {
                string sql = $"UPDATE Product SET description={product.Description}, amount={product.Amount} price={product.Price} WHERE id={product.Id}";

                return await _connect.QueryAsync<Product>(sql);
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// Deleta os Produtos do banco de dados SqLite
        /// </summary>
        /// <param name="id"></param>
        public async Task<int> Delete(int id)
        {
            try
            {
                return await _connect.Table<Product>().DeleteAsync(i => i.Id == id);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

        #region GetAll
        /// <summary>
        /// Capitura todos os Produtos dentro do banco de dados SqLite
        /// </summary>
        public async Task<List<Product>> GetAll()
        {
            try
            {
                List<Product> products = await _connect.Table<Product>().OrderBy(p => p.Description).ToListAsync();
                return products;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Search
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<List<Product>> Search(string value)
        {
            try
            {
                List<Product> products = await _connect.Table<Product>().Where(p => p.Description == value).ToListAsync();
                return products;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
