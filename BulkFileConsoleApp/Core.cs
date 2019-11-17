using System.IO;
using System.Linq;

namespace BulkFileConsoleApp
{
    public static class Core
    {
        public static string PrimaryChallangeMethod(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new System.ArgumentException("Input can not be null or empty", nameof(input));
            }

            // split input string with space
            string[] inputs = input.Split(separator: ' ');
            string word = "acme";
            string[] outputs = new string[inputs.Length];

            for (int i = 0; i < inputs.Length; i++)
            {
                if (inputs[i].Equals(word, System.StringComparison.CurrentCultureIgnoreCase))
                {
                    inputs[i] = "TimCo";
                }
                else
                {
                    inputs[i] = ChangeFirstLetterCapitalized(inputs[i]);
                }

                outputs[i] = inputs[i];
            }

            return string.Join(" ", outputs);
        }

        public static FileModel BonusChallangeMethod(FileModel fileModel)
        {
            using (MemoryStream memoryStream = new MemoryStream(fileModel.Data))
            {
                var streamReader = new StreamReader(memoryStream);
                string line = streamReader.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    fileModel.NewFilenameWithoutExtension = line;
                }
            }

            return fileModel;
        }

        public static string ChangeFirstLetterCapitalized(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new System.ArgumentException("Input can not be null or empty", nameof(input));
            }

            if (input.Length > 1)
            {
                return input.First().ToString().ToUpper() + input.Substring(1).ToLower();
            }
            else
            {
                return input.First().ToString().ToUpper();
            }
        }
    }
}