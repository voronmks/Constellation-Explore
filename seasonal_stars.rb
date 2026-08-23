# seasonal_stars.rb
#!/usr/bin/env ruby
require 'optparse'

CONSTELLATIONS = [
  { name: "Andromeda", abbr: "And", hemisphere: "north", season: "autumn", brightest_star: "Alpheratz (Alpha Andromedae, 2.06 mag)", mythology: "In Greek mythology, Andromeda was the daughter of King Cepheus and Queen Cassiopeia. She was chained to a rock as a sacrifice to the sea monster Cetus, but was rescued by Perseus.", notable_objects: "Andromeda Galaxy (M31), Messier 32, Messier 110" },
  { name: "Aquila", abbr: "Aql", hemisphere: "both", season: "summer", brightest_star: "Altair (Alpha Aquilae, 0.77 mag)", mythology: "Aquila represents the eagle that carried Zeus's thunderbolts in Greek mythology.", notable_objects: "Barnard's Star (nearby red dwarf)" },
  { name: "Aries", abbr: "Ari", hemisphere: "north", season: "autumn", brightest_star: "Hamal (Alpha Arietis, 2.01 mag)", mythology: "Aries represents the ram with the golden fleece in Greek mythology.", notable_objects: "Spiral galaxy NGC 772" },
  { name: "Auriga", abbr: "Aur", hemisphere: "north", season: "winter", brightest_star: "Capella (Alpha Aurigae, 0.08 mag)", mythology: "Auriga represents the charioteer. In Greek mythology, he is often identified with Erichthonius.", notable_objects: "Messier 36, Messier 37, Messier 38 (open clusters)" },
  { name: "Boötes", abbr: "Boo", hemisphere: "north", season: "spring", brightest_star: "Arcturus (Alpha Boötis, -0.05 mag)", mythology: "Boötes represents a herdsman or plowman. In Greek mythology, he is sometimes identified with Arcas.", notable_objects: "Arcturus (brightest star in northern celestial hemisphere)" },
  { name: "Canis Major", abbr: "CMa", hemisphere: "south", season: "winter", brightest_star: "Sirius (Alpha Canis Majoris, -1.46 mag)", mythology: "Canis Major represents the larger hunting dog of Orion. Sirius, the Dog Star, is the brightest star in the night sky.", notable_objects: "Sirius (brightest star in the night sky), M41 (open cluster)" },
  { name: "Canis Minor", abbr: "CMi", hemisphere: "both", season: "winter", brightest_star: "Procyon (Alpha Canis Minoris, 0.34 mag)", mythology: "Canis Minor represents the smaller hunting dog of Orion. Procyon means 'before the dog' in Greek.", notable_objects: "Procyon (one of the nearest bright stars)" },
  { name: "Cassiopeia", abbr: "Cas", hemisphere: "north", season: "autumn", brightest_star: "Schedar (Alpha Cassiopeiae, 2.24 mag)", mythology: "Cassiopeia was the vain queen of Ethiopia who boasted about her beauty, leading to the sacrifice of her daughter Andromeda.", notable_objects: "Cassiopeia A (supernova remnant), NGC 457 (open cluster)" },
  { name: "Cygnus", abbr: "Cyg", hemisphere: "north", season: "summer", brightest_star: "Deneb (Alpha Cygni, 1.25 mag)", mythology: "Cygnus represents a swan. In Greek mythology, it is associated with Zeus, who disguised himself as a swan to seduce Leda.", notable_objects: "North America Nebula, Veil Nebula, Cygnus X-1 (black hole candidate)" },
  { name: "Draco", abbr: "Dra", hemisphere: "north", season: "spring", brightest_star: "Thuban (Alpha Draconis, 3.65 mag)", mythology: "Draco represents the dragon Ladon in Greek mythology, who guarded the golden apples of the Hesperides.", notable_objects: "Cat's Eye Nebula (NGC 6543)" },
  { name: "Gemini", abbr: "Gem", hemisphere: "north", season: "winter", brightest_star: "Pollux (Beta Geminorum, 1.16 mag)", mythology: "Gemini represents the twins Castor and Pollux, the Dioscuri in Greek mythology.", notable_objects: "Messier 35 (open cluster), Eskimo Nebula (NGC 2392)" },
  { name: "Hercules", abbr: "Her", hemisphere: "both", season: "summer", brightest_star: "Ras Algethi (Alpha Herculis, variable 2.7–4.0 mag)", mythology: "Hercules represents the legendary Greek hero who performed the Twelve Labors.", notable_objects: "Hercules Cluster (M13), NGC 6229 (globular cluster)" },
  { name: "Leo", abbr: "Leo", hemisphere: "north", season: "spring", brightest_star: "Regulus (Alpha Leonis, 1.35 mag)", mythology: "Leo represents the Nemean lion, which was slain by Hercules as the first of his Twelve Labors.", notable_objects: "Leo Triplet (M65, M66, NGC 3628), M95, M96" },
  { name: "Lyra", abbr: "Lyr", hemisphere: "north", season: "summer", brightest_star: "Vega (Alpha Lyrae, 0.03 mag)", mythology: "Lyra represents the lyre of Orpheus, the legendary musician and poet. After his death, the lyre was placed among the stars.", notable_objects: "Ring Nebula (M57), Vega (brightest star)" },
  { name: "Orion", abbr: "Ori", hemisphere: "both", season: "winter", brightest_star: "Betelgeuse (Alpha Orionis, 0.42 mag)", mythology: "Orion, a mighty hunter in Greek mythology, was placed among the stars by Zeus. He is depicted as a hunter with his belt, sword, and club.", notable_objects: "Orion Nebula (M42), Horsehead Nebula, Barnard's Loop" },
  { name: "Pegasus", abbr: "Peg", hemisphere: "north", season: "autumn", brightest_star: "Enif (Epsilon Pegasi, 2.39 mag)", mythology: "Pegasus is the winged horse from Greek mythology, born from the blood of Medusa.", notable_objects: "Great Square of Pegasus, M15 (globular cluster)" },
  { name: "Perseus", abbr: "Per", hemisphere: "north", season: "autumn", brightest_star: "Mirfak (Alpha Persei, 1.79 mag)", mythology: "Perseus is the Greek hero who slew Medusa and rescued Andromeda.", notable_objects: "Perseus Double Cluster (h+χ Persei), Algol (eclipsing binary star)" },
  { name: "Sagittarius", abbr: "Sgr", hemisphere: "south", season: "summer", brightest_star: "Kaus Australis (Epsilon Sagittarii, 1.79 mag)", mythology: "Sagittarius represents a centaur archer. In Greek mythology, he is often identified with Chiron.", notable_objects: "Galactic Center, Lagoon Nebula (M8), Trifid Nebula (M20)" },
  { name: "Scorpius", abbr: "Sco", hemisphere: "south", season: "summer", brightest_star: "Antares (Alpha Scorpii, 0.96 mag)", mythology: "Scorpius represents the scorpion that killed Orion. According to mythology, the scorpion was placed on the opposite side of the sky from Orion.", notable_objects: "Antares (red supergiant), Ptolemy's Cluster (M7), Butterfly Cluster (M6)" },
  { name: "Taurus", abbr: "Tau", hemisphere: "north", season: "winter", brightest_star: "Aldebaran (Alpha Tauri, 0.86 mag)", mythology: "Taurus represents the bull from Greek mythology. It is associated with Zeus, who transformed into a bull to abduct Europa.", notable_objects: "Pleiades (M45), Hyades, Crab Nebula (M1)" },
  { name: "Ursa Major", abbr: "UMa", hemisphere: "north", season: "spring", brightest_star: "Alioth (Epsilon Ursae Majoris, 1.77 mag)", mythology: "Ursa Major represents the Great Bear. In Greek mythology, Callisto was transformed into a bear by Hera.", notable_objects: "M81, M82 (Bode's Galaxy and Cigar Galaxy), Owl Nebula (M97)" },
  { name: "Ursa Minor", abbr: "UMi", hemisphere: "north", season: "spring", brightest_star: "Polaris (Alpha Ursae Minoris, 1.97 mag)", mythology: "Ursa Minor represents the Little Bear. It contains Polaris, the current North Star.", notable_objects: "Polaris (current North Star)" }
]

def list_all(hemisphere)
  CONSTELLATIONS.select { |c| hemisphere == 'all' || c[:hemisphere] == hemisphere || c[:hemisphere] == 'both' }
end

def by_season(season)
  CONSTELLATIONS.select { |c| c[:season] == season }
end

def get_info(query)
  CONSTELLATIONS.find { |c| c[:name].downcase == query.downcase || c[:abbr].downcase == query.downcase }
end

def search(term)
  CONSTELLATIONS.select { |c| c[:name].downcase.include?(term.downcase) || c[:abbr].downcase.include?(term.downcase) || c[:mythology].downcase.include?(term.downcase) }
end

def display_info(c)
  puts "\n✨ #{c[:name]}"
  puts "Abbreviation: #{c[:abbr]}"
  puts "Hemisphere: #{c[:hemisphere]}"
  puts "Season: #{c[:season].capitalize}"
  puts "Brightest Star: #{c[:brightest_star]}"
  puts "Mythology: #{c[:mythology]}"
  puts "Notable Objects: #{c[:notable_objects]}"
end

options = {}
$command = ARGV.shift
if $command.nil?
  puts "Usage: seasonal_stars.rb <command> [options]"
  exit 1
end

case $command
when "list"
  hemisphere = "all"
  if ARGV.include?("--hemisphere")
    idx = ARGV.index("--hemisphere")
    hemisphere = ARGV[idx+1] if idx
  end
  results = list_all(hemisphere)
  puts "\n📋 All Constellations (#{results.length}):"
  results.each { |c| puts "  #{c[:name]} (#{c[:abbr]}) – #{c[:hemisphere]} – #{c[:season]}" }

when "season"
  season = ARGV.shift
  if season.nil?
    puts "season <spring|summer|autumn|winter>"
    exit 1
  end
  emojis = { "spring" => "🌸", "summer" => "☀️", "autumn" => "🍂", "winter" => "❄️" }
  results = by_season(season)
  puts "\n#{emojis[season]} Constellations Visible in #{season.capitalize}:"
  results.each { |c| puts "  #{c[:name]} (#{c[:abbr]}) – #{c[:hemisphere]}" }

when "info"
  query = ARGV.shift
  if query.nil?
    puts "info <name|abbr>"
    exit 1
  end
  c = get_info(query)
  if c
    display_info(c)
  else
    puts "❌ Constellation '#{query}' not found."
  end

when "search"
  term = ARGV.shift
  if term.nil?
    puts "search <term>"
    exit 1
  end
  results = search(term)
  if results.length > 0
    puts "\n🔍 Found #{results.length} constellation(s):"
    results.each { |c| puts "  #{c[:name]} (#{c[:abbr]}) – #{c[:season]} – #{c[:mythology][0..60]}..." }
  else
    puts "❌ No matches found."
  end

else
  puts "Unknown command. Use list, season, info, search."
end
