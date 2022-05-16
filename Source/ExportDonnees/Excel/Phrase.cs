using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Export.Commun;

namespace Excel
{
    public class Phrase
    {
        public string[] Words;
        public int[] Spaces;
        public int length;
        public string Text;
        public Alignment Align;
        public void build()
        {
            for (int i = 0; i < Words.Length; i++)
            {
                Text += get_space(Spaces[i]);
                Text += Words[i];
            }
            Text += get_space(Spaces[Spaces.Length - 1]);
        }

        private string get_space(int s)
        {
            string Blanck = "";
            for (int i = 0; i < s; i++)
                Blanck += " ";

            return Blanck;
        }



    }
}
