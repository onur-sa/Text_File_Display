using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;


// Difference between list and array
//


namespace Text_File_Display
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String[] lines;
        
        List<string> mylist = new List<string>();
        string file_path = "";
        string file_extension = "";
        int lineCount = 0;

        void ReadTextFile(string file_path, List<string> mylist)
        {

            // .CompareTo() ifadesi file_extension ile ".txt" stringini karşılaştırır. Eğer aynı ise int 0 dönüdürür. 
            if (file_extension.CompareTo(".txt") == 0)  // yani dosya uzantıları aynı ise --->
            {

                try
                {
                    StreamReader reader = new StreamReader(file_path);

                    while (!reader.EndOfStream)
                    {

                        mylist.Add(reader.ReadLine());
                        lineCount++;

                    }
                    reader.Close();

                }
                catch (Exception ex)
                {

                }
                //label5.Text = lineCount.ToString();
            }
        }

        void DisplayTextFileOnTextBox(String[] lines, RichTextBox richTextBox1)
        {
            for (int i = 0; i < lineCount; i++)
            {
                richTextBox1.Text += lines[i] + "\n";
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Dosya browse etmek için açılan pencereye "OpenFileDialog penceresi" deniyor.
            // Burada openFileDialog adında bir nesne oluşturup nesneye dair özellikler ekledim.

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = " Open File ";
            openFileDialog.Filter = "txt_file (*.txt)|";

            if(openFileDialog.ShowDialog() == DialogResult.OK)  // Burada ise openFileDialog dialog ekranı gösterildiğinde(.ShowDialog())
            {                                                   // birşey seçilmişse şunları yap şeklinde bir if yazdım.            
                file_path = openFileDialog.FileName;     // file_path adındaki boş stringe seçtiğim dosyanın dosya yolunu ekledim. 
                                                         // bu dosya yoluna .FileName' i kullandığım için dosyanın adını da eklemiş oldum.                                                                          
                label1.Text = file_path;
                
                file_extension = Path.GetExtension(file_path); // Daha sonra Path.GetExtension() metodu ile file_path' deki dosyanın uzantısını aldım.     
                
                label2.Text = file_extension;


                //// var lineCount = File.ReadLines(file_path).Count();

                ReadTextFile(file_path, mylist);
                String[] lines = mylist.ToArray();

                DisplayTextFileOnTextBox(lines, richTextBox1);

            }
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
