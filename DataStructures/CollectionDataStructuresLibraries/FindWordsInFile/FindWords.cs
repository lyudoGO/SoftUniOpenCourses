namespace FindWordsInFile
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class FindWords
    {
        static void Main()
        {
            try
            {
                string inputFile = @"..\..\text.txt";
                StreamReader inputReader = new StreamReader(inputFile);

                string inputFileWords = @"..\..\words.txt";
                string[] inputWords = File.ReadAllLines(inputFileWords);

                Dictionary<string, int> words = new Dictionary<string, int>();

                using (inputReader)
                {
                    string currentLine = inputReader.ReadLine();

                    while (currentLine != null)
                    {
                        if (currentLine != string.Empty)
                        {
                            foreach (var word in inputWords)
                            {
                                MatchCollection matches = Regex.Matches(currentLine, word);
                                if (!words.ContainsKey(word))
                                {
                                    words[word] = 0;
                                }
                                words[word] += matches.Count;
                            }
                        }
                        currentLine = inputReader.ReadLine();
                    }
                }

                foreach (KeyValuePair<string, int> pair in words)
                {
                    Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }
    }
}