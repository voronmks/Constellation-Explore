// seasonal_stars.go
package main

import (
	"flag"
	"fmt"
	"os"
	"strings"
)

type Constellation struct {
	Name          string
	Abbr          string
	Hemisphere    string
	Season        string
	BrightestStar string
	Mythology     string
	NotableObjs   string
}

var constellations = []Constellation{
	{"Andromeda", "And", "north", "autumn", "Alpheratz (Alpha Andromedae, 2.06 mag)", "In Greek mythology, Andromeda was the daughter of King Cepheus and Queen Cassiopeia. She was chained to a rock as a sacrifice to the sea monster Cetus, but was rescued by Perseus.", "Andromeda Galaxy (M31), Messier 32, Messier 110"},
	{"Aquila", "Aql", "both", "summer", "Altair (Alpha Aquilae, 0.77 mag)", "Aquila represents the eagle that carried Zeus's thunderbolts in Greek mythology.", "Barnard's Star (nearby red dwarf)"},
	{"Aries", "Ari", "north", "autumn", "Hamal (Alpha Arietis, 2.01 mag)", "Aries represents the ram with the golden fleece in Greek mythology.", "Spiral galaxy NGC 772"},
	{"Auriga", "Aur", "north", "winter", "Capella (Alpha Aurigae, 0.08 mag)", "Auriga represents the charioteer. In Greek mythology, he is often identified with Erichthonius.", "Messier 36, Messier 37, Messier 38 (open clusters)"},
	{"Boötes", "Boo", "north", "spring", "Arcturus (Alpha Boötis, -0.05 mag)", "Boötes represents a herdsman or plowman. In Greek mythology, he is sometimes identified with Arcas.", "Arcturus (brightest star in northern celestial hemisphere)"},
	{"Canis Major", "CMa", "south", "winter", "Sirius (Alpha Canis Majoris, -1.46 mag)", "Canis Major represents the larger hunting dog of Orion. Sirius, the Dog Star, is the brightest star in the night sky.", "Sirius (brightest star in the night sky), M41 (open cluster)"},
	{"Canis Minor", "CMi", "both", "winter", "Procyon (Alpha Canis Minoris, 0.34 mag)", "Canis Minor represents the smaller hunting dog of Orion. Procyon means 'before the dog' in Greek.", "Procyon (one of the nearest bright stars)"},
	{"Cassiopeia", "Cas", "north", "autumn", "Schedar (Alpha Cassiopeiae, 2.24 mag)", "Cassiopeia was the vain queen of Ethiopia who boasted about her beauty, leading to the sacrifice of her daughter Andromeda.", "Cassiopeia A (supernova remnant), NGC 457 (open cluster)"},
	{"Cygnus", "Cyg", "north", "summer", "Deneb (Alpha Cygni, 1.25 mag)", "Cygnus represents a swan. In Greek mythology, it is associated with Zeus, who disguised himself as a swan to seduce Leda.", "North America Nebula, Veil Nebula, Cygnus X-1 (black hole candidate)"},
	{"Draco", "Dra", "north", "spring", "Thuban (Alpha Draconis, 3.65 mag)", "Draco represents the dragon Ladon in Greek mythology, who guarded the golden apples of the Hesperides.", "Cat's Eye Nebula (NGC 6543)"},
	{"Gemini", "Gem", "north", "winter", "Pollux (Beta Geminorum, 1.16 mag)", "Gemini represents the twins Castor and Pollux, the Dioscuri in Greek mythology.", "Messier 35 (open cluster), Eskimo Nebula (NGC 2392)"},
	{"Hercules", "Her", "both", "summer", "Ras Algethi (Alpha Herculis, variable 2.7–4.0 mag)", "Hercules represents the legendary Greek hero who performed the Twelve Labors.", "Hercules Cluster (M13), NGC 6229 (globular cluster)"},
	{"Leo", "Leo", "north", "spring", "Regulus (Alpha Leonis, 1.35 mag)", "Leo represents the Nemean lion, which was slain by Hercules as the first of his Twelve Labors.", "Leo Triplet (M65, M66, NGC 3628), M95, M96"},
	{"Lyra", "Lyr", "north", "summer", "Vega (Alpha Lyrae, 0.03 mag)", "Lyra represents the lyre of Orpheus, the legendary musician and poet. After his death, the lyre was placed among the stars.", "Ring Nebula (M57), Vega (brightest star)"},
	{"Orion", "Ori", "both", "winter", "Betelgeuse (Alpha Orionis, 0.42 mag)", "Orion, a mighty hunter in Greek mythology, was placed among the stars by Zeus. He is depicted as a hunter with his belt, sword, and club.", "Orion Nebula (M42), Horsehead Nebula, Barnard's Loop"},
	{"Pegasus", "Peg", "north", "autumn", "Enif (Epsilon Pegasi, 2.39 mag)", "Pegasus is the winged horse from Greek mythology, born from the blood of Medusa.", "Great Square of Pegasus, M15 (globular cluster)"},
	{"Perseus", "Per", "north", "autumn", "Mirfak (Alpha Persei, 1.79 mag)", "Perseus is the Greek hero who slew Medusa and rescued Andromeda.", "Perseus Double Cluster (h+χ Persei), Algol (eclipsing binary star)"},
	{"Sagittarius", "Sgr", "south", "summer", "Kaus Australis (Epsilon Sagittarii, 1.79 mag)", "Sagittarius represents a centaur archer. In Greek mythology, he is often identified with Chiron.", "Galactic Center, Lagoon Nebula (M8), Trifid Nebula (M20)"},
	{"Scorpius", "Sco", "south", "summer", "Antares (Alpha Scorpii, 0.96 mag)", "Scorpius represents the scorpion that killed Orion. According to mythology, the scorpion was placed on the opposite side of the sky from Orion.", "Antares (red supergiant), Ptolemy's Cluster (M7), Butterfly Cluster (M6)"},
	{"Taurus", "Tau", "north", "winter", "Aldebaran (Alpha Tauri, 0.86 mag)", "Taurus represents the bull from Greek mythology. It is associated with Zeus, who transformed into a bull to abduct Europa.", "Pleiades (M45), Hyades, Crab Nebula (M1)"},
	{"Ursa Major", "UMa", "north", "spring", "Alioth (Epsilon Ursae Majoris, 1.77 mag)", "Ursa Major represents the Great Bear. In Greek mythology, Callisto was transformed into a bear by Hera.", "M81, M82 (Bode's Galaxy and Cigar Galaxy), Owl Nebula (M97)"},
	{"Ursa Minor", "UMi", "north", "spring", "Polaris (Alpha Ursae Minoris, 1.97 mag)", "Ursa Minor represents the Little Bear. It contains Polaris, the current North Star.", "Polaris (current North Star)"},
}

func listAll(hemisphere string) []Constellation {
	var result []Constellation
	for _, c := range constellations {
		if hemisphere == "all" || c.Hemisphere == hemisphere || c.Hemisphere == "both" {
			result = append(result, c)
		}
	}
	return result
}

func bySeason(season string) []Constellation {
	var result []Constellation
	for _, c := range constellations {
		if c.Season == season {
			result = append(result, c)
		}
	}
	return result
}

func getInfo(query string) *Constellation {
	lower := strings.ToLower(query)
	for _, c := range constellations {
		if strings.ToLower(c.Name) == lower || strings.ToLower(c.Abbr) == lower {
			return &c
		}
	}
	return nil
}

func search(term string) []Constellation {
	lower := strings.ToLower(term)
	var result []Constellation
	for _, c := range constellations {
		if strings.Contains(strings.ToLower(c.Name), lower) ||
			strings.Contains(strings.ToLower(c.Abbr), lower) ||
			strings.Contains(strings.ToLower(c.Mythology), lower) {
			result = append(result, c)
		}
	}
	return result
}

func displayInfo(c Constellation) {
	fmt.Printf("\n✨ %s\n", c.Name)
	fmt.Printf("Abbreviation: %s\n", c.Abbr)
	fmt.Printf("Hemisphere: %s\n", c.Hemisphere)
	fmt.Printf("Season: %s\n", strings.Title(c.Season))
	fmt.Printf("Brightest Star: %s\n", c.BrightestStar)
	fmt.Printf("Mythology: %s\n", c.Mythology)
	fmt.Printf("Notable Objects: %s\n", c.NotableObjs)
}

func main() {
	if len(os.Args) < 2 {
		fmt.Println("Usage: seasonal_stars <command> [options]")
		return
	}
	cmd := os.Args[1]

	switch cmd {
	case "list":
		listCmd := flag.NewFlagSet("list", flag.ExitOnError)
		hemisphere := listCmd.String("hemisphere", "all", "north, south, or all")
		listCmd.Parse(os.Args[2:])
		results := listAll(*hemisphere)
		fmt.Printf("\n📋 All Constellations (%d):\n", len(results))
		for _, c := range results {
			fmt.Printf("  %s (%s) – %s – %s\n", c.Name, c.Abbr, c.Hemisphere, c.Season)
		}

	case "season":
		if len(os.Args) < 3 {
			fmt.Println("season <spring|summer|autumn|winter>")
			return
		}
		season := os.Args[2]
		results := bySeason(season)
		emojis := map[string]string{"spring": "🌸", "summer": "☀️", "autumn": "🍂", "winter": "❄️"}
		fmt.Printf("\n%s Constellations Visible in %s:\n", emojis[season], strings.Title(season))
		for _, c := range results {
			fmt.Printf("  %s (%s) – %s\n", c.Name, c.Abbr, c.Hemisphere)
		}

	case "info":
		if len(os.Args) < 3 {
			fmt.Println("info <name|abbr>")
			return
		}
		c := getInfo(os.Args[2])
		if c != nil {
			displayInfo(*c)
		} else {
			fmt.Printf("❌ Constellation '%s' not found.\n", os.Args[2])
		}

	case "search":
		if len(os.Args) < 3 {
			fmt.Println("search <term>")
			return
		}
		results := search(os.Args[2])
		if len(results) > 0 {
			fmt.Printf("\n🔍 Found %d constellation(s):\n", len(results))
			for _, c := range results {
				fmt.Printf("  %s (%s) – %s – %s...\n", c.Name, c.Abbr, c.Season, c.Mythology[:60])
			}
		} else {
			fmt.Println("❌ No matches found.")
		}

	default:
		fmt.Println("Unknown command. Use list, season, info, search.")
	}
}
