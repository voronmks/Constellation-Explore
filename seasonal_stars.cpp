// seasonal_stars.cpp
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <map>
#include <algorithm>
#include <cctype>
#include <nlohmann/json.hpp>
#include <getopt.h>

using namespace std;
using json = nlohmann::json;

struct Constellation {
    string name, abbr, hemisphere, season, brightest_star, mythology, notable_objects;
};

vector<Constellation> constellations = {
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
    {"Ursa Minor", "UMi", "north", "spring", "Polaris (Alpha Ursae Minoris, 1.97 mag)", "Ursa Minor represents the Little Bear. It contains Polaris, the current North Star.", "Polaris (current North Star)"}
};

string toLower(const string& s) {
    string r = s;
    for (char& c : r) c = tolower(c);
    return r;
}

vector<Constellation> listAll(const string& hemisphere) {
    vector<Constellation> result;
    for (auto& c : constellations) {
        if (hemisphere == "all" || c.hemisphere == hemisphere || c.hemisphere == "both") {
            result.push_back(c);
        }
    }
    return result;
}

vector<Constellation> bySeason(const string& season) {
    vector<Constellation> result;
    for (auto& c : constellations) {
        if (c.season == season) result.push_back(c);
    }
    return result;
}

const Constellation* getInfo(const string& query) {
    string q = toLower(query);
    for (auto& c : constellations) {
        if (toLower(c.name) == q || toLower(c.abbr) == q) {
            return &c;
        }
    }
    return nullptr;
}

vector<Constellation> search(const string& term) {
    string t = toLower(term);
    vector<Constellation> result;
    for (auto& c : constellations) {
        if (toLower(c.name).find(t) != string::npos ||
            toLower(c.abbr).find(t) != string::npos ||
            toLower(c.mythology).find(t) != string::npos) {
            result.push_back(c);
        }
    }
    return result;
}

void displayInfo(const Constellation& c) {
    cout << "\n✨ " << c.name << "\n";
    cout << "Abbreviation: " << c.abbr << "\n";
    cout << "Hemisphere: " << c.hemisphere << "\n";
    cout << "Season: " << (char)toupper(c.season[0]) << c.season.substr(1) << "\n";
    cout << "Brightest Star: " << c.brightest_star << "\n";
    cout << "Mythology: " << c.mythology << "\n";
    cout << "Notable Objects: " << c.notable_objects << "\n";
}

int main(int argc, char* argv[]) {
    if (argc < 2) {
        cerr << "Usage: seasonal_stars <command> [options]\n";
        return 1;
    }
    string cmd = argv[1];

    if (cmd == "list") {
        string hemisphere = "all";
        for (int i=2; i<argc; i++) {
            if (string(argv[i]) == "--hemisphere" && i+1 < argc) {
                hemisphere = argv[++i];
            }
        }
        auto results = listAll(hemisphere);
        cout << "\n📋 All Constellations (" << results.size() << "):\n";
        for (auto& c : results) {
            cout << "  " << c.name << " (" << c.abbr << ") – " << c.hemisphere << " – " << c.season << "\n";
        }
    } else if (cmd == "season") {
        if (argc < 3) { cerr << "season <spring|summer|autumn|winter>\n"; return 1; }
        string season = argv[2];
        map<string, string> emojis = {{"spring", "🌸"}, {"summer", "☀️"}, {"autumn", "🍂"}, {"winter", "❄️"}};
        auto results = bySeason(season);
        cout << "\n" << emojis[season] << " Constellations Visible in " << (char)toupper(season[0]) << season.substr(1) << ":\n";
        for (auto& c : results) {
            cout << "  " << c.name << " (" << c.abbr << ") – " << c.hemisphere << "\n";
        }
    } else if (cmd == "info") {
        if (argc < 3) { cerr << "info <name|abbr>\n"; return 1; }
        const Constellation* c = getInfo(argv[2]);
        if (c) {
            displayInfo(*c);
        } else {
            cout << "❌ Constellation '" << argv[2] << "' not found.\n";
        }
    } else if (cmd == "search") {
        if (argc < 3) { cerr << "search <term>\n"; return 1; }
        auto results = search(argv[2]);
        if (!results.empty()) {
            cout << "\n🔍 Found " << results.size() << " constellation(s):\n";
            for (auto& c : results) {
                cout << "  " << c.name << " (" << c.abbr << ") – " << c.season << " – " << c.mythology.substr(0, min(60u, c.mythology.length())) << "...\n";
            }
        } else {
            cout << "❌ No matches found.\n";
        }
    } else {
        cerr << "Unknown command. Use list, season, info, search.\n";
        return 1;
    }
    return 0;
}
