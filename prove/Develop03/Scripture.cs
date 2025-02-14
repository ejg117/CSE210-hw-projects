using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public ScriptureReference Reference { get; }
    private List<Word> Words { get; }

    public Scripture(ScriptureReference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public bool HideWords(int count = 2)
    {
        var visibleWords = Words.Where(word => !word.IsHidden).ToList();
        if (visibleWords.Count == 0) return false;

        Random random = new Random();
        foreach (var word in visibleWords.OrderBy(_ => random.Next()).Take(Math.Min(count, visibleWords.Count)))
        {
            word.Hide();
        }
        return true;
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine($"\n{Reference}");
        Console.WriteLine(string.Join(" ", Words));
    }
}