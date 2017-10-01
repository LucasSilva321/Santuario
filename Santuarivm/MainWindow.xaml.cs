using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Santuarivm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ArvoreBin arvore;
        
        public MainWindow()
        {
            InitializeComponent();
            arvore = new ArvoreBin();

            if (File.Exists("Animais.txt"))
            {
      
                StreamReader r = new StreamReader("Animais.txt");
                try
                {
                    //string[] linhas = File.ReadAllLines("Animais.txt");
                    while (!r.EndOfStream)
                    {
                        string linha = r.ReadLine();
                        string[] info = linha.Split('|');
                        DateTime data = Convert.ToDateTime(info[2]);

                        if (info[0] == "Aquila Audax")
                            arvore.Insere(new AquilaAudax(info[1], data, info[3], (CoresAve)Enum.Parse(typeof(CoresAve), info[4])));
                        if (info[0] == "Kiwi")
                            arvore.Insere(new Kiwi(info[1], data, info[3], (CoresAve)Enum.Parse(typeof(CoresAve), info[4])));
                        if (info[0] == "Cisne Negro")
                            arvore.Insere(new CisneNegro(info[1], data, info[3], (CoresAve)Enum.Parse(typeof(CoresAve), info[4])));
                        if (info[0] == "Crocodilo")
                            arvore.Insere(new Crocodilo(info[1], data, info[3], (TipoDePele)Enum.Parse(typeof(TipoDePele), info[4])));
                        if (info[0] == "Taipan")
                            arvore.Insere(new Taipan(info[1], data, info[3], (TipoDePele)Enum.Parse(typeof(TipoDePele), info[4])));
                        if (info[0] == "Sapo")
                            arvore.Insere(new Sapo(info[1], data, info[3], (TipoDePele)Enum.Parse(typeof(TipoDePele), info[4])));
                        if (info[0] == "Canguru Vermelho")
                            arvore.Insere(new CanguruVermelho(info[1], data, info[3], info[4]));
                        if (info[0] == "Coala")
                            arvore.Insere(new Coala(info[1], data, info[3], info[4]));
                        if (info[0] == "Demônio da Tasmania")
                            arvore.Insere(new DemonioDaTasmania(info[1], data, info[3], info[4]));
                        if (info[0] == "Dingo")
                            arvore.Insere(new Dingo(info[1], data, info[3], info[4]));
                        if (info[0] == "Elefante Marinho")
                            arvore.Insere(new ElefanteMarinho(info[1], data, info[3], info[4]));
                        if (info[0] == "Morcego Gigante")
                            arvore.Insere(new MorcegoGigante(info[1], data, info[3], info[4]));
                        if (info[0] == "Ornitorrinco")
                            arvore.Insere(new Ornintorrinco(info[1], data, info[3], info[4]));

                    }
                    r.Close();
                  
                }
                catch(Exception erro)
                {
                    MessageBox.Show(erro.Message);
                    r.Close();
                }
               
            }

        }

        private void lblCadastrar_MouseEnter(object sender, MouseEventArgs e)
        {
            lblCadastrar.FontSize = 55;
        }

        private void lblCadastrar_MouseLeave(object sender, MouseEventArgs e)
        {
            lblCadastrar.FontSize = 50;
        }

        private void lblCadastrar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tela_Cadastro tela = new Tela_Cadastro();
            tela.arvore = arvore;
            Visibility = Visibility.Hidden;
            tela.ShowDialog();
            arvore = tela.arvore;
            Visibility = Visibility.Visible;

        }

        private void lblConsulta_MouseEnter(object sender, MouseEventArgs e)
        {
            lblConsulta.FontSize = 55;
        }

        private void lblConsulta_MouseLeave(object sender, MouseEventArgs e)
        {
            lblConsulta.FontSize = 50;
        }

        private void lblConsulta_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tela_Consulta tela = new Tela_Consulta();
            tela.arvore = arvore;
            Visibility = Visibility.Hidden;
            tela.ShowDialog();
            Visibility = Visibility.Visible;
           
           
        }

        private void Window_Closed(object sender, EventArgs e)
        {
           
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
        }

        private void lblListas_MouseEnter(object sender, MouseEventArgs e)
        {
            lblListas.FontSize = 55;

        }

        private void lblListas_MouseLeave(object sender, MouseEventArgs e)
        {
            lblListas.FontSize = 50;
        }

        private void lblListas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tela_Listagem tela = new Tela_Listagem();
           
            tela.TodosAnimais = arvore.ParaLista();
            Visibility = Visibility.Hidden;
            tela.ShowDialog();
            Visibility = Visibility.Visible;

        }

        private void lblSobre_MouseEnter(object sender, MouseEventArgs e)
        {
            lblSobre.FontSize = 55;

        }

        private void lblSobre_MouseLeave(object sender, MouseEventArgs e)
        {
            lblSobre.FontSize = 50;
        }

        private void lblSobre_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tela_Sobre tela = new Tela_Sobre();
            Visibility = Visibility.Hidden;
            tela.ShowDialog();
            Visibility = Visibility.Visible;
        }

        
    }
}
