using System.IO; //toto potřebujeme
namespace Prace_v_hodine_2
{
    internal class Program
    {
        //práce se soubory
        //práce s argumenty zadanými při spuštění aplikace
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }
            StreamReader streamReader = new StreamReader("text.txt"); //načítá to soubor ve složce bin/Debug/net.... !Soubor se musí vytvořit jinak to hodí chybu!
            string text = streamReader.ReadToEnd(); //přečtení dokumentu a uložení
            streamReader.Close();   //uzavření dokumentu
            streamReader.Dispose(); //

            using (StreamReader streamReader2 = new StreamReader("text.txt")) //to samé akorát jiná metoda
            {
                string text2 = streamReader2.ReadToEnd();
            }

            using (StreamWriter writer = new StreamWriter(args[0])) //vytvoření dokumentu pomocí cmd po sestavení (program.exe zapis.txt) 
                                                                    //also ve ->vlastnostech projektu->ladit->obecné->argumenty příkazového řádku nastavujeme spuštění tohoto programu ve visual studiu
                                                                    //jelikož by po spuštění program nic neudělal bez tohoto argumentu
                                                                    //dá se pak najít v ./propeties/launchsettings.json/ pod názvem "commandLineArgs": "text3.txt" 
            {
                writer.WriteLine("Ahoj!"); //zapsání do dokumentu
                writer.WriteLine("Ahoj2?");
            }

            using (StreamReader cs_reader = new StreamReader(args[1])) //cs -> ceasarova šifra
            {
                using (StreamWriter cs_writer = new StreamWriter(args[2]))
                {
                    Coder coder = new Coder(cs_reader.ReadToEnd(), int.Parse(args[3]));
                    cs_writer.Write(coder.Encode());
                }
            }
        }

        class Coder     //ceasarova šifra
        {
            private string text;
            private int key;

            public Coder(string text, int key)
            {
                this.text = text;
                this.key = key;
            }

            public string Encode()
            {
                char[] chars = new char[text.Length];
                for (int i = 0; i < chars.Length; i++)
                {
                    chars[i] = (char)(text[i] + key);
                }
                return new string(chars);
            }
        }
    }
}
