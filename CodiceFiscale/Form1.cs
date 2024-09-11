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

//Lorenzo Bardelli 3°I
//calcolo del codice fiscale

namespace CodiceFiscale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        string[] province = new string[9000];   //array in cui inserisco le province (sigle)
        string[] codici = new string[9000];     //array dei codici ISTAT dei comuni
        string sesso = "";                      
        int i, n;

        private void Form1_Load(object sender, EventArgs e)
        {
            PopolaComboBox();
        }

        private void PopolaComboBox() //carico il file dei comuni
        {
            string lista = Properties.Resources.listacomuni;
            string riga, comune;
            string[] elementi;
            i = 0;            
            
            using ( StringReader lettore = new StringReader(lista) )
            {
                while ( (riga = lettore.ReadLine() ) != null )
                {
                    elementi = riga.Split (';');
                    comune = elementi[1];           //i vari elementi del file vanno negli appositi array
                    comboBox1.Items.Add(comune);
                    province [i] = elementi[2]; 
                    codici [i] = elementi [6];  
                    i++;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) 
        {

            n = comboBox1.SelectedIndex; //salvo l' indice del comune selezionato
            textBox3.Text = province[n];
        }

        private void button1_Click(object sender, EventArgs e) //quando clicco button1 inizio l' algoritmo
        {
            CodFis Codifica = new CodFis();

            string codiceFiscale = "";  //stringa per salvare mano a mano il codice fiscale
            bool esegui = true;         //variabile booleana che è true se tutti i campi sono riempiti

            if (string.Compare(textBox1.Text, "") == 0) //controllo l' inserimento del cognome
            {
                MessageBox.Show("inserisci cognome");
                esegui = false;
            }

            if (string.Compare(textBox2.Text, "") == 0) //controllo l' inserimento del nome
            {
                MessageBox.Show("inserisci nome");
                esegui = false;
            }

            if (comboBox1.SelectedItem == null || string.Compare(comboBox1.SelectedItem.ToString(), "Comune") == 0) //controllo l' inserimento del comune dalla comboBox
            {
                MessageBox.Show("scegli un comune dall' elenco");
                esegui = false;
            }

            if(radioButton1.Checked == false && radioButton2.Checked == false) //controllo l' inserimento del sesso
            {
                MessageBox.Show("seleziona il sesso");
                esegui = false;
            }

            if (esegui == true) //se l' utente ha inserito tutto codifico le varie parti
            {
         
                string cognomeCodificato = Codifica.Cognome(textBox1.Text);
                codiceFiscale += cognomeCodificato;

                string nomeCodificato = Codifica.Nome(textBox2.Text);
                codiceFiscale += nomeCodificato;

                string annoCodificato = Codifica.CifreAnno(dateTimePicker1.Value.Year.ToString());
                codiceFiscale += annoCodificato;

                string carattereMese = Codifica.CarattereMese(dateTimePicker1.Value.Month);
                codiceFiscale += carattereMese;

                ControllaSesso();

                string giornoCodificato = Codifica.CifreGiorno(dateTimePicker1.Value.Day, sesso);
                codiceFiscale += giornoCodificato;

                string codiceIstat = codici[n];
                codiceFiscale += codiceIstat;

                string controllo = Codifica.CarattereControllo(codiceFiscale);
                codiceFiscale += controllo;

                textBox4.Text = codiceFiscale;

            }
        }

        private void ControllaSesso() //in base al bottone selezionato ricava il sesso
        {

            if (radioButton1.Checked == true)
            {
                sesso = "MASCHIO";
            }
            else if (radioButton2.Checked == true)
            {
                sesso = "FEMMINA";
            }
        }
    }
}