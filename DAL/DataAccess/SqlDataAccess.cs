using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
	public class SqlDataAccess : ISqlDataAccess
	{
		private readonly IConfiguration config;

		public SqlDataAccess(IConfiguration _config)
		{
			config = _config;
		}

		public async Task<IEnumerable<T>> GetAll<T, P>(string spName, P parameters, string connectionStr = "Conn")
		{
			var connstring = config.GetConnectionString(connectionStr);
			using IDbConnection dbConnection = new SqlConnection(connstring);

			return await dbConnection.QueryAsync<T>(spName, parameters, commandType: CommandType.StoredProcedure);
		}

		public async Task AddData<T>(string spName, T parameters, string connectionStr = "Conn")
		{
			var connstring = config.GetConnectionString(connectionStr);
			using IDbConnection dbConnection = new SqlConnection(connstring);

			await dbConnection.ExecuteAsync(spName, parameters, commandType: CommandType.StoredProcedure);
		}

	}
}
