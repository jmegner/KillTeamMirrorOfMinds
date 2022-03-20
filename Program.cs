// See https://aka.ms/new-console-template for more information
main();

const int NumDieSides = 6;
const int NumDiceThrownPerSide = 6;

void main()
{
    var rng = new Random();
    var pipCounts1 = new int[NumDieSides];
    var pipCounts2 = new int[NumDieSides];
    var matchCounts = new int[NumDieSides + 1];
    var numSimulations = (int)1e8;

    for (int i = 0; i < numSimulations; i++)
    {
        var matchCount = mirrorOfMindsMatchCount(pipCounts1, pipCounts2, rng);
        matchCounts[matchCount]++;
    }

    Console.WriteLine("NumMatches,n(NumMatches),p(NumMatches),p(>=NumMatches),p(<=NumMatches)");

    int runningSum = 0;
    double expectedValue = 0;

    for(int damage = 0; damage < matchCounts.Length; damage++)
    {
        var matchCount = matchCounts[damage];
        var frequency = matchCount / (double)numSimulations;
        expectedValue += damage * frequency;

        Console.WriteLine(
            damage
            + ", " + matchCount.ToString("D9")
            + ", " + frequency.ToString("N4")
            + ", " + ((numSimulations - runningSum) / (double)numSimulations).ToString("N4")
            + ", " + ((matchCount + runningSum) / (double)numSimulations).ToString("N4")
            );
        runningSum += matchCount;
    }

    Console.WriteLine("expectedValue=" + expectedValue.ToString("N4"));
}

int mirrorOfMindsMatchCount(int[] pipCounts1, int[] pipCounts2, Random rng)
{
    var matchCount = 0;
    fillPipCounts(pipCounts1, rng);
    fillPipCounts(pipCounts2, rng);

    for (int pipIdx = 0; pipIdx < pipCounts1.Length; pipIdx++)
    {
        matchCount += Math.Min(pipCounts1[pipIdx], pipCounts2[pipIdx]);
    }

    return matchCount;
}

void fillPipCounts(int[] pipCounts, Random rng)
{
    Array.Clear(pipCounts);

    for (int i = 0; i < NumDiceThrownPerSide; i++)
    {
        pipCounts[rng.Next(6)]++;
    }
}