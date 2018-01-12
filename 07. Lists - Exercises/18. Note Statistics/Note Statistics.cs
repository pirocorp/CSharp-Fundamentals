using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.Note_Statistics
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            string[] notes = {"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"};
            List<double> notesInHz = new List<double>{261.63, 277.18, 293.66, 311.13, 329.63, 349.23, 369.99, 392.00, 415.30, 440.00, 466.16, 493.88 };

            var inputFreq = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            var notesResultList = new List<string>();
            var stringResultNatural = new List<string>();
            var stringResultSharp = new List<string>();
            var naturalsSum = 0.0;
            var sharpsSum = 0.0;

            for (int i = 0; i < inputFreq.Count; i++)
            {
                var currentInputNoteFreq = inputFreq[i];
                var index = notesInHz.IndexOf(currentInputNoteFreq);
                var currentNote = notes[index];
                notesResultList.Add(currentNote);

                //Console.Beep((int)inputFreq[i], 100);

                if (currentNote.Contains("#"))
                {
                    stringResultSharp.Add(currentNote);
                    sharpsSum += inputFreq[i];
                }
                else
                {
                    stringResultNatural.Add(currentNote);
                    naturalsSum += inputFreq[i];
                }
            }

            Console.WriteLine($"Notes: {String.Join(" ", notesResultList)}");
            Console.WriteLine($"Naturals: {String.Join(", ", stringResultNatural)}");
            Console.WriteLine($"Sharps: {String.Join(", ", stringResultSharp)}");
            Console.WriteLine($"Naturals sum: {naturalsSum}");
            Console.WriteLine($"Sharps sum: {sharpsSum}");
            
        }
    }
}
