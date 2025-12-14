using KASD_11;
using System;
string fileReader = @"input.txt";
var vector = new MyVector<string>();
using(StreamReader sr=File.OpenText(fileReader))
{
    string line;
    while((line= sr.ReadLine()) != null)
    {
        string ip = "";
        string a = " ";//считывает числа между точек
        bool f = false;
        int tochki = 0;
        for(int j=0;j<line.Length; j++)
        {
           
            if (line[j] >= '0' && line[j] <= '9') a += line[j];
            if (line[j] == '.')
            {
                
                bool t = false;
                tochki++;
                if(a.Length != 0 && Convert.ToInt32(a)>=0 && Convert.ToInt32(a)<=255)
                {
                    t=true;
                    ip += a;
                    ip += ".";
                    a = "";
                }
                if(tochki==3)
                {
                    for (int k = j; k < j+4 && k<line.Length; k++)
                    {
                        if (line[k] >= '0' && line[k] <= '9') a += line[k];
                        if (line[k] == ' ') { break; } 
                    }
                    if (a.Length!=0 && Convert.ToInt32(a) >= 0 && Convert.ToInt32(a) <= 255)
                    {
                        t = true;
                        ip += a;
                        a = "";
                        vector.Add(ip);
                        ip = "";
                        if (j <= line.Length - 4) { j += 3; continue; }
                        break;                       
                    }
                }
            }
            if (line[j]==' ')
            {
                a = "";
                tochki = 0;
            }
        }
    } 
}
vector.Print();