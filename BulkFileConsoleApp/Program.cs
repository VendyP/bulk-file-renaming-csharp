using System;

namespace BulkFileConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string assetPrimaryPath = "..\\Assets\\Primary";
            string assetBonusPath = "..\\Assets\\Bonus";
            string outputPrimaryChallangePath = "..\\Outputs\\Primary";
            string outputBonusChallangePath = "..\\Outputs\\Bonus";

            // primary challange section
            var primaryFiles = FileReader.GetFiles(assetPrimaryPath);

            Console.WriteLine("Total count primary files " + primaryFiles.Count);

            foreach (var primaryFile in primaryFiles)
            {
                primaryFile.NewFilenameWithoutExtension = Core.PrimaryChallangeMethod(primaryFile.FilenameWithoutExtension);
                Console.WriteLine(primaryFile.NewFilename);
            }

            FileWriter.Write(outputPath: outputPrimaryChallangePath, files: primaryFiles);

            Console.WriteLine("==========");

            // bonus challange section
            var bonusFiles = FileReader.GetFiles(assetBonusPath);

            Console.WriteLine("Total count bonus files " + bonusFiles.Count);

            for (int i = 0; i < bonusFiles.Count; i++)
            {
                bonusFiles[i] = Core.BonusChallangeMethod(fileModel: bonusFiles[i]);
                Console.WriteLine(bonusFiles[i].NewFilename);
            }

            FileWriter.Write(outputPath: outputBonusChallangePath, files: bonusFiles);
        }
    }
}
