namespace AdventOfCode2024.helpers;

public static class Helpers {
    public static IEnumerable<T> NonConsecutive<T>(this IEnumerable<T> input, Func<T, T, bool> comparator)
    {
        bool isFirst = true;
        T? last = default;
        foreach (var item in input) {
            if (isFirst || comparator(item, last)) {
                yield return item;
                last = item;
                isFirst = false;
            }
        }
    }
}