using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MightyMorphinPowerRangers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton1.CheckedChanged += RadioButton_CheckedChanged;
            radioButton2.CheckedChanged += RadioButton_CheckedChanged;
            radioButton3.CheckedChanged += RadioButton_CheckedChanged;
            radioButton4.CheckedChanged += RadioButton_CheckedChanged;
            radioButton5.CheckedChanged += RadioButton_CheckedChanged;
            radioButton6.CheckedChanged += RadioButton_CheckedChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked && !radioButton5.Checked && !radioButton6.Checked)
            {
                MessageBox.Show("Por favor, selecione uma opção antes de continuar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Arquivo Mighty Morphin Power Rangers|locale.strings|Todos os arquivos (*.*)|*.*";
                openFileDialog1.Title = "Escolha um arquivo do jogo Mighty Morphin Power Rangers Rita's Rewind...";
                openFileDialog1.Multiselect = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    foreach (String file in openFileDialog1.FileNames)
                    {
                        using (FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            BinaryReader br = new BinaryReader(stream);

                            int blocos = 5;

                            string[] idioma = new string[blocos];
                            int[] inicioponteiros = new int[blocos];
                            int[] iniciotexto = new int[blocos];

                            if (radioButton1.Checked) //Switch 1.0.1
                            {
                                idioma[0] = "alemão";
                                inicioponteiros[0] = 0x10468;
                                iniciotexto[0] = 0x127D8;

                                idioma[1] = "inglês";
                                inicioponteiros[1] = 0x1DD20;
                                iniciotexto[1] = 0x20090;

                                idioma[2] = "espanhol";
                                inicioponteiros[2] = 0x29E80;
                                iniciotexto[2] = 0x2C1F0;

                                idioma[3] = "francês";
                                inicioponteiros[3] = 0x3F494;
                                iniciotexto[3] = 0x41804;

                                idioma[4] = "italiano";
                                inicioponteiros[4] = 0x4D294;
                                iniciotexto[4] = 0x4F604;
                            }
                            else if (radioButton2.Checked) //Switch 1.0.3
                            {
                                idioma[0] = "alemão";
                                inicioponteiros[0] = 0x8070;
                                iniciotexto[0] = 0xA190;

                                idioma[1] = "inglês";
                                inicioponteiros[1] = 0x15068;
                                iniciotexto[1] = 0x17188;

                                idioma[2] = "espanhol";
                                inicioponteiros[2] = 0x207BC;
                                iniciotexto[2] = 0x228DC;

                                idioma[3] = "francês";
                                inicioponteiros[3] = 0x2D1DC;
                                iniciotexto[3] = 0x2F2FC;

                                idioma[4] = "italiano";
                                inicioponteiros[4] = 0x3A754;
                                iniciotexto[4] = 0x3C874;
                            }
                            else if (radioButton3.Checked) //Switch 1.0.4
                            {
                                idioma[0] = "alemão";
                                inicioponteiros[0] = 0x8070;
                                iniciotexto[0] = 0xA1A0;

                                idioma[1] = "inglês";
                                inicioponteiros[1] = 0x15178;
                                iniciotexto[1] = 0x172A8;

                                idioma[2] = "espanhol";
                                inicioponteiros[2] = 0x209C4;
                                iniciotexto[2] = 0x22AF4;

                                idioma[3] = "francês";
                                inicioponteiros[3] = 0x2D4F0;
                                iniciotexto[3] = 0x2F620;

                                idioma[4] = "italiano";
                                inicioponteiros[4] = 0x3AB88;
                                iniciotexto[4] = 0x3CCB8;
                            }
                            else if (radioButton4.Checked) //Switch 1.0.5
                            {
                                idioma[0] = "alemão";
                                inicioponteiros[0] = 0x8070;
                                iniciotexto[0] = 0xA1A8;

                                idioma[1] = "inglês";
                                inicioponteiros[1] = 0x1518C;
                                iniciotexto[1] = 0x172C4;

                                idioma[2] = "espanhol";
                                inicioponteiros[2] = 0x209EC;
                                iniciotexto[2] = 0x22B24;

                                idioma[3] = "francês";
                                inicioponteiros[3] = 0x2D52C;
                                iniciotexto[3] = 0x2F664;

                                idioma[4] = "italiano";
                                inicioponteiros[4] = 0x3ABE0;
                                iniciotexto[4] = 0x3CD18;
                            }
                            else if (radioButton5.Checked) //PC - STEAM Original
                            {
                                idioma[0] = "alemão";
                                inicioponteiros[0] = 0x8070;
                                iniciotexto[0] = 0xA190;

                                idioma[1] = "inglês";
                                inicioponteiros[1] = 0x15068;
                                iniciotexto[1] = 0x17188;

                                idioma[2] = "espanhol";
                                inicioponteiros[2] = 0x207BC;
                                iniciotexto[2] = 0x228DC;

                                idioma[3] = "francês";
                                inicioponteiros[3] = 0x2D1DC;
                                iniciotexto[3] = 0x2F2FC;

                                idioma[4] = "italiano";
                                inicioponteiros[4] = 0x3A754;
                                iniciotexto[4] = 0x3C874;
                            }
                            else if (radioButton6.Checked) //PC - STEAM Portátil
                            {
                                idioma[0] = "alemão";
                                inicioponteiros[0] = 0x8070;
                                iniciotexto[0] = 0xA188;

                                idioma[1] = "inglês";
                                inicioponteiros[1] = 0x15054;
                                iniciotexto[1] = 0x1716C;

                                idioma[2] = "espanhol";
                                inicioponteiros[2] = 0x20794;
                                iniciotexto[2] = 0x228AC;

                                idioma[3] = "francês";
                                inicioponteiros[3] = 0x2D1A0;
                                iniciotexto[3] = 0x2F2B8;

                                idioma[4] = "italiano";
                                inicioponteiros[4] = 0x3A700;
                                iniciotexto[4] = 0x3C818;
                            }

                            string[][] idiomas = new string[blocos][];

                            for (int a = 0; a < blocos; a++)
                            {
                                br.BaseStream.Seek(inicioponteiros[a], SeekOrigin.Begin);

                                int primeiroponteiro = br.ReadInt32();

                                int quantidadetextos = primeiroponteiro / 8;

                                br.BaseStream.Seek(-4, SeekOrigin.Current);

                                int[] ponteiros = new int[quantidadetextos];
                                int[] tamanhotexto = new int[quantidadetextos];

                                for (int i = 0; i < quantidadetextos; i++)
                                {
                                    ponteiros[i] = br.ReadInt32();
                                    tamanhotexto[i] = br.ReadInt32();
                                }

                                br.BaseStream.Seek(iniciotexto[a], SeekOrigin.Begin);

                                idiomas[a] = new string[quantidadetextos];

                                string todosostextos = "";

                                for (int i = 0; i < quantidadetextos; i++)
                                {
                                    byte[] bytes = br.ReadBytes(tamanhotexto[i] + 1);

                                    string utf8 = Encoding.UTF8.GetString(bytes);

                                    todosostextos = "//" + utf8.Replace("\n", "<ql>").Replace("\0", string.Empty);

                                    idiomas[a][i] = todosostextos;
                                }
                            }

                            StringBuilder sb = new StringBuilder();

                            for (int i = 0; i < idiomas[0].Length; i++)
                            {
                                sb.AppendLine(idiomas[3][i]); // Adiciona o texto do idioma francês
                                sb.AppendLine(idiomas[2][i]); // Adiciona o texto do idioma espanhol
                                sb.AppendLine(idiomas[1][i]); // Adiciona o texto do idioma inglês
                                sb.AppendLine(); // Linha em branco
                            }
                            File.WriteAllText(Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file)) + ".txt", sb.ToString(), Encoding.UTF8);
                        }
                    }
                    MessageBox.Show("Terminado!", "AVISO!");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked && !radioButton5.Checked && !radioButton6.Checked)
            {
                MessageBox.Show("Por favor, selecione uma opção antes de continuar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Arquivo Mighty Morphin Power Rangers|locale.strings|Todos os arquivos (*.*)|*.*";
                openFileDialog1.Title = "Escolha um arquivo do jogo Mighty Morphin Power Rangers Rita's Rewind...";
                openFileDialog1.Multiselect = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    foreach (String file in openFileDialog1.FileNames)
                    {
                        using (FileStream stream = File.Open(file, FileMode.Open))
                        {
                            BinaryReader br = new BinaryReader(stream);
                            BinaryWriter bw = new BinaryWriter(stream);

                            FileInfo dump = new FileInfo(Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file)) + ".txt");

                            string arquivotxt = (Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file)) + ".txt");

                            if (!dump.Exists)
                            {
                                MessageBox.Show("O arquivo locale.txt não foi encontrado! Certifique-se que o arquivo esteja na mesma pasta do arquivo locale.strings", "AVISO!");
                            }
                            else
                            {
                                int inicioponteiros = 0;
                                int iniciotexto = 0;

                                if (radioButton1.Checked) //Switch 1.0.1
                                {
                                    //idioma = "italiano"
                                    inicioponteiros = 0x4D294;
                                    iniciotexto = 0x4F604;
                                }
                                else if (radioButton2.Checked) //Switch 1.0.3
                                {
                                    //idioma[4] = "italiano"
                                    inicioponteiros = 0x3A754;
                                    iniciotexto = 0x3C874;
                                }
                                else if (radioButton3.Checked) //Switch 1.0.4
                                {
                                    //idioma[4] = "italiano"
                                    inicioponteiros = 0x3AB88;
                                    iniciotexto = 0x3CCB8;
                                }
                                else if (radioButton4.Checked) //Switch 1.0.5
                                {
                                    //idioma = "italiano"
                                    inicioponteiros = 0x3ABE0;
                                    iniciotexto = 0x3CD18;
                                }
                                else if (radioButton5.Checked) //PC - STEAM Original
                                {
                                    //idioma = "italiano"
                                    inicioponteiros = 0x3A754;
                                    iniciotexto = 0x3C874;
                                }
                                else if (radioButton6.Checked) //PC - STEAM Portátil
                                {
                                    //idioma = "italiano"
                                    inicioponteiros = 0x3A700;
                                    iniciotexto = 0x3C818;
                                }

                                br.BaseStream.Seek(inicioponteiros, SeekOrigin.Begin);

                                int ponteiro = br.ReadInt32();

                                br.BaseStream.Seek(-4, SeekOrigin.Current);

                                int novoponteiro;

                                var linhasFiltradas = File.ReadLines(arquivotxt).Where(linha => !string.IsNullOrWhiteSpace(linha) && !linha.TrimStart().StartsWith("//"));

                                int i = 0;

                                stream.SetLength(iniciotexto);

                                int tamanhototaltextos = 0;

                                foreach (var linha in linhasFiltradas)
                                {
                                    string linhamod = linha.Replace("<ql>", "\n");

                                    byte[] bytes = Encoding.UTF8.GetBytes(linhamod);

                                    br.BaseStream.Seek(inicioponteiros + i * 8, SeekOrigin.Begin);

                                    int tamanhotexto = bytes.Length;

                                    novoponteiro = ponteiro - (i * 8) + tamanhototaltextos;

                                    bw.Write(novoponteiro);
                                    bw.Write(tamanhotexto);

                                    br.BaseStream.Seek(iniciotexto + tamanhototaltextos, SeekOrigin.Begin);

                                    tamanhototaltextos += tamanhotexto + 1;

                                    bw.Write(bytes);
                                    bw.Write((byte)0);

                                    i++;
                                }
                            }
                        }
                    }
                    MessageBox.Show("Terminado!", "AVISO!");
                }
            }
        }
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton selectedRadioButton && selectedRadioButton.Checked)
            {
                // Percorre todos os controles do formulário
                foreach (Control control in this.Controls)
                {
                    // Desmarca outros RadioButtons
                    if (control is RadioButton radioButton && radioButton != selectedRadioButton)
                    {
                        radioButton.Checked = false;
                    }
                }
                foreach (Control groupControl in this.Controls.OfType<GroupBox>())
                {
                    foreach (Control nestedControl in groupControl.Controls)
                    {
                        if (nestedControl is RadioButton radioButton && radioButton != selectedRadioButton)
                        {
                            radioButton.Checked = false;
                        }
                    }
                }
            }
        }
    }
}
