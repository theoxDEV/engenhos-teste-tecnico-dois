using System;
using System.Windows.Forms;

namespace engenhos_teste_tecnico_dois
{
    public partial class Form1 : Form
    {
        public const int CONST_ONE_SECOND_TO_MILLISECONDS = 1000;


        Lanterna EngenhosLanterna = new Lanterna() 
        { 
            Carga = 100, 
            Status = "Desligada" 
        };


        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Decremento da carga em 1
            EngenhosLanterna.Carga -= 1;

            // Caso a carga da bateria chegue a 0% desativa o timer
            if (EngenhosLanterna.Carga <= 0)
            {
                timer1.Enabled = false;
                timer1.Stop();

                MessageBox.Show("Bateria com 0% de carga, recarregue imediatamamente !");

                stopBtn.Visible = false;
                startBtn.Visible = true;
                statusLabel.Text = "Desligada";

                Carga.Text = "0%";
                progressBar1.Value = 0;
            }
            else
            {
                progressBar1.Value = EngenhosLanterna.Carga;
                Carga.Text = EngenhosLanterna.Carga.ToString() + "%";
            }
        }

        private void changeBatteryBtn_Click_1(object sender, EventArgs e)
        {
            // Verificação se o timer está ativado
            // Caso esteja ativo, não permitir a troca de bateria
            if (timer1.Enabled)
            {
                MessageBox.Show("Impossível trocar a bateria com a lanterna ligada !");
            }
            else
            {
                EngenhosLanterna.TrocarDeBateria();
                progressBar1.Value = EngenhosLanterna.Carga;
                Carga.Text = $"{EngenhosLanterna.Carga}%";
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            // A propriedade é definida por milisegundos
            // por conta disso foi setado a constante como 1000 milisegundos (1 segundo)
            timer1.Interval = CONST_ONE_SECOND_TO_MILLISECONDS;
            statusLabel.Text = "Ligada";
            startBtn.Visible = false;
            stopBtn.Visible = true;
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            statusLabel.Text = "Desligada";
            stopBtn.Visible = false;
            startBtn.Visible = true;
        }
    }
}
