using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
public interface IDeleteEmployee
{
    Task<bool> Delete(SqlConnection connection, int id, CancellationToken cancellationToken = default);
}

public class DeleteEmployee : IDeleteEmployee
{
    private const string DeleteSql = "DELETE FROM dbo.EmployeeCapG WHERE Id = @id";

    public async Task<bool> Delete(SqlConnection connection, int id, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(connection);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        if (connection.State != ConnectionState.Open)
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        using var cmd = connection.CreateCommand();
        cmd.CommandText = DeleteSql;
        cmd.Parameters.AddWithValue("@id", id);

        int rows = await cmd.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
        return rows > 0;
    }
}
