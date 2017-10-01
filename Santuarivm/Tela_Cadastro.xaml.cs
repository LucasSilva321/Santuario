using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Santuarivm
{
    /// <summary>
    /// Interaction logic for Tela_Especies.xaml
    /// </summary>
    public partial class Tela_Cadastro : Window
    {
        internal ArvoreBin arvore;
        Storyboard mamiferos, aves, repteis;

        public Tela_Cadastro()
        {
            InitializeComponent();
            this.Height = 700;
            mamiferos = FindResource("botoesMamifero") as Storyboard;
            aves = FindResource("botoesAve") as Storyboard;
            repteis = FindResource("botoesReptil") as Storyboard;
            foreach (CoresAve item in Enum.GetValues(typeof(CoresAve)))
            {
                cbColoracaoAve.Items.Add(item);
            }
            foreach (TipoDePele item in Enum.GetValues(typeof(TipoDePele)))
            {
                cbPeleReptil.Items.Add(item);
            }
            cbColoracaoAve.SelectedIndex = 0;
            cbPeleReptil.SelectedIndex = 0;
        }

        void PreencheAtributosMamisfero(Mamifero m)
        {
            txtVenenoso.Text = m.Venenoso ? "Sim" : "Não";
            txtAlimentacao.Text = m.Alimentacao.ToString();
            txtMarsupial.Text = m.Marsupial ? "Sim" : "Não";
            txtPelo.Text = m.Pelo ? "Possui" : "Não Possui";
            txtQtdeMamas.Text = m.qtdeMamas.ToString();
            cbCoresPeloPele.SelectedIndex = 0;
            foreach (Button item in gridMamiferos.Children)
            {
                item.IsEnabled = true;
            }

        }

        void PreencheAtributosAve(Ave a)
        {
            txtVenenoso.Text = a.Venenoso ? "Sim" : "Não";
            txtAlimentacao.Text = a.Alimentacao.ToString();
            txtRapina.Text = a.Rapina ? "Possui" : "Não Possui";
            foreach (Button item in gridAves.Children)
            {
                item.IsEnabled = true;
            }
        }

        void PreencheAtributosReptil(Reptil r)
        {
            txtVenenoso.Text = r.Venenoso ? "Sim" : "Não";
            txtAlimentacao.Text = r.Alimentacao.ToString();
            foreach (Button item in gridRepteis.Children)
            {
                item.IsEnabled = true;
            }
        }

        void LimpaCampos()
        {
            foreach (var item in gridInfoGerais.Children)
            {
                if (item is TextBox) (item as TextBox).Text = "";
            }
            foreach (var item in gridInfoMamifero.Children)
            {
                if (item is TextBox) (item as TextBox).Text = "";
            }
            txtRapina.Text = "";
            dtNascimento.Text = DateTime.Now.ToString();
            cbCoresPeloPele.Items.Clear();
            btnVoltar0.Visibility = Visibility.Collapsed;

            foreach (Button item in gridRepteis.Children)
                item.IsEnabled = true;

            foreach (Button item in gridAves.Children)
                item.IsEnabled = true;

            foreach (Button item in gridMamiferos.Children)
                item.IsEnabled = true;



        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            boxInfoGerais.Visibility = boxInfoMamifero.Visibility = dockMamiferos.Visibility = Visibility.Collapsed;
            dockAves.Visibility = dockInfoAve.Visibility = Visibility.Collapsed;
            dockInfoReptil.Visibility = dockRepteis.Visibility = Visibility.Collapsed;


        }



        private void rdMamifero_Checked(object sender, RoutedEventArgs e)
        {
            if (rdMamifero.IsChecked == true)
            {
                mamiferos.Begin();
                LimpaCampos();
                foreach (Button item in gridMamiferos.Children)
                {
                    item.IsEnabled = true;
                }
                this.Window_Loaded(this, e);
                boxInfoGerais.Visibility = boxInfoMamifero.Visibility = dockMamiferos.Visibility = Visibility.Visible;

            }

        }



        private void rdReptil_Checked(object sender, RoutedEventArgs e)
        {
            if (rdReptil.IsChecked == true)
            {
                repteis.Begin();
                LimpaCampos();
                foreach (Button item in gridRepteis.Children)
                {
                    item.IsEnabled = true;
                }
                this.Window_Loaded(this, e);
                boxInfoGerais.Visibility = dockInfoReptil.Visibility = dockRepteis.Visibility = Visibility.Visible;
                dockRepteis.Margin = dockMamiferos.Margin;
                dockInfoReptil.Margin = dockInfoMamifero.Margin;
            }
        }

        private void rdAve_Checked(object sender, RoutedEventArgs e)
        {
            if (rdAve.IsChecked == true)
            {
                aves.Begin();
                LimpaCampos();
                foreach (Button item in gridAves.Children)
                {
                    item.IsEnabled = true;
                }
                this.Window_Loaded(this, e);
                boxInfoGerais.Visibility = dockAves.Visibility = dockInfoAve.Visibility = Visibility.Visible;
                dockInfoAve.Margin = dockInfoMamifero.Margin;
                dockAves.Margin = dockMamiferos.Margin;

            }
        }

        private void btnCoala_Click(object sender, RoutedEventArgs e)
        {
            cbCoresPeloPele.Items.Clear();
            cbCoresPeloPele.Items.Add("Cinza"); cbCoresPeloPele.Items.Add("Branco");
            PreencheAtributosMamisfero(new Coala());
            btnCoala.IsEnabled = false;
        }

        private void btnCanguru_Click(object sender, RoutedEventArgs e)
        {
            cbCoresPeloPele.Items.Clear();
            cbCoresPeloPele.Items.Add("Pardo-avermelhada");
            PreencheAtributosMamisfero(new CanguruVermelho());
            btnCanguru.IsEnabled = false;
        }

        private void btnMorcego_Click(object sender, RoutedEventArgs e)
        {
            cbCoresPeloPele.Items.Clear();
            cbCoresPeloPele.Items.Add("Preto");
            PreencheAtributosMamisfero(new MorcegoGigante());
            btnMorcego.IsEnabled = false;
        }

        private void btnOrnitorrinco_Click(object sender, RoutedEventArgs e)
        {
            cbCoresPeloPele.Items.Clear();
            cbCoresPeloPele.Items.Add("Âmbar"); cbCoresPeloPele.Items.Add("Marrom Escuro");
            PreencheAtributosMamisfero(new Ornintorrinco());
            btnOrnitorrinco.IsEnabled = false;
        }

        private void btnDingo_Click(object sender, RoutedEventArgs e)
        {
            cbCoresPeloPele.Items.Clear();
            cbCoresPeloPele.Items.Add("Amarelado"); cbCoresPeloPele.Items.Add("Branco");
            PreencheAtributosMamisfero(new Dingo());
            btnDingo.IsEnabled = false;
        }

        private void btnTasmania_Click(object sender, RoutedEventArgs e)
        {
            cbCoresPeloPele.Items.Clear();
            cbCoresPeloPele.Items.Add("Preto");
            PreencheAtributosMamisfero(new DemonioDaTasmania());
            btnTasmania.IsEnabled = false;
        }

        private void btnElefante_Click(object sender, RoutedEventArgs e)
        {
            cbCoresPeloPele.Items.Clear();
            cbCoresPeloPele.Items.Add("Amarelo Claro"); cbCoresPeloPele.Items.Add("Amarelo Escuro");
            PreencheAtributosMamisfero(new ElefanteMarinho());
            btnElefante.IsEnabled = false;
        }


        private void btnCisne_Click(object sender, RoutedEventArgs e)
        {
            PreencheAtributosAve(new CisneNegro());
            btnCisne.IsEnabled = false;
        }

        private void btnKiwi_Click(object sender, RoutedEventArgs e)
        {
            PreencheAtributosAve(new Kiwi());
            btnKiwi.IsEnabled = false;
        }

        private void btnAquila_Click(object sender, RoutedEventArgs e)
        {
            PreencheAtributosAve(new AquilaAudax());
            btnAquila.IsEnabled = false;
        }

        private void btnTaipan_Click(object sender, RoutedEventArgs e)
        {
            PreencheAtributosReptil(new Taipan());
            btnTaipan.IsEnabled = false;
        }

        private void btnCrocodilo_Click(object sender, RoutedEventArgs e)
        {
            PreencheAtributosReptil(new Crocodilo());
            btnCrocodilo.IsEnabled = false;
        }

        private void btnSapo_Click(object sender, RoutedEventArgs e)
        {
            PreencheAtributosReptil(new Sapo());
            btnSapo.IsEnabled = false;
        }

        private void btnCadastraMamifero_Click(object sender, RoutedEventArgs e)
        {
            DateTime data;
            try
            {
                data = Convert.ToDateTime(dtNascimento.Text);
            }
            catch
            {
                MessageBox.Show("Formato incorreto para data");
                return;
            }
            try
            {
                Mamifero animal = null;
                if (!btnCoala.IsEnabled)
                    animal = new Coala(txtNome.Text, data, cbSexo.SelectedItem.ToString(), cbCoresPeloPele.SelectedItem.ToString());
                else if (!btnCanguru.IsEnabled)
                    animal = new CanguruVermelho(txtNome.Text, data, cbSexo.SelectedItem.ToString(), cbCoresPeloPele.SelectedItem.ToString());
                else if (!btnMorcego.IsEnabled)
                    animal = new MorcegoGigante(txtNome.Text, data, cbSexo.SelectedItem.ToString(), cbCoresPeloPele.SelectedItem.ToString());
                else if (!btnOrnitorrinco.IsEnabled)
                    animal = new Ornintorrinco(txtNome.Text, data, cbSexo.SelectedItem.ToString(), cbCoresPeloPele.SelectedItem.ToString());
                else if (!btnDingo.IsEnabled)
                    animal = new Dingo(txtNome.Text, data, cbSexo.SelectedItem.ToString(), cbCoresPeloPele.SelectedItem.ToString());
                else if (!btnTasmania.IsEnabled)
                    animal = new DemonioDaTasmania(txtNome.Text, data, cbSexo.SelectedItem.ToString(), cbCoresPeloPele.SelectedItem.ToString());
                else if (!btnElefante.IsEnabled)
                    animal = new ElefanteMarinho(txtNome.Text, data, cbSexo.SelectedItem.ToString(), cbCoresPeloPele.SelectedItem.ToString());
               
                else
                {
                    MessageBox.Show("Selecione uma espécie para cadastrar");
                    return;
                }
                
                arvore.Insere(animal);
                File.AppendAllText("Animais.txt", $"{animal.Especie}|{animal.Nome}|{animal.Nascimento}|{animal.Sexo}|{animal.CorPeleo}\n");

                MessageBox.Show("Cadastro efetuado com sucesso!");
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }


        }

        private void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void btnVoltar0_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnVoltar1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnVoltar2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnVoltar3_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void txtNome_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Oem102) e.Handled = true;
        }

        private void txtNome_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void btnCadastraAve_Click(object sender, RoutedEventArgs e)
        {

            DateTime data;
            try
            {
                data = Convert.ToDateTime(dtNascimento.Text);
            }
            catch
            {
                MessageBox.Show("Formato incorreto para data");
                return;
            }
            try
            {
                Ave animal = null;
                if (!btnCisne.IsEnabled)
                   animal = new CisneNegro(txtNome.Text, data, cbSexo.SelectedItem.ToString(), (CoresAve)cbColoracaoAve.SelectedItem);
                else if (!btnKiwi.IsEnabled)
                    animal = new Kiwi(txtNome.Text, data, cbSexo.SelectedItem.ToString(), (CoresAve)cbColoracaoAve.SelectedItem);
                else if (!btnAquila.IsEnabled)
                    animal = new AquilaAudax(txtNome.Text, data, cbSexo.SelectedItem.ToString(), (CoresAve)cbColoracaoAve.SelectedItem);
                else
                {
                    MessageBox.Show("Selecione uma espécie para cadastrar");
                    return;
                }
                arvore.Insere(animal);
                File.AppendAllText("Animais.txt", $"{animal.Especie}|{animal.Nome}|{animal.Nascimento}|{animal.Sexo}|{animal.Coloracao}\n");


                MessageBox.Show("Cadastro efetuado com sucesso!");
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnCadastraReptil_Click(object sender, RoutedEventArgs e)
        {
            DateTime data;
            try
            {
                data = Convert.ToDateTime(dtNascimento.Text);
            }
            catch
            {
                MessageBox.Show("Formato incorreto para data");
                return;
            }
            try
            {
                Reptil animal = null;
                if (!btnTaipan.IsEnabled)
                    animal = new Taipan(txtNome.Text, data, cbSexo.SelectedItem.ToString(), (TipoDePele)cbPeleReptil.SelectedItem);
                else if (!btnCrocodilo.IsEnabled)
                    animal = new Crocodilo(txtNome.Text, data, cbSexo.SelectedItem.ToString(), (TipoDePele)cbPeleReptil.SelectedItem);
                else if (!btnSapo.IsEnabled)
                    animal = new Sapo(txtNome.Text, data, cbSexo.SelectedItem.ToString(), (TipoDePele)cbPeleReptil.SelectedItem);
                else
                {
                    MessageBox.Show("Selecione uma espécie para cadastrar");
                    return;
                }
                arvore.Insere(animal);
                File.AppendAllText("Animais.txt", $"{animal.Especie}|{animal.Nome}|{animal.Nascimento}|{animal.Sexo}|{animal.Pele}\n");

                MessageBox.Show("Cadastro efetuado com sucesso!");
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}
