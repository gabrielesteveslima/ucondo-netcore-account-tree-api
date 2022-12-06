namespace UCondoAccountTree.Application.Configuration;

using System.Data;

public interface IConnectionFactory
{
    IDbConnection GetOpenSqlConnection();
}
