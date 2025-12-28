using Microsoft.Data.Sqlite;
using System;
using System.IO;

namespace ControlGastosApp.Data
{
    public static class Db
    {
        public static readonly string DbPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "ControlGastosApp",
                "control_gastos.db");

        public static SqliteConnection OpenConnection()
        {
            var dir = Path.GetDirectoryName(DbPath)!;
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            var conn = new SqliteConnection($"Data Source={DbPath}");
            conn.Open();
            return conn;
        }

        public static void Init()
        {
            using var conn = OpenConnection();
            using var cmd = conn.CreateCommand();

            cmd.CommandText = @"
PRAGMA foreign_keys = ON;

CREATE TABLE IF NOT EXISTS Period (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Year INTEGER NOT NULL,
    Month INTEGER NOT NULL,
    UNIQUE(Year, Month)
);

CREATE TABLE IF NOT EXISTS BudgetItem (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    PeriodId INTEGER NOT NULL,
    Category TEXT NOT NULL,
    Subcategory TEXT NOT NULL,
    AssignedAmount REAL NOT NULL DEFAULT 0,
    PayDate TEXT NULL,
    SortOrder INTEGER NOT NULL DEFAULT 0,
    FOREIGN KEY (PeriodId) REFERENCES Period(Id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS Movement (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    PeriodId INTEGER NOT NULL,
    BudgetItemId INTEGER NULL,
    Type TEXT NOT NULL,          -- 'INCOME' o 'EXPENSE'
    Amount REAL NOT NULL,
    MovementDate TEXT NOT NULL,  -- YYYY-MM-DD
    Note TEXT NULL,
    FOREIGN KEY (PeriodId) REFERENCES Period(Id) ON DELETE CASCADE,
    FOREIGN KEY (BudgetItemId) REFERENCES BudgetItem(Id) ON DELETE SET NULL
);
";
            cmd.ExecuteNonQuery();
        }
    }
}