using System;
using KASD_9;
string fileReader = @"input.txt";
var arr = new MyArrayList<string>();
using (StreamReader sr = File.OpenText(fileReader))
{
    string line;
    while((line=sr.ReadLine())!=null)
    {
        string teg = "";
        bool f = false;
        for(int i=0;i<line.Length;i++)
        {
            if (line[i]=='<')
            {
                f = true;
            }
            if (f) teg += line[i];
            if (line[i]=='>')
            {
                f = false;
                arr.Add(teg);
                teg = "";
            }
        }
    }
}
Console.WriteLine("Массив тегов до удаления:");
arr.Print();
arr.RemoveSibling();
Console.WriteLine("Массив тегов после удаления:");  
arr.Print();


