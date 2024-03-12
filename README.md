# KillTeamMirrorOfMinds

This is a Monte Carlo simulation to estimate damage/match probabilities for
Mirror Of Minds psychic power.

## Background

Kill Team (2021 edition) has a Harlequin Void-Dance Troupe kill team (revealed
in White Dwarf 474).  The Void-Dancer Troupe Shadowseer operative can perform a
Mirror Of Minds psychic power:

> Select one enemy operative within this operative's Line of Sight.  Both
players roll six D6.  Pair your dice with your opponent's dice based on
matching results.  For each matching pair, that enemy operative suffers 1
mortal wound.  For example, if you roll ***6***, ***5***, 5, ***4***, 2, ***1*** and
your opponent rolls ***6***, ***5***, ***4***, 4, 3, ***1***, that enemy operative
would suffer 4 mortal wounds.

## Output
```
all possibilities
NumMatches,n(NumMatches),p(NumMatches),p(>=NumMatches),p(<=NumMatches)
0, 002214105, 0.0061, 1.0000, 0.0061
1, 021111660, 0.0582, 0.9939, 0.0643
2, 077425830, 0.2134, 0.9357, 0.2777
3, 132229900, 0.3645, 0.7223, 0.6422
4, 100848975, 0.2780, 0.3578, 0.9202
5, 027491880, 0.0758, 0.0798, 0.9959
6, 001474706, 0.0041, 0.0041, 1.0000
expectedValue=3.0936
iterations=362797056

Monte Carlo
NumMatches,n(NumMatches),p(NumMatches),p(>=NumMatches),p(<=NumMatches)
0, 000610143, 0.0061, 1.0000, 0.0061
1, 005817604, 0.0582, 0.9939, 0.0643
2, 021343524, 0.2134, 0.9357, 0.2777
3, 036447337, 0.3645, 0.7223, 0.6422
4, 027794322, 0.2779, 0.3578, 0.9201
5, 007579888, 0.0758, 0.0799, 0.9959
6, 000407182, 0.0041, 0.0041, 1.0000
expectedValue=3.0937
iterations=100000000
```
