using System.Configuration;
using System.Data.SqlClient;

namespace Your.Site.Infrastructure.Migrations
{
    /// <summary>
    /// Migration job that will merge two property definitions - for instance when a duplicate has been added after a class or namespace change.
    /// ExecutePropertyMigrationScript should be called when starting the site, as early as possible, for instance from global.asax.cs
    /// Will merge two property type definitions and update their corresponding property definitions using the site.
    /// Please Note that 'KPIItemProperty' needs to be changed to your type that you need to merge. 
    /// Also - please check so that you do not have more property definition types with the same name that should not be merged.
    /// </summary>
    public class PropertyMigrationSqlCommandExecutor
    {
        private const string sqlCommandText = @"DECLARE @propertyTypeName VARCHAR(50) = 'KPIItemProperty';
DECLARE @amountOfPropertyDefinitions INT;
DECLARE @lastPropertyDefinitionId INT;
DECLARE @firstPropertyDefinitionId INT;

SELECT @amountOfPropertyDefinitions = Count(*) from tblPropertyDefinitionType where name = @propertyTypeName;

if(@amountOfPropertyDefinitions <= 1)
BEGIN
 PRINT 'Only found one property definition type with this name - aborting command'
 RETURN
END

PRINT 'Found ' + CAST(@amountOfPropertyDefinitions AS VARCHAR) + ' property definitions for name - start merge'

SELECT @lastPropertyDefinitionId = MAX(pkID) from tblPropertyDefinitionType where name = @propertyTypeName;
SELECT @firstPropertyDefinitionId = MIN(pkID) from tblPropertyDefinitionType where name = @propertyTypeName;

PRINT 'Merging property definitions'
update tblPropertyDefinition set fkPropertyDefinitionTypeID = @lastPropertyDefinitionId where fkPropertyDefinitionTypeID = @firstPropertyDefinitionId;

PRINT 'Deleting additional property definition type with id ' + CAST(@firstPropertyDefinitionId AS VARCHAR)
delete from tblPropertyDefinitionType where pkId = @firstPropertyDefinitionId;";

        public void ExecutePropertyMigrationScript()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EPiServerDB"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlCommandText, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
