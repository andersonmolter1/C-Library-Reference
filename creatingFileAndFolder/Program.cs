using System;
namespace Example2
{
    public class CreateFileOrFolder
    {
        static void Main()
        {
            //will create 20 text files for example. 
            for (int i = 0; i < 20; i++)
            {
                //assigning string to string value of top folder. will test for existence later. 
                string folderName = @"c:\Top-Level Folder";

                //will assign string value to value to go inside of topfolder. can be done by referencing top folder. 
                string pathString = System.IO.Path.Combine(folderName, "SubFolder");

                //putting subfolder under top folder. 
                string pathString2 = @"c:\Top-Level Folder\SubFolder2";

                //one more instance under subfolder. 
                pathString = System.IO.Path.Combine(pathString, "SubSubFolder");


                System.IO.Directory.CreateDirectory(pathString);

                // Creates a file based on time stamp of when ran to avoid writing overfiles. 
                //var myUniqueFileName = $@"{Guid.NewGuid()}.txt";
                //another example of random file name. 
                var fileName = $@"{DateTime.Now.Ticks}.txt";

                //combines random file name and total pathString
                pathString = System.IO.Path.Combine(pathString, fileName);

                //writes path to console for visual
                Console.WriteLine("Path to my file: {0}\n", pathString);

                //test if that path string exist. 
                if (!System.IO.File.Exists(pathString))
                {
                    //if doesnt exist it will create it. 
                    //if a random name generator is used it will never exist before test. 
                    using (System.IO.FileStream fs = System.IO.File.Create(pathString))
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            Console.Write("test string ");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File \"{0}\" already exists.", fileName);
                    return;
                }
            }

        }
    }
}