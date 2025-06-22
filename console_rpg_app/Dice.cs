public static class Dice
{
    private static Random rng = new Random();

    public static int Roll(int sides) => rng.Next(1, sides + 1);
    public static int D20() => Roll(20);
    public static int D6() => Roll(6);
    public static int D(int sides, int times) => Enumerable.Range(0, times).Sum(_ => Roll(sides));
}