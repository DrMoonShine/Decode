using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Vigenere
{
    public class VigenereText
    {
        public List<string> AllText { get; set; } = new List<string>();
        private static char[] alph = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

        public static VigenereText OpenFile(string p)
        {
            string path = p;
            VigenereText vt = new VigenereText();
            if (string.IsNullOrEmpty(path) == false)
            {
                using (var streamReader = File.OpenText(path))
                {
                    var s = string.Empty;
                    while ((s = streamReader.ReadLine()) != null)
                    {
                        vt.AllText.Add(s);
                    }
                        
                }
            }
            return vt;
        }
        public static VigenereText DecodeOrEncode(string key,VigenereText text,bool codeOrdecode)
        {
            
            VigenereText decodedText = new VigenereText();
            int indexKey = 0;
            int c = default(int); //Индекс символа закодированного сообщения
            int k = default(int); //Индекс символа ключа
            int charIndex = default(int);
            foreach (var item in text.AllText) //перебоh строк
            {
                string s = "";//Расшифрованная строка

                foreach (var symbol in item)//перебор символов в строке
                {
                    if (symbol >= 'а' && symbol <= 'я' || symbol == 'ё')//если символ буква
                    {
                        for (int i = 0; i < alph.Length; i++)//поиск нужного индекса
                        {
                            if(alph[i] == symbol)
                            {
                                c = i;
                            }
                        }
                        for (int i = 0; i < alph.Length; i++)//поиск нужного индекса
                        {
                            if(alph[i] == key[indexKey])
                            {
                                k = i;
                            }
                        }
                        if (!codeOrdecode)//Если false - расшифровываем
                        {
                            charIndex = (c + alph.Length - k) % alph.Length; //Формула для расшифровки видженера(найдена в интернете =) ):  Исходный символ = (с + мощьность алфавита - k) % мощьность алфавита
                        }
                        else
                        {
                            charIndex = (c + k) % alph.Length;
                        }
                        s += alph[charIndex];
                        indexKey++;
                        if (indexKey == key.Length)
                        {
                            indexKey = 0;
                        }
                    }
                    else
                    {
                        s += symbol;
                    }
                }
                decodedText.AllText.Add(s);
            }
            return decodedText;
        }
    
        public static void SaveText(VigenereText text,string path)
        {
            using(FileStream file = new FileStream(path, FileMode.Create))
            {
                using(StreamWriter stream = new StreamWriter(file))
                {
                    foreach (var item in text.AllText)
                    {
                        stream.WriteLine(item);
                    }
                }
            }
        }
    }
}
