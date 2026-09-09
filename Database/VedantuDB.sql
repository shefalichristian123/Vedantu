-- This project uses SQLite, so no SQL Server installation is required.
-- The application automatically creates VedantuDB.db on first start.
--
-- The equivalent SQLite table is:
CREATE TABLE IF NOT EXISTS Students
(
    StudentId INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    FullName TEXT NOT NULL,
    Email TEXT NOT NULL UNIQUE,
    Phone TEXT NOT NULL,
    PasswordHash TEXT NOT NULL,
    CreatedAt TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP
);
