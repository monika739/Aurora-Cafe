using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace CafeAutomationSystem
{
    /// <summary>
    /// Помощник для работы с локальной SQLite базой.
    /// Создаёт файл и таблицы автоматически, если их ещё нет.
    /// При обновлении версии — мягко докатывает недостающие столбцы (ALTER TABLE).
    /// </summary>
    public static class DbHelper
    {
        private static readonly string DbFolder =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

        private static readonly string DbPath =
            Path.Combine(DbFolder, "CafeAutomationDB.db");

        public static string ConnectionString =>
            $"Data Source={DbPath};Version=3;";

        public static SQLiteConnection GetOpenConnection()
        {
            var conn = new SQLiteConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// Создаёт файл БД и нужные таблицы при первом запуске.
        /// </summary>
        public static void EnsureCreated()
        {
            if (!Directory.Exists(DbFolder))
                Directory.CreateDirectory(DbFolder);

            if (!File.Exists(DbPath))
                SQLiteConnection.CreateFile(DbPath);

            using (var conn = GetOpenConnection())
            {
                string sql = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id   INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Role TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS MenuItems (
                        Id       INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name     TEXT    NOT NULL,
                        Price    REAL    NOT NULL,
                        Category TEXT    NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Sales (
                        Id          INTEGER PRIMARY KEY AUTOINCREMENT,
                        FoodName    TEXT    NOT NULL,
                        Quantity    INTEGER NOT NULL,
                        TotalPrice  REAL    NOT NULL,
                        SaleDate    TEXT    NOT NULL,
                        TableNumber INTEGER NOT NULL DEFAULT 0,
                        OrderNo     INTEGER NOT NULL DEFAULT 0
                    );

                    CREATE TABLE IF NOT EXISTS Tables (
                        Id       INTEGER PRIMARY KEY AUTOINCREMENT,
                        Number   INTEGER NOT NULL UNIQUE,
                        Capacity INTEGER NOT NULL DEFAULT 4
                    );
                ";

                using (var cmd = new SQLiteCommand(sql, conn))
                    cmd.ExecuteNonQuery();

                // ---- мягкая миграция старых БД ----
                EnsureColumn(conn, "Sales", "TableNumber", "INTEGER NOT NULL DEFAULT 0");
                EnsureColumn(conn, "Sales", "OrderNo",     "INTEGER NOT NULL DEFAULT 0");

                // Демо-данные при первом запуске
                using (var check = new SQLiteCommand("SELECT COUNT(*) FROM MenuItems", conn))
                {
                    long count = (long)check.ExecuteScalar();
                    if (count == 0)
                    {
                        string seed = @"
                            INSERT INTO MenuItems (Name, Price, Category) VALUES
                                ('Омлет с сыром',            200, 'Завтраки'),
                                ('Омлет с ветчиной',         230, 'Завтраки'),
                                ('Каша овсяная',             150, 'Завтраки'),
                                ('Каша рисовая',             140, 'Завтраки'),
                                ('Сырники со сметаной',      220, 'Завтраки'),
                                ('Блины с творогом',         210, 'Завтраки'),
                                ('Блины с мёдом',            180, 'Завтраки'),
                                ('Гранола с йогуртом',       240, 'Завтраки'),
                                ('Тост с авокадо',           260, 'Завтраки'),
                                ('Яичница с беконом',        250, 'Завтраки'),

                                ('Борщ украинский',          220, 'Супы'),
                                ('Куриный суп с лапшой',     200, 'Супы'),
                                ('Том ям',                   380, 'Супы'),
                                ('Грибной крем-суп',         240, 'Супы'),
                                ('Солянка',                  260, 'Супы'),
                                ('Уха',                      280, 'Супы'),
                                ('Харчо',                    230, 'Супы'),
                                ('Шурпа',                    250, 'Супы'),

                                ('Стейк рибай',              890, 'Горячее'),
                                ('Стейк из лосося',          720, 'Горячее'),
                                ('Куриная грудка гриль',     420, 'Горячее'),
                                ('Свиные рёбра BBQ',         560, 'Горячее'),
                                ('Паста Карбонара',          380, 'Горячее'),
                                ('Паста Болоньезе',          360, 'Горячее'),
                                ('Паста с морепродуктами',   460, 'Горячее'),
                                ('Лазанья',                  390, 'Горячее'),
                                ('Ризотто с грибами',        350, 'Горячее'),
                                ('Плов узбекский',           320, 'Горячее'),
                                ('Бефстроганов',             410, 'Горячее'),
                                ('Шашлык из баранины',       520, 'Горячее'),

                                ('Цезарь с курицей',         340, 'Салаты'),
                                ('Цезарь с креветками',      420, 'Салаты'),
                                ('Греческий',                290, 'Салаты'),
                                ('Оливье',                   240, 'Салаты'),
                                ('Сельдь под шубой',         230, 'Салаты'),
                                ('Капрезе',                  310, 'Салаты'),
                                ('Тёплый салат с говядиной', 380, 'Салаты'),
                                ('Винегрет',                 180, 'Салаты'),

                                ('Чизкейк Нью-Йорк',         240, 'Десерты'),
                                ('Тирамису',                 260, 'Десерты'),
                                ('Шоколадный фондан',        280, 'Десерты'),
                                ('Медовик',                  220, 'Десерты'),
                                ('Наполеон',                 210, 'Десерты'),
                                ('Панна-котта',              230, 'Десерты'),
                                ('Мороженое (3 шарика)',     180, 'Десерты'),
                                ('Брауни',                   200, 'Десерты'),
                                ('Эклер',                    150, 'Десерты'),

                                ('Эспрессо',                 120, 'Напитки'),
                                ('Американо',                140, 'Напитки'),
                                ('Капучино',                 170, 'Напитки'),
                                ('Латте',                    180, 'Напитки'),
                                ('Раф',                      200, 'Напитки'),
                                ('Какао',                    160, 'Напитки'),
                                ('Чай чёрный',                80, 'Напитки'),
                                ('Чай зелёный',               80, 'Напитки'),
                                ('Чай с облепихой',          180, 'Напитки'),
                                ('Свежевыжатый сок',         220, 'Напитки'),
                                ('Морс ягодный',             150, 'Напитки'),
                                ('Лимонад',                  160, 'Напитки'),
                                ('Компот',                   100, 'Напитки'),
                                ('Минеральная вода',          80, 'Напитки');
                        ";
                        using (var cmd = new SQLiteCommand(seed, conn))
                            cmd.ExecuteNonQuery();
                    }
                }

                using (var check = new SQLiteCommand("SELECT COUNT(*) FROM Users", conn))
                {
                    long count = (long)check.ExecuteScalar();
                    if (count == 0)
                    {
                        string seed = @"
                            INSERT INTO Users (Name, Role) VALUES
                                ('Администратор', 'Admin'),
                                ('Официант',      'Staff'),
                                ('Стажёр',        'Intern');
                        ";
                        using (var cmd = new SQLiteCommand(seed, conn))
                            cmd.ExecuteNonQuery();
                    }
                }

                // Столики 1..12 при первом запуске
                using (var check = new SQLiteCommand("SELECT COUNT(*) FROM Tables", conn))
                {
                    long count = (long)check.ExecuteScalar();
                    if (count == 0)
                    {
                        string seed = @"
                            INSERT INTO Tables (Number, Capacity) VALUES
                                (1, 2), (2, 2), (3, 4), (4, 4), (5, 4), (6, 4),
                                (7, 6), (8, 6), (9, 6), (10, 8), (11, 8), (12, 10);
                        ";
                        using (var cmd = new SQLiteCommand(seed, conn))
                            cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Возвращает следующий номер заказа (max + 1).
        /// </summary>
        public static int NextOrderNo()
        {
            using (var conn = GetOpenConnection())
            using (var cmd = new SQLiteCommand("SELECT IFNULL(MAX(OrderNo), 0) + 1 FROM Sales", conn))
            {
                object o = cmd.ExecuteScalar();
                return Convert.ToInt32(o);
            }
        }

        /// <summary>
        /// Добавляет недостающую колонку в существующую таблицу (для апдейта старых БД).
        /// </summary>
        private static void EnsureColumn(SQLiteConnection conn, string table, string column, string definition)
        {
            bool exists = false;
            using (var cmd = new SQLiteCommand($"PRAGMA table_info({table})", conn))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    if (string.Equals(r["name"].ToString(), column, StringComparison.OrdinalIgnoreCase))
                    {
                        exists = true;
                        break;
                    }
                }
            }

            if (!exists)
            {
                using (var cmd = new SQLiteCommand($"ALTER TABLE {table} ADD COLUMN {column} {definition}", conn))
                    cmd.ExecuteNonQuery();
            }
        }
    }
}
