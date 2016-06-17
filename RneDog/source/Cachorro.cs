using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RneDog
{
    public class Cachorro
    {
        private int expectativavida;
        private int altura;
        private int peso;
        private int inteligencia;

        public int ExpectativaVida
        {
            get { return expectativavida; }
            set { expectativavida = value; }
        }
        public int Altura
        {
            get { return altura; }
            set { altura = value; }
        }
        public int Peso
        {
            get { return peso; }
            set { peso = value; }
        }
        public int Inteligencia
        {
            get { return inteligencia; }
            set { inteligencia = value; }
        }

        const int maxExpectativaVida = 15;
        const int maxAltura= 74;
        const int maxPeso = 38;
        const int maxInteligencia = 5;

        public Cachorro(int expectativa, int altura, int peso, int inteligencia)
        {
            this.ExpectativaVida = expectativa;
            this.Altura = altura;
            this.Peso = peso;
            this.Inteligencia = inteligencia;
        }

        public double[] Fator()
        {
            double[] result = new double[4];

            result[0] = (double)this.ExpectativaVida / (double)maxExpectativaVida;
            result[1] = (double)this.Altura / (double)maxAltura;
            result[2] = (double)this.Peso / (double)maxPeso;
            result[3] = (double)this.Inteligencia / (double)maxInteligencia;

            return result;
        }

        public enum Raca
        {
            Desconhecido,
            Pintcher = 1,
            Beagle = 2,
            York_Shire = 3,
            Bull_Terrier = 4,
            Chow_Chow = 5,
            Greyhound = 6,
            Dalmata = 7,
            Labrador = 8,
            Pastor_Alemao = 9
        }
    }
}