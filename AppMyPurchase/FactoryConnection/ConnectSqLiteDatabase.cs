using AppMyPurchase.Models;
using SQLite;

namespace AppMyPurchase.FactoryConnection
{
    public  class ConnectSqLiteDatabase
    {
        private readonly SQLiteAsyncConnection _connect;

        /// <summary>
        /// Conexão de banco de dados
        /// </summary>
        /// <param name="connection"></param>
        public ConnectSqLiteDatabase(string path)
        {
            try
            {
                _connect = new SQLiteAsyncConnection(path);
                _connect.CreateTableAsync<Product>().Wait();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
