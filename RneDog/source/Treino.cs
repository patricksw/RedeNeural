using AForge.Neuro;
using AForge.Neuro.Learning;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RneDog
{
    public class Rna
    {
        //referencia http://www.codeproject.com/Articles/16447/Neural-Networks-on-C

        const int TotalNeuronios = 9;
        const int Variaveis = 4;
        const double ValorAlpha = 2.0;
        const double CamadaRate = 0.1;

        private DataTable funcaoneuronio;

        public DataTable FuncaoNeuronio
        {
            get { return funcaoneuronio; }
            set { funcaoneuronio = value; }
        }

        private void CriaColunaFuncao()
        {
            this.FuncaoNeuronio = new DataTable();

            this.FuncaoNeuronio.Columns.Add("Neuronio");
            this.FuncaoNeuronio.Columns.Add("Limite");
            this.FuncaoNeuronio.Columns.Add("Valor");
        }

        public void Treinar(double[][] dados)
        {
            double[][] output = new double[dados.Length][];
            double[][] input = new double[dados.Length][];

            for (int i = 0; i < dados.Length; i++)
            {
                input[i] = new double[Variaveis];
                output[i] = new double[TotalNeuronios];

                for (int j = 0; j < Variaveis; j++)
                    input[i][j] = dados[i][j];

                int classe = Convert.ToInt32(dados[i][4]) - 1;

                output[i][classe] = 1;
            }

            ActivationNetwork network = new ActivationNetwork(new SigmoidFunction(ValorAlpha), Variaveis, TotalNeuronios);

            ActivationLayer layer = network[0];

            PerceptronLearning teacher = new PerceptronLearning(network);

            teacher.LearningRate = CamadaRate;

            int interacao = 1000;
            int count = 0;

            List<double> errolist = new List<double>();

            while (count <= interacao)
            {
                double erro = teacher.RunEpoch(input, output) / dados.Length;
                errolist.Add(erro);
                count++;
            }

            CriaColunaFuncao();

            for (int i = 0; i < TotalNeuronios; i++)
            {
                this.FuncaoNeuronio.Rows.Add("Neuronio [" + (i + 1)+ "]", Convert.ToInt32(layer[i].Threshold), layer[i][0]);
            }
        }

        private double[][] FuncaoToDouble()
        {
            List<double[]> output = new List<double[]>();
            foreach (DataRow dr in this.FuncaoNeuronio.Rows)
            {
                double[] temp = new double[2];
                temp[0] = Convert.ToDouble(dr[1]);
                temp[1] = Convert.ToDouble(dr[2]);

                temp[0] = Math.Abs(temp[0]);
                temp[1] = Math.Abs(temp[1]);

                output.Add(temp);
            }
            return output.ToArray();
        }

        private double valorAproximado(double[] list, ref int index)
        {
            double result = 0;

            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] < 1)
                {
                    if (list[i] > result)
                    {
                        result = list[i];
                        index = i; 
                    }
                }
            }
            return result;
        }

        public string[] Resultado(double[] fator)
        {
            string temp = string.Empty;

            string[] result = new string[3];
            double[][] funcaoDouble = FuncaoToDouble();

            List<double> valor = new List<double>();

            for (int i = 0; i < funcaoDouble.Length; i++)
            {
                double sum = 0;
                for (int j = 0; j < fator.Length; j++)
                {
                    double fat = fator[j];
                    double fun = funcaoDouble[i][1];

                    double d = fat * fun;
                    temp += d.ToString() + "|";
                    sum += d;
                }
                double par = funcaoDouble[i][0];
                double divParamentro = (sum / par);
                double divFuncao = (funcaoDouble[i][1] / par);

                double media = (divParamentro + divFuncao) / 2;

                temp += sum.ToString() + "|";
                temp += par.ToString() + "|";
                temp += funcaoDouble[i][1].ToString();
                temp += "\r\n";

                valor.Add(par / media);
            }

            int index = 0;
            double maxValue = valorAproximado(valor.ToArray(), ref index);

            index++;

            result[0] = ((Cachorro.Raca)index).ToString();
            result[1] = maxValue.ToString();
            result[2] = temp;
            return result;
        }
    }
}