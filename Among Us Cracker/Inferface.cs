using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Among_Us_Cracker
{
    public partial class Inferface : Form
    {

        string source = "playerPrefs";
        string destination = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData), "../LocalLow/Innersloth/Among Us/playerPrefs");
        string crack = "a,1,0,1,False,False,False,0,False,False,0,17,29,1,0,0,0,False,1,True,0,1,,1,1,2000,04/01/2021 09:39:27,1,False,CrackeadoPorFoxPlaysalone@gmail.com,True";

        public Inferface()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://youtube.com/c/FoxPlaysAlone");
        }

        string replaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        private void copyFile()
        {
            if (File.Exists(destination))
            {
                try
                {
                    File.Delete(destination);
                }
                catch
                {
                    MessageBox.Show("No se pudo reemplazar el archivo.");
                }
            }
            File.Copy(source, destination);
        }

        private void createFile()
        {
            using (StreamWriter sw = File.CreateText(source))
            {
                sw.WriteLine(crack);
            }
        }

        private void btnCrack_Click(object sender, EventArgs e)
        {
            btnCrack.Image = Properties.Resources.btn;

            if (txtNombre.Text == "")
            {
                MessageBox.Show("Por favor ingresa un nombre", "Error!");
            }
            else
            {
                if (!File.Exists(source))
                {
                    createFile();
                }
                else
                {
                    File.Delete(source);
                    createFile();
                }
                string text = File.ReadAllText(source);
                string name = text.Substring(0, text.IndexOf(','));
                text = replaceFirst(text, name, txtNombre.Text);
                File.WriteAllText(source, text);
            copyFile();
            File.Delete(source);
            MessageBox.Show("El juego se ha crackeado con éxito.\n\nSuscribete al canal!", "Juego crackeado.");
            }

        }

        private void btnCrack_MouseEnter(object sender, EventArgs e)
        {
            btnCrack.Image = Properties.Resources.btn_hover;
        }

        private void btnCrack_MouseLeave(object sender, EventArgs e)
        {
            btnCrack.Image = Properties.Resources.btn;
        }

    }
}
