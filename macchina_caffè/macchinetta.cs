using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace macchina_caffè
{
    internal class Macchinetta
    {
        //numero di serie
        private string numero;
        //serbatoio dell'acqua in ml
        private int serbatoio_acqua;
        //serbatio del caffè in g
        private int serbatoio_caffe;
        //contatore dei caffè erogati
        private int erogati;
        //limite massimo serbatoio acqua in ml
        private int limite_acqua;
        //limite massimo serbatoio caffè in g
        private int limite_caffe;

        public Macchinetta(int maxa, int maxc)
        {
            var chars = "abcdefghijklmnopqrstuvwxyz";
            var chars2 = "01234567989";
            var stringChars = new char[7];
            var random = new Random();

            for (int i = 0; i < 3; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            for (int i = 0; i < 4; i++)
            {
                stringChars[i] = chars2[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            Numero = finalString;
            Limite_acqua = maxa;
            Limite_caffe = maxc;
            SerbatoioAcqua = 0;
            SerbatoioCaffe = 0;
            this.erogati = 0;
        }

        public Macchinetta()
        {

        }

        public string Numero
        {
            get { return numero; }

            set { numero = value;}
        }

        public int SerbatoioAcqua
        {
            get { return serbatoio_acqua; }

            set { serbatoio_acqua = limite_acqua; }
        }

        public int SerbatoioCaffe
        {
            get { return serbatoio_caffe; }

            set { serbatoio_caffe = limite_caffe; }
        }

        public int Erogati
        {
            get { return erogati; }

            set { erogati+=value; }
        }

        public int Limite_acqua
        {
            get { return limite_acqua; }
            set 
            { 
                if (value <= 0)
                {
                    throw new ArgumentException("il valore inserito deve essere maggiore di 0");
                }
                else
                {
                    limite_acqua = value;
                } 
            }
        }

        public int Limite_caffe
        {
            get { return limite_caffe; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("il valore inserito deve essere maggiore di 0");
                }
                else
                {
                    limite_caffe = value;
                }
            }
        }

        public int stato_acqua()
        {
            return SerbatoioAcqua;
        }

        public int stato_caffe()
        {
            return SerbatoioCaffe;
        }

        public void erogazione_normale()
        {
            Random random = new Random();
            int acqua = random.Next(50, 60);
            int caffe = random.Next(5, 7);

            if (SerbatoioAcqua >= acqua && SerbatoioCaffe >= caffe)
            {
                SerbatoioAcqua -= acqua;
                SerbatoioCaffe -= caffe;
            }
            else
            {
                throw new Exception("I materiali nei serbatoi non sono sufficienti, si prega di riempirli");
            }

            Erogati=1;
        }

        public void erogazione_lungo()
        {
            Random random = new Random();
            int acqua = random.Next(15, 20);
            int caffe = random.Next(3, 5);

            if (SerbatoioAcqua >= acqua && SerbatoioCaffe >= caffe)
            {
                SerbatoioAcqua -= acqua;
                SerbatoioCaffe -= caffe;
            }
            else
            {
                throw new Exception("I materiali nei serbatoi non sono sufficienti, si prega di riempirli");
            }

            Erogati = 1;
        }

        public void ricarica_acqua()
        {
            SerbatoioAcqua = limite_acqua;
        }

        public void ricarica_caffe()
        {
            SerbatoioCaffe = limite_caffe;
        }

        public int calcolo_massimo_normali()
        {
            int i = SerbatoioAcqua;
            int r = SerbatoioCaffe;
            int volte = 0;

            for(int j = 0; i >= 60 && r >= 7; j ++)
            {
                i -= 60;
                r -= 7;
                volte++;
            }
            return volte;
        }

        public Macchinetta confronto(Macchinetta a, Macchinetta b)
        {
            if (a == null || b == null)
            {
                throw new Exception("uno degli oggetti ricevuti è vuoto");
            }
            else
            {
                if (a.Erogati > b.Erogati)
                {
                    return a;
                }
                else
                {
                    return b;
                }
            }
        }

        //metodi di base

        public bool Equals(Macchinetta a2)
        {
            return true;
        }

        public override string ToString()
        {
            return String.Format("Macchinetta ({0}, {1})", numero, serbatoio_acqua, serbatoio_caffe, Erogati, limite_acqua, limite_caffe);
        }

        //mettere secondo costruttore ecc
        //controllare se mettere i this 
        //gestire le eccezioni
        //fare il main
    }
}
