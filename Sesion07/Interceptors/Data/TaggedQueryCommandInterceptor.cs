using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

class TaggedQueryCommandInterceptor : DbCommandInterceptor {

    public override InterceptionResult<DbDataReader> ReaderExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result)
    {
        ManipulateCommand(command);

        return result;
    }

    public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result,
        CancellationToken cancellationToken = default)
    {
        ManipulateCommand(command);

        return new ValueTask<InterceptionResult<DbDataReader>>(result);
    }

    private static void ManipulateCommand(DbCommand command)
    {
        if (command.CommandText.StartsWith("-- patata", StringComparison.Ordinal))
        {
            Console.WriteLine("Doing what we want to do to current command");
            Console.WriteLine($"Current commant text is {command.CommandText}");
        }
    }
}