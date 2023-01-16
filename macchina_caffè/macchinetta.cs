using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace macchina_caffè
{
    public class Macchinetta
    {
        //numero di serie
        private static string numero;
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
            var stringChars = new char[3];
            var stringChars2 = new char[4];
            var random = new Random();

            for (int i = 0; i < 3; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            for (int i = 0; i < 4; i++)
            {
                stringChars2[i] = chars2[random.Next(chars2.Length)];
            }

            var finalString = new String(stringChars);
            var finalString2 = new String(stringChars2);

            var final = finalString + finalString2;

            Numero = final;
            Limite_acqua = maxa;
            Limite_caffe = maxc;
            SerbatoioAcqua = 0;
            SerbatoioCaffe = 0;
            this.erogati = 0;
        }

        public Macchinetta()
        {
            Numero = "abc1234";
            Limite_acqua = 2000;
            Limite_caffe = 500;
            SerbatoioAcqua = 0;
            SerbatoioCaffe = 0;
            this.erogati = 0;
        }

        public string Numero
        {
            get { return numero; }

            private set { numero = value;}
        }

        public int SerbatoioAcqua
        {
            get { return serbatoio_acqua; }

            private set { serbatoio_acqua = value; }
        }

        public int SerbatoioCaffe
        {
            get { return serbatoio_caffe; }

            private set { serbatoio_caffe = value; }
        }

        public int Erogati
        {
            get { return erogati; }

            set { erogati+=value; }
        }

        public int Limite_acqua
        {
            get { return limite_acqua; }
            private set 
            { 
                if (value <= 0)
                {
                    throw new Exception("il valore inserito deve essere maggiore di 0");
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
            private set 
            {
                if (value <= 0)
                {
                    throw new Exception("il valore inserito deve essere maggiore di 0");
                }
                else
                {
                    limite_caffe = value;
                }
            }
        }

        public int Stato_acqua()
        {
            return SerbatoioAcqua;
        }

        public int Stato_caffe()
        {
            return SerbatoioCaffe;
        }

        public void Erogazione_normale()
        {
            Random random = new Random();
            int acqua = random.Next(50, 61);
            int caffe = random.Next(5, 8);

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

        public void Erogazione_lungo()
        {
            Random random = new Random();
            int acqua = random.Next(15, 21);
            int caffe = random.Next(3, 6);

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

        public void Ricarica_acqua()
        {
            SerbatoioAcqua = limite_acqua;
        }

        public void Ricarica_caffe()
        {
            SerbatoioCaffe = limite_caffe;
        }

        public int Calcolo_massimo_normali()
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

        public Macchinetta Confronto(Macchinetta a, Macchinetta b)
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

        public bool Equals(Macchinetta p)
        {
            if (p == null) return false;

            if (this == p) return true;

            return (this.Numero == p.Numero);
        }

        public override string ToString()
        {
            return String.Format("Macchinetta", numero, serbatoio_acqua, serbatoio_caffe, Erogati, limite_acqua, limite_caffe);
        }

        public Macchinetta Clone()
        {
            Macchinetta b = new Macchinetta();
            this.Numero = Numero;
            this.SerbatoioAcqua = SerbatoioAcqua;
            this.SerbatoioCaffe = SerbatoioCaffe;
            this.Erogati = Erogati;
            this.Limite_acqua = Limite_acqua;
            this.Limite_caffe = Limite_caffe;
            return b;
        }
    }
}
