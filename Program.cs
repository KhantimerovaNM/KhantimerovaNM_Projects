using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CVS_parsing_1
{
    class MainClass
    {
        public static List<string> linesOfText = new List<string>();

        public static void Main(string[] args)
        {
            string fileLocation = "";
            bool checkReadingFile=false;

            Console.WriteLine("Write the file address, please! \n For example: " +
            	"/home/user/folder/file.csv or C:/folder/file.csv");
          
            while (checkReadingFile == false) 
            {
                fileLocation = Console.ReadLine();
                checkReadingFile = ReadingFile(fileLocation);

                if (checkReadingFile == true)
                    break;
                else
                    Console.WriteLine("File not found. Please, try again...");
            }


             foreach (string nextline in linesOfText)
             {

                List<string> newLine = LineParsing(nextline);
                foreach (string row in newLine)
                    {
                        Console.Write(row+" | ");
                    }
                Console.WriteLine();
            }
           

        }

        public static bool ReadingFile(string fileLocation)
        {
            try
            {
                StreamReader read = new StreamReader(fileLocation);
                string line;
                while ((line=read.ReadLine())!=null)
                {
                    linesOfText.Add(line);
                }
                return true;
            }
            catch (System.IO.IOException)
            {
                return false; 
            }
        }

        public static List<string> LineParsing(string toParseLine)
        {
            List<string> newLine = new List<string>();
            char splitChar = ',';
            char unSplitChar = '"';
            bool stopSplitingOne = false;
            bool stopSplitingTwo = false;
         
            string row="";


            for (int i=0; i< toParseLine.Length; i++)
            {
                if ((toParseLine[i] == unSplitChar)&&(stopSplitingOne == false))
                {
                    stopSplitingOne = true;
                    stopSplitingTwo = false;
                    continue;
                }

                if ((toParseLine[i] == unSplitChar)&&(stopSplitingOne == true))
                {
                    stopSplitingOne = false;
                    stopSplitingTwo = true;
                    continue;

                }

                if (((toParseLine[i]!=splitChar)&&(stopSplitingTwo != true))||(stopSplitingOne==true))
                {
                    row = row + toParseLine[i];
                }
                else if ((toParseLine[i] == splitChar)&&(stopSplitingOne == false))
                {
                    newLine.Add(row);
                    row = "";
                    stopSplitingOne = false;
                    stopSplitingTwo = false;
                    continue;
                }

                //to find last row
                if ((i+2)==toParseLine.Length)
                {
                    newLine.Add(row);
                }

            }

            return newLine;
        }
    }
}
