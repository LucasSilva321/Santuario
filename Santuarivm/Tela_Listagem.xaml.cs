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
    /// Interaction logic for Tela_Listagem.xaml
    /// </summary>
    public partial class Tela_Listagem : Window
    {
        internal Lista TodosAnimais;
        Lista AnimaisMamiferos, AnimaisOviparos, AnimaisAquaticos, AnimaisVoadores;

        void PreencheTabelaPorNome(Lista lista)
        {
            dataGrid.Items.Clear();
            lista.OrdenarPorNome();
            foreach (Animal item in lista)
            {
                dataGrid.Items.Add(item);
            }
        }

        void PreencheTabelaPorIdade(Lista lista)
        {
            dataGrid.Items.Clear();
            lista.OrdenarPorIdade();
            foreach (Animal item in lista)
            {
                dataGrid.Items.Add(item);
                
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dataGrid.SelectedIndex != -1)
            {
                image.Visibility = label.Visibility = Visibility.Visible;
                image.Source = (dataGrid.SelectedItem as Animal).Imagem;
                label.Content = (dataGrid.SelectedItem as Animal).ToString();
            }
            else
            {
                image.Visibility = label.Visibility =  Visibility.Hidden;
            }
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
           dataGrid.Items.Clear();
            foreach (RadioButton item in gridFiltro.Children)
            {
                item.IsChecked = false;
            }
            foreach (RadioButton item in gridOrdenar.Children)
            {
                item.IsChecked = false;
            }
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void rdMamiferos_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (rdAlfabetico.IsChecked == true)
            {
                if (rdTodos.IsChecked == true)
                    PreencheTabelaPorNome(TodosAnimais);
                else if (rdMamiferos.IsChecked == true)
                    PreencheTabelaPorNome(AnimaisMamiferos);
                else if (rdOviparos.IsChecked == true)
                    PreencheTabelaPorNome(AnimaisOviparos);
                else if (rdAquaticos.IsChecked == true)
                    PreencheTabelaPorNome(AnimaisAquaticos);
                else if (rdVoadores.IsChecked == true)
                    PreencheTabelaPorNome(AnimaisVoadores);
                else
                    MessageBox.Show("Preencha os campos Filtrar e Ordenar corretamente");
            }
            else if (rdIdade.IsChecked == true)
            {
                if (rdTodos.IsChecked == true)
                    PreencheTabelaPorIdade(TodosAnimais);
                else if (rdMamiferos.IsChecked == true)
                    PreencheTabelaPorIdade(AnimaisMamiferos);
                else if (rdOviparos.IsChecked == true)
                    PreencheTabelaPorIdade(AnimaisOviparos);
                else if (rdAquaticos.IsChecked == true)
                    PreencheTabelaPorIdade(AnimaisAquaticos);
                else if(rdVoadores.IsChecked == true)
                    PreencheTabelaPorIdade(AnimaisVoadores);
                else
                    MessageBox.Show("Preencha os campos Filtrar e Ordenar corretamente");
            }
            else
                MessageBox.Show("Preencha os campos Filtrar e Ordenar corretamente");
            if(dataGrid.Items.Count > 0)
            {
                dataGrid.SelectedIndex = 0;
            }
        }

        public Tela_Listagem()
        {
            InitializeComponent();
            AnimaisMamiferos = new Lista();
            AnimaisOviparos = new Lista();
            AnimaisAquaticos = new Lista();
            AnimaisVoadores = new Lista();
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Animal item in TodosAnimais)
            {
               // dataGrid.Items.Add(item);
                if (item is Mamifero)
                    AnimaisMamiferos.InserirNoFim(item);
                if (item is IOviparo)
                    AnimaisOviparos.InserirNoFim(item);
                if (item is IAquatico)
                    AnimaisAquaticos.InserirNoFim(item);
                if (item is IVoador)
                    AnimaisVoadores.InserirNoFim(item);
            }
        }
    }
}
