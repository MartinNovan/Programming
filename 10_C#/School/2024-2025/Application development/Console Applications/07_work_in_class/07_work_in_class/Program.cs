namespace _07_work_in_class
{
    internal static class Program
    {
        // File handling and command-line arguments processing
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                return; // Exit if no command-line arguments are provided
            }

            // Reading from a file
            StreamReader streamReader = new StreamReader("text.txt"); // Reads the file located in bin/Debug/net...
            string text = streamReader.ReadToEnd(); // Read the entire document and store it
            Console.WriteLine(text);
            streamReader.Close(); // Close the document
            streamReader.Dispose(); // Dispose of the stream reader

            // Alternative method to read from the same file
            using (StreamReader streamReader2 = new StreamReader("text.txt"))
            {
                string text2 = streamReader2.ReadToEnd();
                Console.WriteLine(text2);
            }

            // Creating a document using command-line arguments
            using (StreamWriter writer = new StreamWriter(args[0])) // Create a document using command line (program.exe output.txt)
            {
                writer.WriteLine("Hello!"); // Write to the document
                writer.WriteLine("Hello again?");
            }

            // Caesar cipher implementation
            using (StreamReader csReader = new StreamReader(args[1])) // Read from the input file for the Caesar cipher
            {
                using (StreamWriter csWriter = new StreamWriter(args[2])) // Write to the output file for the Caesar cipher
                {
                    Coder coder = new Coder(csReader.ReadToEnd(), int.Parse(args[3])); // Create a Coder instance
                    csWriter.Write(coder.Encode()); // Encode the text and write it to the output file
                }
            }
        }

        class Coder // Caesar cipher class
            (string text, int key)
        {
            public string Encode()
            {
                char[] chars = new char[text.Length];
                for (int i = 0; i < chars.Length; i++)
                {
                    chars[i] = (char)(text[i] + key); // Shift each character by the key
                }
                return new string(chars); // Return the encoded string
            }
        }
    }
}
