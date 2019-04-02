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
using WMPLib;
using TrabalhoMP3.Controller;
using TrabalhoMP3.Model;

namespace TrabalhoMP3
{
    public partial class Form1 : Form
    {

        List<string> Musicas = new List<string>();

        public Form1()
        {
            InitializeComponent();              
        }
        List list = new List();

        private void bttnAbrir_Click(object sender, EventArgs e)
        {            
            folderBrowserDialog.SelectedPath = openFileDialog.InitialDirectory;          
            
            DialogResult result = folderBrowserDialog.ShowDialog();
            textBoxCaminho.Text = folderBrowserDialog.SelectedPath;
            //APAGADO
            //DirectoryInfo Diret = new DirectoryInfo(textBoxCaminho.Text);

            if (result == DialogResult.OK)
            {
                DirectoryInfo Diret = new DirectoryInfo(textBoxCaminho.Text); //ADICIONADO
                IWMPPlaylist Playlist = axWindowsMediaPlayer.playlistCollection.newPlaylist("Playlist");
                int x = 0;
                int aux;//ADICIONADO
                foreach (FileInfo file in Diret.GetFiles("*.mp3", SearchOption.AllDirectories))
                {

                    IWMPMedia3 Mp3 = (IWMPMedia3)axWindowsMediaPlayer.newMedia(file.FullName);
                    aux = Convert.ToInt32(Mp3.getItemInfo("Bitrate")) / 1000; //ADICIONADO
                    list.InsertMusic(Mp3.name, Mp3.durationString, aux.ToString());//ADICIONADO
                    Playlist.appendItem(Mp3);
                    /* dataGridViewPlaylist.Rows.Add();
                       dataGridViewPlaylist.Rows[x].Cells[0].Value = (Mp3.name);
                       dataGridViewPlaylist.Rows[x].Cells[1].Value = (Mp3.durationString);
                       //Adição do Kbps 
                       dataGridViewPlaylist.Rows[x].Cells[2].Value = (aux+" kbps");
                       x++;

                       Musicas.Add(Mp3.name); //Add na List
                       Playlist.appendItem(Mp3);
                   */


                }
                //ADICIONADO
                Node timer = list.Begin;
                while (timer != null)
                {
                    dataGridViewPlaylist.Rows.Add();
                    dataGridViewPlaylist.Rows[x].Cells[0].Value = (timer.Name.ToString());
                    dataGridViewPlaylist.Rows[x].Cells[1].Value = (timer.Duraction.ToString());
                    //Adição do Kbps 
                    dataGridViewPlaylist.Rows[x].Cells[2].Value = (timer.Bitrate.ToString() + " kbps");
                    //IWMPMedia3 Mp3 = (IWMPMedia3)axWindowsMediaPlayer.newMedia(timer.Name.ToString());

                    x++;
                    timer = timer.Next;
                }
                axWindowsMediaPlayer.currentPlaylist = Playlist; //Cria a playlist no player

            }

            for (int i = 0; i < Musicas.Count; i++) //Montar a tabela
                {
                    dataGridViewPlaylist.Rows[i].Cells[0].Style.BackColor = Color.White;
                    dataGridViewPlaylist.Rows[i].Cells[1].Style.BackColor = Color.White;
                    dataGridViewPlaylist.Rows[i].Cells[2].Style.BackColor = Color.White;
                    if (i % 2 > 0 && i != 0)
                    {
                        dataGridViewPlaylist.Rows[i].Cells[0].Style.BackColor = Color.WhiteSmoke;
                        dataGridViewPlaylist.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                        dataGridViewPlaylist.Rows[i].Cells[2].Style.BackColor = Color.WhiteSmoke;
                    }
                }
            }
        }
    }
