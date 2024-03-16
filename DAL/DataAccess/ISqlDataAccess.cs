namespace DAL.DataAccess
{
	public interface ISqlDataAccess
	{
		Task<IEnumerable<T>> GetAll<T, P>(string spName, P parameters, string connectionStr = "Conn");
		Task AddData<T>(string spName, T parameters, string connectionStr = "Conn");
	}
}