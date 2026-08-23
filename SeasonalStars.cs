// SeasonalStars.cs
using System;
using System.Collections.Generic;
using System.Linq;

class Constellation
{
    public string Name { get; set; }
    public string Abbr { get; set; }
    public string Hemisphere { get; set; }
    public string Season { get; set; }
    public string BrightestStar { get; set; }
    public string Mythology { get; set; }
    public string NotableObjects { get; set; }
}

class SeasonalStars
{
    static readonly List<Constellation> Constellations = new List<Constellation>
    {
        new Constellation{ Name="Andromeda", Abbr="And", Hemisphere="north", Season="autumn", BrightestStar="Alpheratz (Alpha Andromedae, 2.06 mag)", Mythology="In Greek mythology, Andromeda was the daughter of King Cepheus and Queen Cassiopeia. She was chained to a rock as a sacrifice to the sea monster Cetus, but was rescued by Perseus.", NotableObjects="Andromeda Galaxy (M31), Messier 32, Messier 110" },
        new Constellation{ Name="Aquila", Abbr="Aql", Hemisphere="both", Season="summer", BrightestStar="Altair (Alpha Aquilae, 0.77 mag)", Mythology="Aquila represents the eagle that carried Zeus's thunderbolts in Greek mythology.", NotableObjects="Barnard's Star (nearby red dwarf)" },
        new Constellation{ Name="Aries", Abbr="Ari", Hemisphere="north", Season="autumn", BrightestStar="Hamal (Alpha Arietis, 2.01 mag)", Mythology="Aries represents the ram with the golden fleece in Greek mythology.", NotableObjects="Spiral galaxy NGC 772" },
        new Constellation{ Name="Auriga", Abbr="Aur", Hemisphere="north", Season="winter", BrightestStar="Capella (Alpha Aurigae, 0.08 mag)", Mythology="Auriga represents the charioteer. In Greek mythology, he is often identified with Erichthonius.", NotableObjects="Messier 36, Messier 37, Messier 38 (open clusters)" },
        new Constellation{ Name="Boötes", Abbr="Boo", Hemisphere="north", Season="spring", BrightestStar="Arcturus (Alpha Boötis, -0.05 mag)", Mythology="Boötes represents a herdsman or plowman. In Greek mythology, he is sometimes identified with Arcas.", NotableObjects="Arcturus (brightest star in northern celestial hemisphere)" },
        new Constellation{ Name="Canis Major", Abbr="CMa", Hemisphere="south", Season="winter", BrightestStar="Sirius (Alpha Canis Majoris, -1.46 mag)", Mythology="Canis Major represents the larger hunting dog of Orion. Sirius, the Dog Star, is the brightest star in the night sky.", NotableObjects="Sirius (brightest star in the night sky), M41 (open cluster)" },
        new Constellation{ Name="Canis Minor", Abbr="CMi", Hemisphere="both", Season="winter", BrightestStar="Procyon (Alpha Canis Minoris, 0.34 mag)", Mythology="Canis Minor represents the smaller hunting dog of Orion. Procyon means 'before the dog' in Greek.", NotableObjects="Procyon (one of the nearest bright stars)" },
        new Constellation{ Name="Cassiopeia", Abbr="Cas", Hemisphere="north", Season="autumn", BrightestStar="Schedar (Alpha Cassiopeiae, 2.24 mag)", Mythology="Cassiopeia was the vain queen of Ethiopia who boasted about her beauty, leading to the sacrifice of her daughter Andromeda.", NotableObjects="Cassiopeia A (supernova remnant), NGC 457 (open cluster)" },
        new Constellation{ Name="Cygnus", Abbr="Cyg", Hemisphere="north", Season="summer", BrightestStar="Deneb (Alpha Cygni, 1.25 mag)", Mythology="Cygnus represents a swan. In Greek mythology, it is associated with Zeus, who disguised himself as a swan to seduce Leda.", NotableObjects="North America Nebula, Veil Nebula, Cygnus X-1 (black hole candidate)" },
        new Constellation{ Name="Draco", Abbr="Dra", Hemisphere="north", Season="spring", BrightestStar="Thuban (Alpha Draconis, 3.65 mag)", Mythology="Draco represents the dragon Ladon in Greek mythology, who guarded the golden apples of the Hesperides.", NotableObjects="Cat's Eye Nebula (NGC 6543)" },
        new Constellation{ Name="Gemini", Abbr="Gem", Hemisphere="north", Season="winter", BrightestStar="Pollux (Beta Geminorum, 1.16 mag)", Mythology="Gemini represents the twins Castor and Pollux, the Dioscuri in Greek mythology.", NotableObjects="Messier 35 (open cluster), Eskimo Nebula (NGC 2392)" },
        new Constellation{ Name="Hercules", Abbr="Her", Hemisphere="both", Season="summer", BrightestStar="Ras Algethi (Alpha Herculis, variable 2.7–4.0 mag)", Mythology="Hercules represents the legendary Greek hero who performed the Twelve Labors.", NotableObjects="Hercules Cluster (M13), NGC 6229 (globular cluster)" },
        new Constellation{ Name="Leo", Abbr="Leo", Hemisphere="north", Season="spring", BrightestStar="Regulus (Alpha Leonis, 1.35 mag)", Mythology="Leo represents the Nemean lion, which was slain by Hercules as the first of his Twelve Labors.", NotableObjects="Leo Triplet (M65, M66, NGC 3628), M95, M96" },
        new Constellation{ Name="Lyra", Abbr="Lyr", Hemisphere="north", Season="summer", BrightestStar="Vega (Alpha Lyrae, 0.03 mag)", Mythology="Lyra represents the lyre of Orpheus, the legendary musician and poet. After his death, the lyre was placed among the stars.", NotableObjects="Ring Nebula (M57), Vega (brightest star)" },
        new Constellation{ Name="Orion", Abbr="Ori", Hemisphere="both", Season="winter", BrightestStar="Betelgeuse (Alpha Orionis, 0.42 mag)", Mythology="Orion, a mighty hunter in Greek mythology, was placed among the stars by Zeus. He is depicted as a hunter with his belt, sword, and club.", NotableObjects="Orion Nebula (M42), Horsehead Nebula, Barnard's Loop" },
        new Constellation{ Name="Pegasus", Abbr="Peg", Hemisphere="north", Season="autumn", BrightestStar="Enif (Epsilon Pegasi, 2.39 mag)", Mythology="Pegasus is the winged horse from Greek mythology, born from the blood of Medusa.", NotableObjects="Great Square of Pegasus, M15 (globular cluster)" },
        new Constellation{ Name="Perseus", Abbr="Per", Hemisphere="north", Season="autumn", BrightestStar="Mirfak (Alpha Persei, 1.79 mag)", Mythology="Perseus is the Greek hero who slew Medusa and rescued Andromeda.", NotableObjects="Perseus Double Cluster (h+χ Persei), Algol (eclipsing binary star)" },
        new Constellation{ Name="Sagittarius", Abbr="Sgr", Hemisphere="south", Season="summer", BrightestStar="Kaus Australis (Epsilon Sagittarii, 1.79 mag)", Mythology="Sagittarius represents a centaur archer. In Greek mythology, he is often identified with Chiron.", NotableObjects="Galactic Center, Lagoon Nebula (M8), Trifid Nebula (M20)" },
        new Constellation{ Name="Scorpius", Abbr="Sco", Hemisphere="south", Season="summer", BrightestStar="Antares (Alpha Scorpii, 0.96 mag)", Mythology="Scorpius represents the scorpion that killed Orion. According to mythology, the scorpion was placed on the opposite side of the sky from Orion.", NotableObjects="Antares (red supergiant), Ptolemy's Cluster (M7), Butterfly Cluster (M6)" },
        new Constellation{ Name="Taurus", Abbr="Tau", Hemisphere="north", Season="winter", BrightestStar="Aldebaran (Alpha Tauri, 0.86 mag)", Mythology="Taurus represents the bull from Greek mythology. It is associated with Zeus, who transformed into a bull to abduct Europa.", NotableObjects="Pleiades (M45), Hyades, Crab Nebula (M1)" },
        new Constellation{ Name="Ursa Major", Abbr="UMa", Hemisphere="north", Season="spring", BrightestStar="Alioth (Epsilon Ursae Majoris, 1.77 mag)", Mythology="Ursa Major represents the Great Bear. In Greek mythology, Callisto was transformed into a bear by Hera.", NotableObjects="M81, M82 (Bode's Galaxy and Cigar Galaxy), Owl Nebula (M97)" },
        new Constellation{ Name="Ursa Minor", Abbr="UMi", Hemisphere="north", Season="spring", BrightestStar="Polaris (Alpha Ursae Minoris, 1.97 mag)", Mythology="Ursa Minor represents the Little Bear. It contains Polaris, the current North Star.", NotableObjects="Polaris (current North Star)" }
    };

    static List<Constellation> ListAll(string hemisphere)
    {
        return Constellations.Where(c => hemisphere == "all" || c.Hemisphere == hemisphere || c.Hemisphere == "both").ToList();
    }

    static List<Constellation> BySeason(string season)
    {
        return Constellations.Where(c => c.Season == season).ToList();
    }

    static Constellation GetInfo(string query)
    {
        return Constellations.FirstOrDefault(c => string.Equals(c.Name, query, StringComparison.OrdinalIgnoreCase) ||
                                                   string.Equals(c.Abbr, query, StringComparison.OrdinalIgnoreCase));
    }

    static List<Constellation> Search(string term)
    {
        return Constellations.Where(c =>
            c.Name.Contains(term, StringComparison.OrdinalIgnoreCase) ||
            c.Abbr.Contains(term, StringComparison.OrdinalIgnoreCase) ||
            c.Mythology.Contains(term, StringComparison.OrdinalIgnoreCase)
        ).ToList();
    }

    static void DisplayInfo(Constellation c)
    {
        Console.WriteLine($"\n✨ {c.Name}");
        Console.WriteLine($"Abbreviation: {c.Abbr}");
        Console.WriteLine($"Hemisphere: {c.Hemisphere}");
        Console.WriteLine($"Season: {char.ToUpper(c.Season[0]) + c.Season.Substring(1)}");
        Console.WriteLine($"Brightest Star: {c.BrightestStar}");
        Console.WriteLine($"Mythology: {c.Mythology}");
        Console.WriteLine($"Notable Objects: {c.NotableObjects}");
    }

    static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Usage: SeasonalStars <command> [options]");
            return;
        }
        var parsed = ParseArgs(args);
        string cmd = args[0];
        switch (cmd)
        {
            case "list":
                string hemisphere = parsed.GetValueOrDefault("hemisphere", "all");
                var results = ListAll(hemisphere);
                Console.WriteLine($"\n📋 All Constellations ({results.Count}):");
                foreach (var c in results)
                    Console.WriteLine($"  {c.Name} ({c.Abbr}) – {c.Hemisphere} – {c.Season}");
                break;

            case "season":
                if (args.Length < 2) { Console.WriteLine("season <spring|summer|autumn|winter>"); return; }
                string season = args[1];
                var emojis = new Dictionary<string, string> { {"spring","🌸"}, {"summer","☀️"}, {"autumn","🍂"}, {"winter","❄️"} };
                var seasonResults = BySeason(season);
                Console.WriteLine($"\n{emojis[season]} Constellations Visible in {char.ToUpper(season[0]) + season.Substring(1)}:");
                foreach (var c in seasonResults)
                    Console.WriteLine($"  {c.Name} ({c.Abbr}) – {c.Hemisphere}");
                break;

            case "info":
                if (args.Length < 2) { Console.WriteLine("info <name|abbr>"); return; }
                var cInfo = GetInfo(args[1]);
                if (cInfo != null) DisplayInfo(cInfo);
                else Console.WriteLine($"❌ Constellation '{args[1]}' not found.");
                break;

            case "search":
                if (args.Length < 2) { Console.WriteLine("search <term>"); return; }
                var searchResults = Search(args[1]);
                if (searchResults.Any())
                {
                    Console.WriteLine($"\n🔍 Found {searchResults.Count} constellation(s):");
                    foreach (var c in searchResults)
                        Console.WriteLine($"  {c.Name} ({c.Abbr}) – {c.Season} – {(c.Mythology.Length > 60 ? c.Mythology.Substring(0,60) + "..." : c.Mythology)}");
                }
                else Console.WriteLine("❌ No matches found.");
                break;

            default:
                Console.WriteLine("Unknown command. Use list, season, info, search.");
                break;
        }
    }

    static Dictionary<string, string> ParseArgs(string[] args)
    {
        var dict = new Dictionary<string, string>();
        for (int i = 1; i < args.Length; i++)
        {
            if (args[i].StartsWith("--") && i + 1 < args.Length)
                dict[args[i].Substring(2)] = args[++i];
        }
        return dict;
    }
}
