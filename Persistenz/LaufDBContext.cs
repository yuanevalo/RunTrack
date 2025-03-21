﻿using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.IO;

namespace RunTrack
{
    // Definiert den DbContext für die Anwendung
    public class LaufDBContext : DbContext
    {
        // Pfad zur Datenbankdatei
        private static string _dbPath = MainModel.BaseFolder + "/Dateien/EigeneDatenbank.db";

        // Standardkonstruktor, der die Datenbankoptionen initialisiert
        public LaufDBContext()
              : base(GetDbContextOptions())
        {
            // Erstellt das Verzeichnis, falls es nicht existiert
            if (!Directory.Exists(MainModel.BaseFolder + "/Dateien")) Directory.CreateDirectory(MainModel.BaseFolder + "/Dateien");

            // Erstellt die Datenbank und fügt Testdaten hinzu, falls die Datei nicht existiert oder leer ist
            if (!File.Exists(_dbPath) || new FileInfo(_dbPath).Length == 0)
            {
                Database.EnsureCreated();
                SeedTestData();
                SeedBlattgroessen();
            }
            // Schreibt den vollständigen Pfad der Datenbankdatei in die Ausgabe
            Trace.WriteLine(Path.GetFullPath(_dbPath));
        }

        // Konstruktor, der einen benutzerdefinierten Pfad zur Datenbankdatei akzeptiert
        public LaufDBContext(string _path)
              : base(GetDbContextOptions(_path))
        {
            Database.EnsureCreated();
        }

        // Methode zum Hinzufügen von Blattgrößen in die Datenbank
        public void SeedBlattgroessen()
        {
            // Liste von Blattgrößen
            List<BlattGroesse> blattGroessen = new()
                {
                    new(2384f, 3370f, "A0"),
                    new(1684f, 2384f, "A1"),
                    new(1190f, 1684f, "A2"),
                    new(842f, 1190f, "A3"),
                    new(595f, 842f, "A4"),
                    new(420f, 595f, "A5"),
                    new(298f, 420f, "A6"),
                    new(210f, 298f, "A7"),
                    new(148f, 210f, "A8"),
                    new(105f, 148f, "A9"),
                    new(74f, 105f, "A10"),
                    new(2835f, 4008f, "B0"),
                    new(2004f, 2835f, "B1"),
                    new(1417f, 2004f, "B2"),
                    new(1001f, 1417f, "B3"),
                    new(709f, 1001f, "B4"),
                    new(504f, 709f, "B5"),
                    new(358f, 504f, "B6"),
                    new(252f, 358f, "B7"),
                    new(179f, 252f, "B8"),
                    new(127f, 179f, "B9"),
                    new(90f, 127f, "B10"),
                    new(850f, 1400f, "LEGAL"),
                    new(1100f, 1700f, "LEDGER"),
                    new(725f, 1050f, "Executive"),
                    new(850f, 1100f, "Letter"),
                    new(1100f, 1700f, "Tabloid")
                };

            // Fügt die Blattgrößen in die Datenbank ein, falls sie noch nicht existieren
            using (var db = new LaufDBContext())
            {
                foreach (BlattGroesse bg in blattGroessen)
                {
                    if (!db.BlattGroessen.Any(b => b.Name == bg.Name))
                    {
                        db.BlattGroessen.Add(bg);
                    }
                }
                db.SaveChanges();
            }
        }

        // Methode zum Hinzufügen von Testdaten in die Datenbank
        public void SeedTestData()
        {
            using (var db = new LaufDBContext())
            {
                // Erstellt einen Benutzer
                Benutzer benutzer = new();
                benutzer.Vorname = "Sascha";
                benutzer.Nachname = "Dierl";

                // Erstellt Schulen und fügt sie in die Datenbank ein
                Schule schule1 = new() { Name = "BSZ Wiesau" };
                db.Schulen.Add(schule1);
                db.SaveChanges();

                Schule schule2 = new() { Name = "Mittelschule Wiesau" };
                db.Schulen.Add(schule2);
                db.SaveChanges();

                // Erstellt Rundenarten und fügt sie in die Datenbank ein
                RundenArt rundenArt = new() { Name = "Kurze Runde", LaengeInMeter = 800 };
                db.RundenArten.Add(rundenArt);
                db.SaveChanges();

                RundenArt rundenArt2 = new() { Name = "Lange Runde", LaengeInMeter = 1300 };
                db.RundenArten.Add(rundenArt2);
                db.SaveChanges();

                // Erstellt Klassen und fügt sie in die Datenbank ein
                Klasse klasse1 = new() { Name = "BFI10A", Schule = schule1, RundenArt = rundenArt };
                db.Klassen.Add(klasse1);
                db.SaveChanges();

                Klasse klasse2 = new() { Name = "BFI11A", Schule = schule1, RundenArt = rundenArt2 };
                db.Klassen.Add(klasse2);
                db.SaveChanges();

                // Erstellt Schüler und fügt sie in die Datenbank ein
                Random rnd = new();
                for (int i = 0; i < 20; i++)
                {
                    Schueler schueler = new()
                    {
                        Vorname = RandomVorname(),
                        Nachname = RandomNachname(),
                        Klasse = klasse1,
                        Geburtsjahrgang = rnd.Next(1995, 2010),
                        Geschlecht = Geschlecht.Maennlich
                    };
                    db.Schueler.Add(schueler);
                    db.SaveChanges();
                }

                for (int i = 0; i < 20; i++)
                {
                    Schueler schueler = new()
                    {
                        Vorname = RandomVorname(),
                        Nachname = RandomNachname(),
                        Klasse = klasse2,
                        Geburtsjahrgang = rnd.Next(1995, 2010),
                        Geschlecht = Geschlecht.Maennlich
                    };
                    db.Schueler.Add(schueler);
                    db.SaveChanges();
                }
            }
        }

        // Methode zur Generierung eines zufälligen Vornamens
        private string RandomVorname()
        {
            string[] vorname = { "Max", "Moritz", "Hans", "Peter", "Paul", "Klaus", "Karl", "Kurt", "Kai" };
            Random rnd = new();
            return vorname[rnd.Next(vorname.Length)];
        }

        // Methode zur Generierung eines zufälligen Nachnamens
        private string RandomNachname()
        {
            string[] nachname = { "Müller", "Schmidt", "Schneider", "Fischer", "Weber", "Meyer", "Wagner", "Becker", "Schulz" };
            Random rnd = new();
            return nachname[rnd.Next(nachname.Length)];
        }

        // Methode zur Konfiguration der Datenbankoptionen
        private static DbContextOptions GetDbContextOptions(string? path = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LaufDBContext>();
            if (path == null) path = MainModel.BaseFolder + "/Dateien/EigeneDatenbank.db";
            optionsBuilder.UseSqlite($"Data Source={path};Pooling=False");
            optionsBuilder.EnableSensitiveDataLogging();
            return optionsBuilder.Options;
        }

        // Methode zur Konfiguration des Datenbankmodells
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schule>()
                  .HasMany(s => s.Klassen)
                  .WithOne(k => k.Schule)
                  .HasForeignKey(k => k.SchuleId)
                  .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Klasse>()
                  .HasMany(k => k.Schueler)
                  .WithOne(s => s.Klasse)
                  .HasForeignKey(s => s.KlasseId)
                  .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Klasse>()
                  .HasOne(k => k.RundenArt)
                  .WithMany()
                  .HasForeignKey(k => k.RundenArtId)
                  .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Laeufer>()
                  .HasOne(l => l.RundenArt)
                  .WithMany()
                  .HasForeignKey(l => l.RundenArtId)
                  .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Laeufer>()
                  .HasMany(s => s.Runden)
                  .WithOne(r => r.Laeufer)
                  .HasForeignKey(r => r.LaeuferId)
                  .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Format>()
                  .HasOne(f => f.BlattGroesse)
                  .WithMany()
                  .HasForeignKey(f => f.BlattGroesseId)
                  .OnDelete(DeleteBehavior.SetNull);
        }

        // Definiert die DbSet-Eigenschaften für die verschiedenen Entitäten
        public DbSet<Klasse> Klassen { get; set; }
        public DbSet<Schule> Schulen { get; set; }
        public DbSet<Schueler> Schueler { get; set; }
        public DbSet<Laeufer> Laeufer { get; set; }
        public DbSet<Runde> Runden { get; set; }
        public DbSet<RundenArt> RundenArten { get; set; }
        public DbSet<Benutzer> Benutzer { get; set; }
        public DbSet<Format> Formate { get; set; }
        public DbSet<BlattGroesse> BlattGroessen { get; set; }
    }
}
