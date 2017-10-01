using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Santuarivm
{

    abstract class Animal
    {
        private string nome;
        private DateTime nascimento;
        private string sexo;

        public string Data { get { return Nascimento.ToShortDateString(); } }
        public abstract string Especie { get; }
        public abstract ImageSource Imagem { get; }


        public Animal()
        {

        }


        public Animal(string nome, DateTime nascimento, string sexo)
        {
            Nome = nome;
            Nascimento = nascimento;
            Sexo = sexo;
        }

        public String Nome
        {
            get { return nome; }
            private set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                    throw new Exception("Nome inválido");
                nome = value.Trim();
            }
        }



        public DateTime Nascimento
        {
            get { return nascimento; }
            private set
            {
                if (value.Date >= DateTime.Now.Date)
                    throw new Exception("A data de nascimento deve ser inferior a atual");
                nascimento = value;
            }
        }
        public string Sexo
        {
            get { return sexo; }
            private set
            {
                sexo = value;
            }
        }

         

        public abstract bool Venenoso { get; }

        public abstract TipoDeAlimentacao Alimentacao { get; }

        public virtual int CalcularIdade()
        {
            double dias = DateTime.Now.Subtract(Nascimento).TotalDays;
            return (int)dias / 30;
        }

        public abstract void Movimentar(Key tecla, Animacoes movimentos);

        public void Comer(Animacoes movimentos)
        {
            movimentos.Comer.Begin();
        }

        public abstract string Comunicar();


        public override string ToString()
        {
            string venenoso = Venenoso ? "Sim" : "Não";
            return $"Nome: {Nome} \nIdade: {CalcularIdade()} meses \nSexo: {Sexo}" +
                $"\nVenenoso: {venenoso} \nAlimentação: {Alimentacao} \n\n";

        }
    }
}
