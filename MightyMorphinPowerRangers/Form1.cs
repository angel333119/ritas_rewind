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
        }

        private void button1_Click(object sender, EventArgs e)
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

                        idioma[0] = "alemão";
                        inicioponteiros[0] = 0x8070;
                        iniciotexto[0] = 0xA170;

                        idioma[1] = "inglês";
                        inicioponteiros[1] = 0x01509C;
                        iniciotexto[1] = 0x01719C;

                        idioma[2] = "espanhol";
                        inicioponteiros[2] = 0x02084C;
                        iniciotexto[2] = 0x02294C;

                        idioma[3] = "francês";
                        inicioponteiros[3] = 0x02D2A8;
                        iniciotexto[3] = 0x02F3A8;

                        idioma[4] = "italiano";
                        inicioponteiros[4] = 0x03A85C;
                        iniciotexto[4] = 0x03C95C;

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

                                todosostextos = "//" + utf8.Replace("\n","<ql>").Replace("\0", string.Empty);

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

        private void button2_Click(object sender, EventArgs e)
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
                            int inicioponteiros = 0x03A85C;
                            int iniciotexto = 0x03C95C;

                            br.BaseStream.Seek(inicioponteiros, SeekOrigin.Begin);

                            int ponteiro = br.ReadInt32();

                            br.BaseStream.Seek(-4, SeekOrigin.Current);

                            int novoponteiro = ponteiro;

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

                                novoponteiro = 0x2100 - (i * 8) + tamanhototaltextos;

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
}