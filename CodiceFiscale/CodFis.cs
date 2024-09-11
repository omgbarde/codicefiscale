using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodiceFiscale
{
    class CodFis
    {
        int i;

        public string Cognome(string cognomeCompleto) //ricava le 3 lettere del cognome secondo i criteri
        {
            //I cognomi che risultano composti da più parti o comunque separati od interrotti, vengono considerati
            //come se fossero scritti secondo un'unica ed ininterrotta successione di caratteri. Per i soggetti di sesso
            //femminile coniugati si prende in considerazione soltanto il cognome da nubile. Se il cognome contiene
            //tre o più consonanti, i tre caratteri da rilevare sono, nell'ordine, la prima, la seconda e la terza
            //consonante. Se il cognome contiente due consonanti, i tre caratteri da rilevare sono, nell'ordine, la
            //prima e la seconda consonante e la prima vocale. Se il cognome contiene una consonante e due
            //vocali, si rilevano, nell'ordine, quella consonante e quindi la prima e la seconda vocale. Se il cognome
            //contiene una consonante e una vocale, si rilevano la consonante e la vocale, nell'ordine, e si assume
            //come terzo carattere la lettera x (ics). Se il cognome è costituito da due sole vocali, esse si rilevano,
            //nell'ordine, e si assume come terzo carattere la lettera x (ics).

            string codificaC = "", vocali = "", consonanti = "", cognome = cognomeCompleto.ToUpper();
            char lettera;   //variabile tempornea per confrontare una lettera alla volta
            int nconsonanti = 0, nvocali = 0, l = cognomeCompleto.Length; 

            for (i = 0; i < l; i++)
            {
                lettera = cognome[i];

                if (lettera == 'A' || lettera == 'E' || lettera == 'I' || lettera == 'O' || lettera == 'U')
                {

                    vocali += lettera;
                    nvocali++;

                }
                else
                {

                    consonanti += lettera;
                    nconsonanti++;

                }
            }

            if (nconsonanti < 3)
            {

                if (nconsonanti == 2 && nvocali >= 1)
                {

                    codificaC += consonanti[0];
                    codificaC += consonanti[1];
                    codificaC += vocali[0];

                }

                if (nconsonanti == 1 && nvocali >= 2)
                {

                    codificaC += consonanti[0];
                    codificaC += vocali[0];
                    codificaC += vocali[1];

                }

                if (nconsonanti == 1 && nvocali == 1)
                {

                    codificaC += consonanti[0];
                    codificaC += vocali[0];
                    codificaC += 'X';

                }

                if (nconsonanti < 1 && nvocali < 1)
                {
                    MessageBox.Show("errore nella codifica del cognome");
                }
            }

            else
            {

                codificaC += consonanti[0];
                codificaC += consonanti[1];
                codificaC += consonanti[2];

            }

            return codificaC;
        }

        public string Nome(string nomeCompleto) //ricava le 3 lettere del nome secondo i criteri
        {
            //I nomi doppi, multipli o comunque composti, vengono considerati come scritti per esteso in ogni loro
            //parte e secondo un'unica ed ininterrotta successione di caratteri. Se il nome contiene quattro o più
            //consonanti, i tre caratteri da rilevare sono, nell'ordine, la prima, la terza e la quarta consonante. Se il
            //nome contiene tre consonanti, i tre caratteri da rilevare sono, nell'ordine, la prima, la seconda e la terza
            //consonante. Se il nome contiene due consonanti, i tre caratteri da rilevare sono, nell'ordine, la prima e
            //la seconda consonante e la prima vocale. Se il nome contiene una consonante e due vocali, i tre
            //caratteri da rilevare sono, nell'ordine quella consonante e quindi la prima e la seconda vocale. Se il
            //nome contiene una consonante e una vocale, si rilevano la consonante e la vocale, nell'ordine, e si
            //assume come terzo carattere la lettera x (ics). Se il nome è costituito da due sole vocali, esse si
            //rilevano nell'ordine, e si assume come terzo carattere la lettera x (ics).

            string codificaN = "", vocali = "", consonanti = "", nome = nomeCompleto.ToUpper();
            char lettera;   //variabile tempornea per confrontare una lettera alla volta
            int nconsonanti = 0, nvocali = 0, l = nomeCompleto.Length; ;

            for (i = 0; i < l; i++)
            {
                lettera = nome[i];

                if (lettera == 'A' || lettera == 'E' || lettera == 'I' || lettera == 'O' || lettera == 'U')
                {

                    vocali += lettera;
                    nvocali++;

                }
                else
                {

                    consonanti += lettera;
                    nconsonanti++;

                }
            }

            if (nconsonanti < 4)
            {

                if (nconsonanti == 3)
                {

                    codificaN += consonanti[0];
                    codificaN += consonanti[1];
                    codificaN += consonanti[2];

                }

                if (nconsonanti == 2 && nvocali >= 1)
                {

                    codificaN += consonanti[0];
                    codificaN += consonanti[1];
                    codificaN += vocali[0];

                }

                if (nconsonanti == 1 && nvocali >= 2)
                {
                    codificaN += consonanti[0];
                    codificaN += vocali[0];
                    codificaN += vocali[1];

                }

                if (nconsonanti == 1 && nvocali == 1)
                {

                    codificaN += consonanti[0];
                    codificaN += vocali[0];
                    codificaN += 'X';

                }

                if (nconsonanti < 1 && nvocali < 1)
                {

                    MessageBox.Show("errore nella codifica del nome");

                }
            }

            else
            {

                codificaN += consonanti[0];
                codificaN += consonanti[2];
                codificaN += consonanti[3];

            }

            return codificaN;
        }

       public string CifreAnno(string anno) //isola le ultime due cifre dell' anno di nascita
        {
            //I due caratteri numerici indicativi dell'anno di nascita sono, nell'ordine, la cifra delle decine e la cifra
            //delle unità dell'anno stesso.

            string cifre = "";
            cifre = anno.Substring(2, 2);

            return cifre;
        }

        public string CarattereMese(int mese) //ottiene il carattere corrispondente al mese
        {
            //Il carattere alfabetico corrispondente al mese di nascita è quello stabilito
            //per ciascun mese nella seguente tabella:

            string carattere = "";

            if (mese == 1) carattere = "A";
            if (mese == 2) carattere = "B";
            if (mese == 3) carattere = "C";
            if (mese == 4) carattere = "D";
            if (mese == 5) carattere = "E";
            if (mese == 6) carattere = "H";
            if (mese == 7) carattere = "L";
            if (mese == 8) carattere = "M";
            if (mese == 9) carattere = "P";
            if (mese == 10) carattere = "R";
            if (mese == 11) carattere = "S";
            if (mese == 12) carattere = "T";

            return carattere;
        }

        public string CifreGiorno (int giorno, string sesso) //isola il numero del giorno di nascita
        {
            //I due caratteri numerici indicativi del giorno di nascita e del sesso vengono determinati nel modo
            //seguente: per i soggetti maschili il giorno di nascita figura invariato, con i numeri da uno a trentuno,
            //facendo precedere dalla cifra zero i giorni del mese dall'uno al nove. Per i soggetti femminili il giorno di
            //nascita viene aumentato di quaranta unità, per cui esso figura con i numeri da quarantuno a settantuno.

            string gg = "0";

            if (sesso == "MASCHIO")
            {

                if (giorno < 10)
                {

                    gg += giorno.ToString();

                }
                else gg = giorno.ToString();

            }

            else if (sesso == "FEMMINA")
            {
                giorno += 40;
                gg = giorno.ToString();

            }

            return gg;
        }

        public string CarattereControllo (string cf) //ricava il carattere di controllo secondo i criteri
        {
            //Il sedicesimo carattere ha funzione di controllo della esatta trascrizione dei primi quindici caratteri. Esso
            //viene determinato nel modo seguente: ciascuno degli anzidetti quindici caratteri, a seconda che occupi
            //posizione di ordine pari o posizioni di ordine dispari, viene convertito in un valore numerico in base alle
            //corrispondenze indicate rispettivamente ai successivi punti 1) e 2).

            string carattere = "";
            int sommaPari = 0, sommaDispari = 0, somma = 0;

            for (i = 0; i < 15; i++) //scorro il codice fiscale
            {
                if ((i + 1) % 2 == 0)
                {
                    //1) Per la conversione dei sette caratteri con posizione di ordine pari:

                    if (cf[i] == 'A' || cf[i] == '0') sommaPari += 0;
                    if (cf[i] == 'O') sommaPari += 14;
                    if (cf[i] == 'B' || cf[i] == '1') sommaPari += 1;
                    if (cf[i] == 'P') sommaPari += 15;
                    if (cf[i] == 'C' || cf[i] == '2') sommaPari += 2;
                    if (cf[i] == 'Q') sommaPari += 16;
                    if (cf[i] == 'D' || cf[i] == '3') sommaPari += 3;
                    if (cf[i] == 'R') sommaPari += 17;
                    if (cf[i] == 'E' || cf[i] == '4') sommaPari += 4;
                    if (cf[i] == 'S') sommaPari += 18;
                    if (cf[i] == 'F' || cf[i] == '5') sommaPari += 5;
                    if (cf[i] == 'T') sommaPari += 19;
                    if (cf[i] == 'G' || cf[i] == '6') sommaPari += 6;
                    if (cf[i] == 'U') sommaPari += 20;
                    if (cf[i] == 'H' || cf[i] == '7') sommaPari += 7;
                    if (cf[i] == 'V') sommaPari += 21;
                    if (cf[i] == 'I' || cf[i] == '8') sommaPari += 8;
                    if (cf[i] == 'W') sommaPari += 22;
                    if (cf[i] == 'J' || cf[i] == '9') sommaPari += 9;
                    if (cf[i] == 'X') sommaPari += 23;
                    if (cf[i] == 'K') sommaPari += 10;
                    if (cf[i] == 'Y') sommaPari += 24;
                    if (cf[i] == 'L') sommaPari += 11;
                    if (cf[i] == 'Z') sommaPari += 25;
                    if (cf[i] == 'M') sommaPari += 12;
                    if (cf[i] == 'N') sommaPari += 13;
                }

                else
                {
                    //2) Per la conversione degli otto caratteri con posizione di ordine dispari:

                    if (cf[i] == 'A' || cf[i] == '0') sommaDispari += 1;
                    if (cf[i] == 'O') sommaDispari += 11;
                    if (cf[i] == 'B' || cf[i] == '1') sommaDispari += 0;
                    if (cf[i] == 'P') sommaDispari += 3;
                    if (cf[i] == 'C' || cf[i] == '2') sommaDispari += 5;
                    if (cf[i] == 'Q') sommaDispari += 6;
                    if (cf[i] == 'D' || cf[i] == '3') sommaDispari += 7;
                    if (cf[i] == 'R') sommaDispari += 8;
                    if (cf[i] == 'E' || cf[i] == '4') sommaDispari += 9;
                    if (cf[i] == 'S') sommaDispari += 12;
                    if (cf[i] == 'F' || cf[i] == '5') sommaDispari += 13;
                    if (cf[i] == 'T') sommaDispari += 14;
                    if (cf[i] == 'G' || cf[i] == '6') sommaDispari += 15;
                    if (cf[i] == 'U') sommaDispari += 16;
                    if (cf[i] == 'H' || cf[i] == '7') sommaDispari += 17;
                    if (cf[i] == 'V') sommaDispari += 10;
                    if (cf[i] == 'I' || cf[i] == '8') sommaDispari += 19;
                    if (cf[i] == 'W') sommaDispari += 22;
                    if (cf[i] == 'J' || cf[i] == '9') sommaDispari += 21;
                    if (cf[i] == 'X') sommaDispari += 25;
                    if (cf[i] == 'K') sommaDispari += 2;
                    if (cf[i] == 'Y') sommaDispari += 24;
                    if (cf[i] == 'L') sommaDispari += 4;
                    if (cf[i] == 'Z') sommaDispari += 23;
                    if (cf[i] == 'M') sommaDispari += 18;
                    if (cf[i] == 'N') sommaDispari += 20;
                }
            }

            somma = sommaPari + sommaDispari;

            //La somma si divide per il numero 26. Il carattere di controllo si ottiene convertendo il resto
            //di tale divisione nel carattere alfabetico ad esso corrispondente nella tabella sottoindicata:
            int resto = somma % 26;

            if (resto == 0) carattere = "A";
            if (resto == 14) carattere = "O";
            if (resto == 1) carattere = "B";
            if (resto == 15) carattere = "P";
            if (resto == 2) carattere = "C";
            if (resto == 16) carattere = "Q";
            if (resto == 3) carattere = "D";
            if (resto == 17) carattere = "R";
            if (resto == 4) carattere = "E";
            if (resto == 18) carattere = "S";
            if (resto == 5) carattere = "F";
            if (resto == 19) carattere = "T";
            if (resto == 6) carattere = "G";
            if (resto == 20) carattere = "U";
            if (resto == 7) carattere = "H";
            if (resto == 21) carattere = "V";
            if (resto == 8) carattere = "I";
            if (resto == 22) carattere = "W";
            if (resto == 9) carattere = "J";
            if (resto == 23) carattere = "X";
            if (resto == 10) carattere = "K";
            if (resto == 24) carattere = "Y";
            if (resto == 11) carattere = "L";
            if (resto == 25) carattere = "Z";
            if (resto == 12) carattere = "M";
            if (resto == 13) carattere = "N";

            return carattere;

        }
    }
}
