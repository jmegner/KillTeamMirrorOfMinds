# KillTeamMirrorOfMinds

This is a Monte Carlo simulation to estimate damage/match probabilities for
Mirror Of Minds psychic power.

## Background

Kill Team (2021 edition) has a Harlequin Void-Dance Trouple kill team (revealed
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
NumMatches,n(NumMatches),p(NumMatches),p(>=NumMatches),p(<=NumMatches)
0, 000610928, 0.0061, 1.0000, 0.0061
1, 005817186, 0.0582, 0.9939, 0.0643
2, 021348422, 0.2135, 0.9357, 0.2778
3, 036445107, 0.3645, 0.7222, 0.6422
4, 027794217, 0.2779, 0.3578, 0.9202
5, 007577990, 0.0758, 0.0798, 0.9959
6, 000406150, 0.0041, 0.0041, 1.0000
expectedValue=3.0935
```
