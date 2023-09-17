using System;
using System.Linq;
using System.Windows.Forms;

namespace opakovani2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void poslPrvocislo(int[] pole, out int posledni, out int pozice)
        {
            posledni = 0;
            pozice = 0;
            for (int i = 0; i < pole.Length; i++)
            {
                bool prvocislo = true;
                if (pole[i] == 1) prvocislo = false;
                else for (int delitel = 2; delitel <= Math.Sqrt(pole[i]); ++delitel)
                    {
                        if (pole[i] % delitel == 0)
                        { prvocislo = false; }
                    }
                if (prvocislo)
                {
                    posledni = pole[i];
                    pozice = i;
                }
            }
        }

        private void Vypis(ListBox listbox, int[] pole)
        {
            for (int i = 0; i < pole.Count(); i++)
            {
                listbox.Items.Add(pole[i]);
            }
        }

        private void Vymen(int[] pole)
        {
            int first = pole[0];
            int last = pole[pole.Count() - 1];
            pole[0] = last;
            pole[pole.Count() - 1] = first;
        }

        private string Maximalni(string retezec)
        {
            retezec.Trim();
            while (retezec.Contains("  "))
            {
                retezec = retezec.Replace("  ", " ");
            }
            // return retezec;
            retezec.ToLower();
            string[] pole = retezec.Split(' ');
            string changeString = "";
            for (int i = 0; i < pole.Count(); i++)
            {
                if (changeString.Length < pole[i].Length)
                {
                    changeString = pole[i];
                }
            }
            return changeString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            label1.Text = "";
            label2.Text = "";
            int[] cisla = new int[(int)numericUpDown1.Value];
            Random rng = new Random();
            for (int i = 0; i < (int)numericUpDown1.Value; i++)
            {
                cisla[i] = rng.Next(1, 26);
            }
            Vypis(listBox1, cisla);
            int last = 0;
            int index = 0;
            poslPrvocislo(cisla, out last, out index);
            if (last != 0)
            {
                label1.Text = "Poslední prvočíslo:  " + last.ToString() + " s pořadím: " + (index + 1).ToString();
            }
            string text = textBox1.Text;
            label2.Text = Maximalni(text);
            Vypis(listBox2, cisla);
        }
    }
}