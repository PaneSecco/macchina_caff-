using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace macchina_caffè
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //controllo input
            Console.WriteLine("definire di quanto si vuole la capienza del serbatoio d'acqua");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("definire di quanto si vuole la capienza del serbatoio del caffè");
            int c = int.Parse(Console.ReadLine());
            Macchinetta macchinetta = new Macchinetta(a, c);
            Console.WriteLine("limite acqua: "+macchinetta.Limite_acqua);
            Console.WriteLine("limite caffè: " + macchinetta.Limite_caffe);


            Console.WriteLine();

            //controllo riempimento serbatoi
            Console.WriteLine("livello water: " + macchinetta.Stato_acqua());
            Console.WriteLine("livello coffe: " + macchinetta.Stato_caffe());

            Console.WriteLine("riempimento serbatoi...");
            macchinetta.Ricarica_acqua();
            macchinetta.Ricarica_caffe();

            Console.WriteLine("livello water: " + macchinetta.Stato_acqua());
            Console.WriteLine("livello coffe: " + macchinetta.Stato_caffe());


            Console.WriteLine();

            //controllo erogazione caffe e erogati contati
            Console.WriteLine("erogazione normale (range: acqua=50-60, caffè=5-7)");
            macchinetta.Erogazione_normale();
            Console.WriteLine("livello water: " + macchinetta.Stato_acqua());
            Console.WriteLine("livello coffe: " + macchinetta.Stato_caffe());

            Console.WriteLine("erogazione lunga (range: acqua=15-20, caffè=3-5)");
            macchinetta.Erogazione_lungo();
            Console.WriteLine("livello water: " + macchinetta.Stato_acqua());
            Console.WriteLine("livello coffe: " + macchinetta.Stato_caffe());

            Console.WriteLine("caffè erogati: "+ macchinetta.Erogati);


            Console.WriteLine();

            //controllo calcolo possibili erogazioni massime di normale
            Console.WriteLine("numero di erogazione massimo di caffè normali (tenendo conto del range massimo) è di: " + macchinetta.Calcolo_massimo_normali());

            Console.WriteLine();
            //controllo del confronto erogati tra due oggetti
            Macchinetta macchinetta2 = new Macchinetta(a, c);
            Macchinetta risultato=macchinetta.Confronto(macchinetta, macchinetta2);
            if (risultato == macchinetta)
            {
                Console.WriteLine("la macchinetta con maggior erogazioni è la prima");
            }
            else
            {
                Console.WriteLine("la macchinetta con maggior erogazioni è la seconda");
            }
        }
    }
}
