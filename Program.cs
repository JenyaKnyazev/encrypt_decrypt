using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static string encrypt(string text,int key) {
            string[]lines={"QWERTYUIOP123", "ASDFGHJKL0456 ", "ZXCVBNM/+-789" };
            int []move={key/10000,key/100%100,key%100};
            string res="";
            text = text.ToUpper();
            for (int i = 0; i < text.Length; i++) {
                if (text[i] >= 'A' && text[i] <= 'Z' || text[i] == ' ' || text[i] == '+' || text[i] == '-' || text[i]=='/'||text[i] >= '0' && text[i] <= '9')
                {
                    int line = 0;
                    while (lines[line].IndexOf(text[i]) == -1)
                        line++;
                    int r=lines[line].IndexOf(text[i]);
                    for (int mov = move[line]; mov > 0; mov--) {
                        r++;
                        if (r == lines[line].Length)
                            r = 0;
                    }
                    res += lines[line][r];
                }
                else {
                    res += text[i];
                }
            }
            return res;
        }
        static string decrypt(string text,int key){
            string[] lines = { "QWERTYUIOP123", "ASDFGHJKL0456 ", "ZXCVBNM/+-789" };
            int[] move = { key / 10000, key / 100 % 100, key % 100 };
            string res = "";
            text = text.ToUpper();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] >= 'A' && text[i] <= 'Z' || text[i] == ' ' || text[i] == '+' || text[i] == '-' || text[i] == '/' || text[i] >= '0' && text[i] <= '9')
                {
                    int line = 0;
                    while (lines[line].IndexOf(text[i]) == -1)
                        line++;
                    int r = lines[line].IndexOf(text[i]);
                    for (int mov = move[line]; mov > 0; mov--)
                    {
                        r--;
                        if (r <0)
                            r = lines[line].Length-1;
                    }
                    res += lines[line][r];
                }
                else
                {
                    res += text[i];
                }
            }
            return res;
        }
        static void Main(string[] args)
        {
            int key;
            string text;
            int choose;
            do{
                Console.WriteLine("Encrypte enter 1\nDecrypte enter 2\nexit enter 3");
                choose=int.Parse(Console.ReadLine());
                while (choose > 3 || choose < 1)
                {
                    Console.WriteLine("Wrong input try again");
                    choose = int.Parse(Console.ReadLine());
                }
                switch (choose) { 
                    case 1:
                        Console.WriteLine("Enter key between 10101-121212");
                        key = int.Parse(Console.ReadLine());
                        while (key > 121212 || key < 10101) {
                            Console.WriteLine("Invalid key please try again");
                            key = int.Parse(Console.ReadLine());
                        }
                        Console.WriteLine("Enter text to encrypt");
                        text = Console.ReadLine();
                        Console.WriteLine("Encrypted = " + encrypt(text, key));
                        break;
                    case 2:
                        Console.WriteLine("Enter key between 10101-121212");
                        key = int.Parse(Console.ReadLine());
                        while (key > 121212 || key < 10101) {
                            Console.WriteLine("Invalid key please try again");
                            key = int.Parse(Console.ReadLine());
                        }
                        Console.WriteLine("Enter text to decrypt");
                        text = Console.ReadLine();
                        Console.WriteLine("Encrypted = " + decrypt(text, key));
                        break;
                }
            } while (choose!=3);

        }
    }
}
