using System;
using System.Collections.Generic;
using Yarhl.IO;
using Yarhl.Media.Text;
using Yarhl.FileFormat;

namespace Persona2po
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Persona2PO 1.0 - A simple converter for the txt files (PersonaEditor text file) to po from the games Persona 3 and Persona 4 by Darkmet98.");
            Console.WriteLine("Thanks to Pleonex for the help and Yarhl libraries.");
            if (args.Length != 2) {
                Console.WriteLine("USAGE: [mono] persona2po.exe file -exportP3/-exportP4/import/generatenames/split");
                Console.WriteLine("Export to Po example: persona2po.exe E101_001.txt -exportP4 ");
                Console.WriteLine("Generate the dictionary for names: Persona2po.exe alltxts.txt -generatenames");
                Console.WriteLine("Import to txt from the Po: persona2po.exe E101_001.txt.po -import ");
                Console.WriteLine("Split the txt: persona2po.exe E101.txt -split ");
                Console.WriteLine("Read first the readme file before use this program!");
                Environment.Exit(-1);
            }
            switch (args[1]) {
                case "-exportP4":
                            Po po = new Po
            {
                Header = new PoHeader("Persona 4", "glowtranslations@gmail.com", "es")
                {
                    LanguageTeam = "Glowtranslations",
                }
            };
            string[] textfile = System.IO.File.ReadAllLines(args[0]);
            foreach (string line in textfile)
            {
                string[] lineFields = line.Split('\t');
                if (lineFields.Length < 4) Console.WriteLine("FAAAAAAILLL: {0}", line, args[0]); //It's that a Pleonex's reference!!!!????
                        foreach (string part in lineFields)
                {
                    PoEntry entry = new PoEntry();
                    if (lineFields.Length == 6)
                    {
                        entry.Context = $"{lineFields[0]}:{lineFields[1]}:{lineFields[2]}";
                        if (string.IsNullOrEmpty(lineFields[3]))
                        lineFields[3] = "<!empty>";
                        if (string.IsNullOrWhiteSpace(lineFields[3])) { lineFields[3] = "Pensamiento del protagonista"; }
                        lineFields[3] = lineFields[3].Replace("�", "<NCHAR>");
                        entry.ExtractedComments = lineFields[3];
                        if (string.IsNullOrWhiteSpace(lineFields[4])) { lineFields[4] = "[CUADRO DE TEXTO EN BLANCO]"; }
                        lineFields[4] = lineFields[4].Replace("{0A}", "\n");
                        lineFields[4] = lineFields[4].Replace("{F1 82}", "{PROTAGONISTA}");
                        entry.Original = lineFields[4];
                        po.Add(entry);
                    }
                    if (lineFields.Length >= 7)
                    {
                        entry.Context = $"{lineFields[0]}:{lineFields[1]}:{lineFields[2]}";
                        if (string.IsNullOrEmpty(lineFields[3]))
                        lineFields[3] = "<!empty>";
                        if (string.IsNullOrWhiteSpace(lineFields[3])) { lineFields[3] = "Pensamiento del protagonista"; }
                        lineFields[3] = lineFields[3].Replace("�", "<NCHAR>");
                        entry.ExtractedComments = lineFields[3];
                        if (string.IsNullOrWhiteSpace(lineFields[4])) { lineFields[4] = "[CUADRO DE TEXTO EN BLANCO]"; }
                        lineFields[4] = lineFields[4].Replace("{0A}", "\n");
                        lineFields[4] = lineFields[4].Replace("{F1 82}", "{PROTAGONISTA}");
                        lineFields[6] = lineFields[6].Replace("{0A}", "\n");
                        lineFields[6] = lineFields[6].Replace("{F1 82}", "{PROTAGONISTA}");
                        entry.Original = lineFields[4];
                        entry.Translated = lineFields[6];
                        po.Add(entry);
                    }
                }
            }
            po.ConvertTo<BinaryFormat>().Stream.WriteTo(args[0] + ".po");
            break;

                case "-exportP3":
                    po = new Po
                    {
                        Header = new PoHeader("Persona 3", "traduccionesdeltiovictor@noexiste.com", "es")
                        {
                            LanguageTeam = "Traducciones del Tío Victor",
                        }
                    };
                    textfile = System.IO.File.ReadAllLines(args[0]);
                    foreach (string line in textfile)
                    {
                        string[] lineFields = line.Split('\t');
                        if (lineFields.Length < 4) Console.WriteLine("FAAAAAAILLL: {0}", line, args[0]); //It's that a Pleonex's reference!!!!????
                        foreach (string part in lineFields)
                        {
                            PoEntry entry = new PoEntry();
                            if (lineFields.Length == 6)
                            {
                                entry.Context = $"{lineFields[0]}:{lineFields[1]}:{lineFields[2]}";
                                if (string.IsNullOrEmpty(lineFields[3]))
                                    lineFields[3] = "<!empty>";
                                if (string.IsNullOrWhiteSpace(lineFields[3])) { lineFields[3] = "Pensamiento del protagonista"; }
                                lineFields[3] = lineFields[3].Replace("�", "<NCHAR>");
                                entry.ExtractedComments = lineFields[3];
                                if (string.IsNullOrWhiteSpace(lineFields[4])) { lineFields[4] = "[CUADRO DE TEXTO EN BLANCO]"; }
                                lineFields[4] = lineFields[4].Replace("{0A}", "\n");
                                lineFields[4] = lineFields[4].Replace("{F1 0C}", "{Nombre y apellidos prota}");
                                lineFields[4] = lineFields[4].Replace("{F1 0B}", "{Apellido prota}");
                                lineFields[4] = lineFields[4].Replace("{F1 0A}", "{Nombre prota}");
                                entry.Original = lineFields[4];
                                po.Add(entry);
                            }
                            if (lineFields.Length >= 7)
                            {
                                entry.Context = $"{lineFields[0]}:{lineFields[1]}:{lineFields[2]}";
                                if (string.IsNullOrEmpty(lineFields[3]))
                                    lineFields[3] = "<!empty>";
                                if (string.IsNullOrWhiteSpace(lineFields[3])) { lineFields[3] = "Pensamiento del protagonista"; }
                                lineFields[3] = lineFields[3].Replace("�", "<NCHAR>");
                                entry.ExtractedComments = lineFields[3];
                                if (string.IsNullOrWhiteSpace(lineFields[4])) { lineFields[4] = "[CUADRO DE TEXTO EN BLANCO]"; }
                                lineFields[4] = lineFields[4].Replace("{0A}", "\n");
                                lineFields[4] = lineFields[4].Replace("{F1 0C}", "{Nombre y apellidos prota}");
                                lineFields[4] = lineFields[4].Replace("{F1 0B}", "{Apellido prota}");
                                lineFields[4] = lineFields[4].Replace("{F1 0A}", "{Nombre prota}");
                                lineFields[6] = lineFields[6].Replace("{0A}", "\n");
                                lineFields[6] = lineFields[6].Replace("{F1 0C}", "{Nombre y apellidos prota}");
                                lineFields[6] = lineFields[6].Replace("{F1 0B}", "{Apellido prota}");
                                lineFields[6] = lineFields[6].Replace("{F1 0A}", "{Nombre prota}");
                                entry.Original = lineFields[4];
                                entry.Translated = lineFields[6];
                                po.Add(entry);
                            }
                        }
                    }
                    po.ConvertTo<BinaryFormat>().Stream.WriteTo(args[0] + ".po");
                    break;

                case "-generatenames":
            po = new Po
            {
                Header = new PoHeader("Persona names", "glowtranslations@gmail.com", "es")
                {
                    LanguageTeam = "Glowtranslations",
                }
            };
            string[] textnames = System.IO.File.ReadAllLines(args[0]);
            foreach (string line in textnames)
            {
                string[] lineFields = line.Split('\t');
                        if (lineFields.Length < 4) Console.WriteLine("FAAAAAAILLL: {0}", line, args[0]); //It's that a Pleonex's reference!!!!????
                        foreach (string part in lineFields)
                {
                    PoEntry entry = new PoEntry();
                        if (string.IsNullOrEmpty(lineFields[3]))
                        lineFields[3] = "<!empty>";
                        if (string.IsNullOrWhiteSpace(lineFields[3])) { lineFields[3] = "Pensamiento del protagonista"; }
                        lineFields[3] = lineFields[3].Replace("�", "<NCHAR>");
                        entry.Original = lineFields[3];
                        po.Add(entry);
                        }
                    }
                    po.ConvertTo<BinaryFormat>().Stream.WriteTo("names.po");
            break;

            case "-import":
                    DataStream input = new DataStream(args[0], FileOpenMode.Read);
                    BinaryFormat binary = new BinaryFormat(input);
                    po = binary.ConvertTo<Po>();
                    input.Dispose();
                    DataStream name = new DataStream("names.po", FileOpenMode.Read);
                    BinaryFormat binaryname = new BinaryFormat(name);
                    Po poname = binaryname.ConvertTo<Po>();
                    name.Dispose();
                    Yarhl.IO.TextWriter writer = new Yarhl.IO.TextWriter(new DataStream(args[0] + ".txt", FileOpenMode.Write));
                    foreach (var entry in po.Entries)
                        {
                        string potext = entry.Text;
                        if (potext == "<!empty>")
                        potext = string.Empty;
                        PoEntry nameEntry = poname.FindEntry(entry.ExtractedComments);
                        string names = nameEntry.Text;
                        entry.Context = entry.Context.Replace(":", "\t");
                        entry.Original = entry.Original.Replace("\n", "{0A}");
                        entry.Translated = entry.Translated.Replace("\n", "\\n");
                        entry.Translated = entry.Translated.Replace("{PROTAGONISTA}", "{F1 82}");
                        entry.Translated = entry.Translated.Replace("{Nombre y apellidos prota}", "{F1 0C}");
                        entry.Translated = entry.Translated.Replace("{Apellido prota}", "{F1 0B}");
                        entry.Translated = entry.Translated.Replace("{Nombre prota}", "{F1 0A}");
                        writer.WriteLine(entry.Context + "\t" + entry.ExtractedComments + "\t" + entry.Original + "\t" + names + "\t" + entry.Translated + "\t");
                        }
                    break;

                case "-split":
                    string[] textfilex = System.IO.File.ReadAllLines(args[0]);
                    List<string> text = new List<string>();
                    foreach (string line in textfilex)
                    {
                        string[] lineFields = line.Split('\t');
                        if (lineFields.Length < 4) Console.WriteLine("FAAAAAAILLL: {0}", line, args[0]); //It's that a Pleonex's reference!!!!????
                        if (lineFields.Length == 6)
                        {
                            text.Add(lineFields[0] + "\t" + lineFields[1] + "\t" + lineFields[2] + "\t" + lineFields[3] + "\t" + lineFields[4] + "\t");
                        }
                        if (lineFields.Length >= 7)
                        {
                            text.Add(lineFields[0] + "\t" + lineFields[1] + "\t" + lineFields[2] + "\t" + lineFields[3] + "\t" + lineFields[4] + "\t" + lineFields[5] + "\t" + lineFields[6] + "\t");
                        }
                        string result = string.Join(Environment.NewLine, text.ToArray());
                        System.IO.File.WriteAllText(@lineFields[0], result);
                    }
                    break;
            }
        }
    }
}
