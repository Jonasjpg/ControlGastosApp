using ControlGastosApp.Data;
using ControlGastosApp.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace ControlGastosApp.Services
{
    public class PeriodService
    {
        public Period GetOrCreate(int year, int month)
        {
            using var conn = Db.OpenConnection();

            // 1) Buscar si existe
            using (var findCmd = conn.CreateCommand())
            {
                findCmd.CommandText = @"
SELECT Id, Year, Month
FROM Period
WHERE Year = $year AND Month = $month
LIMIT 1;
";
                findCmd.Parameters.AddWithValue("$year", year);
                findCmd.Parameters.AddWithValue("$month", month);

                using var reader = findCmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Period
                    {
                        Id = reader.GetInt32(0),
                        Year = reader.GetInt32(1),
                        Month = reader.GetInt32(2)
                    };
                }
            }

            // 2) Crear si no existe
            using (var insertCmd = conn.CreateCommand())
            {
                insertCmd.CommandText = @"
INSERT INTO Period (Year, Month)
VALUES ($year, $month);
SELECT last_insert_rowid();
";
                insertCmd.Parameters.AddWithValue("$year", year);
                insertCmd.Parameters.AddWithValue("$month", month);

                var newId = Convert.ToInt32(insertCmd.ExecuteScalar());

                return new Period
                {
                    Id = newId,
                    Year = year,
                    Month = month
                };
            }
        }

        public List<Period> GetAll()
        {
            var list = new List<Period>();
            using var conn = Db.OpenConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
SELECT Id, Year, Month
FROM Period
ORDER BY Year DESC, Month DESC;
";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Period
                {
                    Id = reader.GetInt32(0),
                    Year = reader.GetInt32(1),
                    Month = reader.GetInt32(2)
                });
            }

            return list;
        }
    }
}