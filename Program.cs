// See https://aka.ms/new-console-template for more information
printFromEffectivelyAllPossibilities();
printFromMonteCarloSimulation();

const int NumDieFaces = 6;
const int NumDiceThrownPerSide = 6;

void printMatches(int[] matchCounts)
{
    Console.WriteLine("NumMatches,n(NumMatches),p(NumMatches),p(>=NumMatches),p(<=NumMatches)");

    var numIterations = matchCounts.Sum();
    int runningSum = 0;
    double expectedValue = 0;

    for(int damage = 0; damage < matchCounts.Length; damage++)
    {
        var matchCount = matchCounts[damage];
        var frequency = matchCount / (double)numIterations;
        expectedValue += damage * frequency;

        Console.WriteLine(
            damage
            + ", " + matchCount.ToString("D9")
            + ", " + frequency.ToString("N4")
            + ", " + ((numIterations - runningSum) / (double)numIterations).ToString("N4")
            + ", " + ((matchCount + runningSum) / (double)numIterations).ToString("N4")
            );
        runningSum += matchCount;
    }

    Console.WriteLine("expectedValue=" + expectedValue.ToString("N4"));
    Console.WriteLine("iterations=" + numIterations);
}

void printFromEffectivelyAllPossibilities()
{
    // assume first die outcome is 1
    const int multiValForRemainingIsSixes = 362797055;
    var p1FaceCounts = new int[NumDieFaces];
    var p2FaceCounts = new int[NumDieFaces];
    var matchCounts = new int[NumDiceThrownPerSide + 1];

    for (int diceMultiVal = 0; diceMultiVal <= multiValForRemainingIsSixes; diceMultiVal++)
    {
        Array.Clear(p1FaceCounts);
        Array.Clear(p2FaceCounts);
        var multiValCopy = diceMultiVal;

        for(int p2DieIdx = 0; p2DieIdx < NumDiceThrownPerSide; p2DieIdx++)
        {
            multiValCopy = Math.DivRem(multiValCopy, NumDieFaces, out var dieFace);
            p2FaceCounts[dieFace]++;
        }

        for(int p1DieIdx = 0; p1DieIdx < NumDiceThrownPerSide - 1; p1DieIdx++)
        {
            multiValCopy = Math.DivRem(multiValCopy, NumDieFaces, out var dieFace);
            p1FaceCounts[dieFace]++;
        }

        p1FaceCounts[0]++; // for the assumed first roll of a 1

        var matchCount = 0;

        for (int faceIdx = 0; faceIdx < NumDieFaces; faceIdx++)
        {
            matchCount += Math.Min(p1FaceCounts[faceIdx], p2FaceCounts[faceIdx]);
        }

        matchCounts[matchCount]++;
    }

    Console.WriteLine("all possibilities");
    printMatches(matchCounts);
    Console.WriteLine();

}

void printFromMonteCarloSimulation(int numSimulations = (int)1e8)
{
    var rng = new Random();
    var pipCounts1 = new int[NumDieFaces];
    var pipCounts2 = new int[NumDieFaces];
    var matchCounts = new int[NumDiceThrownPerSide + 1];

    for (int i = 0; i < numSimulations; i++)
    {
        var matchCount = mirrorOfMindsMatchCount(pipCounts1, pipCounts2, rng);
        matchCounts[matchCount]++;
    }

    Console.WriteLine("Monte Carlo");
    printMatches(matchCounts);
    Console.WriteLine();
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