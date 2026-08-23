// SeasonalStars.java
import java.io.*;
import java.nio.file.*;
import java.util.*;
import com.google.gson.*;

class Constellation {
    String name, abbr, hemisphere, season, brightest_star, mythology, notable_objects;
}

public class SeasonalStars {
    private static List<Constellation> constellations = new ArrayList<>();

    static {
        // Hardcode data for simplicity
        String[] data = {
            "Andromeda,And,north,autumn,Alpheratz (Alpha Andromedae, 2.06 mag),In Greek mythology, Andromeda was the daughter of King Cepheus and Queen Cassiopeia. She was chained to a rock as a sacrifice to the sea monster Cetus, but was rescued by Perseus.,Andromeda Galaxy (M31), Messier 32, Messier 110",
            "Aquila,Aql,both,summer,Altair (Alpha Aquilae, 0.77 mag),Aquila represents the eagle that carried Zeus's thunderbolts in Greek mythology.,Barnard's Star (nearby red dwarf)",
            "Aries,Ari,north,autumn,Hamal (Alpha Arietis, 2.01 mag),Aries represents the ram with the golden fleece in Greek mythology.,Spiral galaxy NGC 772",
            "Auriga,Aur,north,winter,Capella (Alpha Aurigae, 0.08 mag),Auriga represents the charioteer. In Greek mythology, he is often identified with Erichthonius.,Messier 36, Messier 37, Messier 38 (open clusters)",
            "Boötes,Boo,north,spring,Arcturus (Alpha Boötis, -0.05 mag),Boötes represents a herdsman or plowman. In Greek mythology, he is sometimes identified with Arcas.,Arcturus (brightest star in northern celestial hemisphere)",
            "Canis Major,CMa,south,winter,Sirius (Alpha Canis Majoris, -1.46 mag),Canis Major represents the larger hunting dog of Orion. Sirius, the Dog Star, is the brightest star in the night sky.,Sirius (brightest star in the night sky), M41 (open cluster)",
            "Canis Minor,CMi,both,winter,Procyon (Alpha Canis Minoris, 0.34 mag),Canis Minor represents the smaller hunting dog of Orion. Procyon means 'before the dog' in Greek.,Procyon (one of the nearest bright stars)",
            "Cassiopeia,Cas,north,autumn,Schedar (Alpha Cassiopeiae, 2.24 mag),Cassiopeia was the vain queen of Ethiopia who boasted about her beauty, leading to the sacrifice of her daughter Andromeda.,Cassiopeia A (supernova remnant), NGC 457 (open cluster)",
            "Cygnus,Cyg,north,summer,Deneb (Alpha Cygni, 1.25 mag),Cygnus represents a swan. In Greek mythology, it is associated with Zeus, who disguised himself as a swan to seduce Leda.,North America Nebula, Veil Nebula, Cygnus X-1 (black hole candidate)",
            "Draco,Dra,north,spring,Thuban (Alpha Draconis, 3.65 mag),Draco represents the dragon Ladon in Greek mythology, who guarded the golden apples of the Hesperides.,Cat's Eye Nebula (NGC 6543)",
            "Gemini,Gem,north,winter,Pollux (Beta Geminorum, 1.16 mag),Gemini represents the twins Castor and Pollux, the Dioscuri in Greek mythology.,Messier 35 (open cluster), Eskimo Nebula (NGC 2392)",
            "Hercules,Her,both,summer,Ras Algethi (Alpha Herculis, variable 2.7–4.0 mag),Hercules represents the legendary Greek hero who performed the Twelve Labors.,Hercules Cluster (M13), NGC 6229 (globular cluster)",
            "Leo,Leo,north,spring,Regulus (Alpha Leonis, 1.35 mag),Leo represents the Nemean lion, which was slain by Hercules as the first of his Twelve Labors.,Leo Triplet (M65, M66, NGC 3628), M95, M96",
            "Lyra,Lyr,north,summer,Vega (Alpha Lyrae, 0.03 mag),Lyra represents the lyre of Orpheus, the legendary musician and poet. After his death, the lyre was placed among the stars.,Ring Nebula (M57), Vega (brightest star)",
            "Orion,Ori,both,winter,Betelgeuse (Alpha Orionis, 0.42 mag),Orion, a mighty hunter in Greek mythology, was placed among the stars by Zeus. He is depicted as a hunter with his belt, sword, and club.,Orion Nebula (M42), Horsehead Nebula, Barnard's Loop",
            "Pegasus,Peg,north,autumn,Enif (Epsilon Pegasi, 2.39 mag),Pegasus is the winged horse from Greek mythology, born from the blood of Medusa.,Great Square of Pegasus, M15 (globular cluster)",
            "Perseus,Per,north,autumn,Mirfak (Alpha Persei, 1.79 mag),Perseus is the Greek hero who slew Medusa and rescued Andromeda.,Perseus Double Cluster (h+χ Persei), Algol (eclipsing binary star)",
            "Sagittarius,Sgr,south,summer,Kaus Australis (Epsilon Sagittarii, 1.79 mag),Sagittarius represents a centaur archer. In Greek mythology, he is often identified with Chiron.,Galactic Center, Lagoon Nebula (M8), Trifid Nebula (M20)",
            "Scorpius,Sco,south,summer,Antares (Alpha Scorpii, 0.96 mag),Scorpius represents the scorpion that killed Orion. According to mythology, the scorpion was placed on the opposite side of the sky from Orion.,Antares (red supergiant), Ptolemy's Cluster (M7), Butterfly Cluster (M6)",
            "Taurus,Tau,north,winter,Aldebaran (Alpha Tauri, 0.86 mag),Taurus represents the bull from Greek mythology. It is associated with Zeus, who transformed into a bull to abduct Europa.,Pleiades (M45), Hyades, Crab Nebula (M1)",
            "Ursa Major,UMa,north,spring,Alioth (Epsilon Ursae Majoris, 1.77 mag),Ursa Major represents the Great Bear. In Greek mythology, Callisto was transformed into a bear by Hera.,M81, M82 (Bode's Galaxy and Cigar Galaxy), Owl Nebula (M97)",
            "Ursa Minor,UMi,north,spring,Polaris (Alpha Ursae Minoris, 1.97 mag),Ursa Minor represents the Little Bear. It contains Polaris, the current North Star.,Polaris (current North Star)"
        };
        for (String s : data) {
            String[] parts = s.split(",");
            Constellation c = new Constellation();
            c.name = parts[0];
            c.abbr = parts[1];
            c.hemisphere = parts[2];
            c.season = parts[3];
            c.brightest_star = parts[4];
            c.mythology = parts[5];
            c.notable_objects = parts[6];
            constellations.add(c);
        }
    }

    public static List<Constellation> listAll(String hemisphere) {
        List<Constellation> result = new ArrayList<>();
        for (Constellation c : constellations) {
            if (hemisphere.equals("all") || c.hemisphere.equals(hemisphere) || c.hemisphere.equals("both")) {
                result.add(c);
            }
        }
        return result;
    }

    public static List<Constellation> bySeason(String season) {
        List<Constellation> result = new ArrayList<>();
        for (Constellation c : constellations) {
            if (c.season.equals(season)) result.add(c);
        }
        return result;
    }

    public static Constellation getInfo(String query) {
        String lower = query.toLowerCase();
        for (Constellation c : constellations) {
            if (c.name.toLowerCase().equals(lower) || c.abbr.toLowerCase().equals(lower)) {
                return c;
            }
        }
        return null;
    }

    public static List<Constellation> search(String term) {
        String lower = term.toLowerCase();
        List<Constellation> result = new ArrayList<>();
        for (Constellation c : constellations) {
            if (c.name.toLowerCase().contains(lower) ||
                c.abbr.toLowerCase().contains(lower) ||
                c.mythology.toLowerCase().contains(lower)) {
                result.add(c);
            }
        }
        return result;
    }

    public static void displayInfo(Constellation c) {
        System.out.printf("\n✨ %s\n", c.name);
        System.out.printf("Abbreviation: %s\n", c.abbr);
        System.out.printf("Hemisphere: %s\n", c.hemisphere);
        System.out.printf("Season: %s\n", c.season.substring(0,1).toUpperCase() + c.season.substring(1));
        System.out.printf("Brightest Star: %s\n", c.brightest_star);
        System.out.printf("Mythology: %s\n", c.mythology);
        System.out.printf("Notable Objects: %s\n", c.notable_objects);
    }

    public static void main(String[] args) {
        if (args.length < 1) {
            System.out.println("Usage: SeasonalStars <command> [options]");
            return;
        }
        String cmd = args[0];
        Map<String, String> params = new HashMap<>();
        for (int i=1; i<args.length; i++) {
            if (args[i].startsWith("--") && i+1 < args.length) {
                params.put(args[i].substring(2), args[++i]);
            }
        }
        switch (cmd) {
            case "list": {
                String hemisphere = params.getOrDefault("hemisphere", "all");
                List<Constellation> results = listAll(hemisphere);
                System.out.printf("\n📋 All Constellations (%d):\n", results.size());
                for (Constellation c : results) {
                    System.out.printf("  %s (%s) – %s – %s\n", c.name, c.abbr, c.hemisphere, c.season);
                }
                break;
            }
            case "season": {
                if (args.length < 2) { System.out.println("season <spring|summer|autumn|winter>"); return; }
                String season = args[1];
                String[] emojis = {"🌸", "☀️", "🍂", "❄️"};
                Map<String, String> emojiMap = new HashMap<>();
                emojiMap.put("spring", "🌸"); emojiMap.put("summer", "☀️"); emojiMap.put("autumn", "🍂"); emojiMap.put("winter", "❄️");
                List<Constellation> results = bySeason(season);
                System.out.printf("\n%s Constellations Visible in %s:\n", emojiMap.get(season), season.substring(0,1).toUpperCase() + season.substring(1));
                for (Constellation c : results) {
                    System.out.printf("  %s (%s) – %s\n", c.name, c.abbr, c.hemisphere);
                }
                break;
            }
            case "info": {
                if (args.length < 2) { System.out.println("info <name|abbr>"); return; }
                Constellation c = getInfo(args[1]);
                if (c != null) displayInfo(c);
                else System.out.printf("❌ Constellation '%s' not found.\n", args[1]);
                break;
            }
            case "search": {
                if (args.length < 2) { System.out.println("search <term>"); return; }
                List<Constellation> results = search(args[1]);
                if (!results.isEmpty()) {
                    System.out.printf("\n🔍 Found %d constellation(s):\n", results.size());
                    for (Constellation c : results) {
                        System.out.printf("  %s (%s) – %s – %s...\n", c.name, c.abbr, c.season, c.mythology.substring(0, Math.min(60, c.mythology.length())));
                    }
                } else {
                    System.out.println("❌ No matches found.");
                }
                break;
            }
            default:
                System.out.println("Unknown command. Use list, season, info, search.");
        }
    }
}
