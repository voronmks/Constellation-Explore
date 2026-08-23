🌟 Constellation Explorer (by Season) — Multi‑Language Seasonal Sky Guide
8 languages, one complete seasonal guide – discover which constellations are visible in each season, learn their mythology, brightest stars, and celestial positions – right from your terminal.

✨ Features
🌿 Seasonal views – see constellations visible in Spring, Summer, Autumn, Winter

📋 List all constellations – with names, abbreviations, and best viewing season

📖 Detailed information – mythology, brightest star, notable objects

🔍 Search – by name, abbreviation, or mythology keyword

🌍 Hemisphere filter – show only Northern or Southern constellations

🎨 Color‑coded output – distinct colors for each season (where supported)

💾 Built‑in data – no external API required

🧰 Supported Languages & Files
Language	File
Python	seasonal_stars.py
Go	seasonal_stars.go
JavaScript (Node)	seasonal_stars.js
Ruby	seasonal_stars.rb
PHP	seasonal_stars.php
Java	SeasonalStars.java
C#	SeasonalStars.cs
C++	seasonal_stars.cpp
🚀 Quick Start
All implementations follow the same CLI pattern:

bash
# Show all constellations (with seasons)
<command> list

# Show only Northern constellations
<command> list --hemisphere north

# Show constellations visible in summer
<command> season summer

# Get detailed info about a constellation
<command> info Orion

# Search by term
<command> search "hunter"
Commands/Arguments:

list [--hemisphere north|south|all] – show all constellations

season <spring|summer|autumn|winter> – show constellations for a season

info <name|abbr> – detailed constellation information

search <term> – search by name, abbreviation, or mythology

📸 Example Output
text
🌟 Constellations Visible in Summer:

  🌞 Summer constellations:
  • Aquila (Aql) – Eagle
  • Cygnus (Cyg) – Swan
  • Hercules (Her) – Hero
  • Lyra (Lyr) – Lyre
  • Sagittarius (Sgr) – Archer
  • Scorpius (Sco) – Scorpion

📖 Orion:
  Abbreviation: Ori
  Hemisphere: both
  Season: winter
  Brightest Star: Betelgeuse (Alpha Orionis, 0.42 mag)
  Mythology: Orion, a mighty hunter in Greek mythology...
  Notable Objects: Orion Nebula (M42), Horsehead Nebula
📁 Repository Structure
text
.
├── README.md
├── python/
│   └── seasonal_stars.py
├── go/
│   └── seasonal_stars.go
├── javascript/
│   └── seasonal_stars.js
├── ruby/
│   └── seasonal_stars.rb
├── php/
│   └── seasonal_stars.php
├── java/
│   └── SeasonalStars.java
├── csharp/
│   └── SeasonalStars.cs
└── cpp/
    └── seasonal_stars.cpp
