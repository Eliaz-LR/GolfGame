using System.Collections.Generic;

public static class JsonParser
{
    public static Dictionary<string, int> Parse(string toParse)
    {
        
        toParse = toParse.Substring(1, toParse.Length - 2);
        string[] scores = toParse.Split(',');
        Dictionary<string, int> highscores = new Dictionary<string, int>();
        for (int i = 0; i < scores.Length; i++)
        {
            //"Eliaz":{"time":44.39243698120117}
            var charToRemove = new char[] { '\"', '{', '}' };
            foreach (var c in charToRemove)
            {
                scores[i] = scores[i].Replace(c.ToString(), "");
            }
            string[] score = scores[i].Split(new string[] {":totalScore:"}, System.StringSplitOptions.None);
            highscores.Add(score[0], int.Parse(score[1]));
            // highscores[i] = new Highscore(score[0], float.Parse(score[1], System.Globalization.CultureInfo.InvariantCulture));
        }

        return highscores;
    }
}