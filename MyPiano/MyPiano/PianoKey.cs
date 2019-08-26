using System;
using System.Windows.Forms;

namespace MyPiano
{
    public class PianoKey
    {
        public string Name { get; set; }
        public double Frequency { get; set; }
        public int Duration { get; set; }

        public static string[] NotesName = { "A10", "A11", "B10", "C20", "C22", "D20", "D22", "E20", "F20", "F22", "G20", "G22" };
        public static double[] NotesValue = { 55.0, 58.27, 61.73, 65.40, 69.29, 73.41, 77.78, 82.40, 87.30, 92.49, 97.99, 103.82 };

        public PianoKey(string name, int durat)
        {
            Name = name;
            Duration = durat;
        }

        public static void RenameKeyInNotes(string name1, ref string name2,Button btn)
        {
          
            if (name1 != "ShiftKey, Shift" && name1 != "ShiftKey" && name1 != "Shift" )
            {
                if (name1 == "D6") { name2 = "A10"; }
                if (name1 == "D6, Shift") { name2 = "A11"; }
                if (name1 == "D7") { name2 = "B10"; }
                if (name1 == "D8") { name2 = "C20"; }
                if (name1 == "D8, Shift") { name2 = "C22"; }
                if (name1 == "D9") { name2 = "D20"; }
                if (name1 == "D9, Shift") { name2 = "D22"; }
                if (name1 == "D0") { name2 = "E20"; }
                if (name1 == "Q") { name2 = "F20"; }
                if (name1 == "Q, Shift") { name2 = "F22"; }
                if (name1 == "W") { name2 = "G20"; }
                if (name1 == "W, Shift") { name2 = "G22"; }

                if (name1 == "E") { name2 = "A20"; }
                if (name1 == "E, Shift") { name2 = "A22"; }
                if (name1 == "R") { name2 = "B20"; }
                if (name1 == "T") { name2 = "C30"; }
                if (name1 == "T, Shift") { name2 = "C33"; }
                if (name1 == "Y") { name2 = "D30"; }
                if (name1 == "Y, Shift") { name2 = "D33"; }
                if (name1 == "U") { name2 = "E30"; }
                if (name1 == "I") { name2 = "F30"; }
                if (name1 == "I, Shift") { name2 = "F33"; }
                if (name1 == "O") { name2 = "G30"; }
                if (name1 == "O, Shift") { name2 = "G33"; }

                if (name1 == "P") { name2 = "A30"; }
                if (name1 == "P, Shift") { name2 = "A33"; }
                if (name1 == "A") { name2 = "B30"; }
                if (name1 == "S") { name2 = "C40"; }
                if (name1 == "S, Shift") { name2 = "C44"; }
                if (name1 == "D") { name2 = "D40"; }
                if (name1 == "D, Shift") { name2 = "D44"; }
                if (name1 == "F") { name2 = "E40"; }
                if (name1 == "G") { name2 = "F40"; }
                if (name1 == "G, Shift") { name2 = "F44"; }
                if (name1 == "H") { name2 = "G40"; }
                if (name1 == "H, Shift") { name2 = "G44"; }

                if (name1 == "J") { name2 = "A40"; }
                if (name1 == "J, Shift") { name2 = "A44"; }
                if (name1 == "K") { name2 = "B40"; }
                if (name1 == "L") { name2 = "C50"; }
                if (name1 == "L, Shift") { name2 = "C55"; }
                if (name1 == "Z") { name2 = "D50"; }
                if (name1 == "Z, Shift") { name2 = "D55"; }
                if (name1 == "X") { name2 = "E50"; }
                if (name1 == "C") { name2 = "F50"; }
                if (name1 == "C, Shift") { name2 = "F55"; }
                if (name1 == "V") { name2 = "G50"; }
                if (name1 == "V, Shift") { name2 = "G55"; }

                if (name1 == "B") { name2 = "A50"; }
                if (name1 == "B, Shift") { name2 = "A55"; }
                if (name1 == "N") { name2 = "B50"; }
            }
            else { name2 = ""; }
            Bank1.PressKey = true;
            btn.Text ="Piano key now: "+ name2;
        }

        public static void FrequencySound(string KeyName)
        {
            if (KeyName != "ShiftKey, Shift" && KeyName != "ShiftKey" && KeyName != "Shift" && KeyName!="")
            {
                double freq = 0;
                int Index = 0;
                for (int i = 0; i < 12; i++)
                {
                    if (KeyName[0] == (NotesName[i])[0])
                    {
                        Index = i;
                        Bank1.PressKey = false; /*MessageBox.Show($"Index = {i}");*/
                        if (KeyName[1] == KeyName[2])
                        {
                            Index++;
                        }
                        break;
                    }
                }

                for (int i = Convert.ToInt32(Convert.ToString(NotesName[Index][1])); i < Convert.ToInt32(Convert.ToString(KeyName[1])); i++)
                {
                    freq = freq + (2 * NotesValue[Index]);
                }

                Console.Beep(Convert.ToInt32(Math.Round(Convert.ToDecimal(freq))), 200);
            }
        }



    }
}

