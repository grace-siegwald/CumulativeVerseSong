using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CumulativeVerseSong
{
    class DaysOfChristmas
    {
        List<string> Days = new()
        {
            "first", "second", "third", "fourth", "fifth", "sixth", "seventh", "eighth", "ninth", "tenth", "eleventh", "twelfth"
        };
        List<string> GiftsMasterList = new()
        {
            "a partridge in a pear tree.",
            "two turtle doves",
            "three French hens",
            "four calling birds",
            "five golden rings",
            "six geese a laying",
            "seven swans a swimming",
            "eight maids a milking",
            "nine ladies dancing",
            "ten lords a leaping",
            "eleven pipers piping",
            "twelve drummers drumming",
        };

        public DaysOfChristmas()
        {
            Console.Write(SongText());
            PlaySong();
        }

        public void PlayNote(int frequency, int duration)
        {
            Console.Beep(frequency, duration);
            Thread.Sleep(50); // Short pause between notes
        }

        public void PlaySong()
        {
            int C = 261, D = 294, E = 329, F = 349, G = 392, A = 440, A_Sharp = 466, B = 494;
            int quarter = 300, half = 600, whole = 850;

            PlayNote(C, quarter); PlayNote(C, quarter); PlayNote(C, half); // "On the first"
            PlayNote(F, quarter); PlayNote(F, quarter); PlayNote(F, half); PlayNote(E, quarter);// "Day if Christmas"
            PlayNote(F, quarter); PlayNote(G, quarter); PlayNote(A, quarter); PlayNote(A_Sharp, quarter); PlayNote(G, quarter); PlayNote(A, whole); // "My true love came to me!"
        }

        public string SongText()
        {
            string output = "";
            
            // Creates an empty list to be given a new gift from the master list at the end of each iteration (except for the first iteration).
            List<string> Gift = new List<string>();

            // This loop will iterate 12 times in total
            for (int i = 0; i <= 11; i++)
            {
                if (i == 0)
                {
                    output += $"On the {Days[i]} day of Christmas my true love gave to me {GiftsMasterList[i]}\n\n";
                }
                else
                {
                    output += $"On the {Days[i]} day of Christmas my true love gave to me {GiftsMasterList[i]}";

                    // There are three key operations here:
                    // 1. Reversing the order of the local "Gift" list.
                    // 2. Outputting each element in the local "Gift" list in that reversed order. 
                    // 3. Reversing the "Gift" list again, resetting it for the next iteration.  
                    Gift.Reverse();
                    foreach (string g in Gift)
                    {
                        output += $", {g}";
                    }
                    Gift.Reverse();

                    output += $" and {GiftsMasterList[0]}\n\n";

                    // Adds the next element in the "GiftsMasterList" list to the local "Gift" list.
                    Gift.Add(GiftsMasterList[i]);
                }
            }
            return output;
        }
    }
}
