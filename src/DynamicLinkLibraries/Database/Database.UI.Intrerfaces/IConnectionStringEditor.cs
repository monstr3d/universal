namespace Database.UI.Intrerfaces
{
    //Editor of connection string
    public interface IConnectionStringEditor
    {
        /// <summary>
        /// Gets connection string
        /// </summary>
        /// <param name="connectionString">The connecion string</param>
        /// <returns></returns>
        string ConnectionStrig(string connectionString);

        /// <summary>
        /// Closes itself
        /// </summary>
        void Close();

    }
}
