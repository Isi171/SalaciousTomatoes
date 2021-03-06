﻿public static class CustomRandom
{
    private static readonly System.Random random = new System.Random();

    public static int Next(int maxValue)
    {
        return random.Next(maxValue);
    }

    public static int Next(int minValue, int maxValue)
    {
        return random.Next(minValue, maxValue);
    }

    public static T From<T>(T[] array)
    {
        return array[random.Next(array.Length)];
    }
}
