using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace Text_To_Speech
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
            Grammar word = new DictationGrammar();
            sr.LoadGrammar(word);

            try {
                this.label1.Text = "Listening...";
                this.label1.Visible = true;
                sr.SetInputToDefaultAudioDevice();
                RecognitionResult result = sr.Recognize();
                this.label1.Text = result.Text;
            }
            catch {
                MessageBox.Show("Mic not found");
                this.label1.Visible =false;
            }
            finally
            {
                sr.UnloadAllGrammars();
            }
        }
    }
}
