using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Santuarivm
{
    /// <summary>
    /// Interaction logic for Tela_Pesquisa.xaml
    /// </summary>
    public partial class Tela_Pesquisa : Window
    {
        internal Animal animal;
        internal ArvoreBin arvore;

        public Tela_Pesquisa()
        {
            InitializeComponent();          

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedIndex != -1)
            {
                try
                {
                    animal = arvore.RetornaValor(comboBox.SelectedItem.ToString());
                    MessageBox.Show("Pesquisa realizada com sucesso");
                    if (MessageBox.Show("Deseja voltar a tela de consulta?", "Pesquisa Concluída", MessageBoxButton.YesNoCancel) == MessageBoxResult.Yes)
                        Close();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }

        }
      

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            foreach (Animal item in arvore)
            {
                comboBox.Items.Add(item.Nome);

            }
            if(comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }
    }
}
