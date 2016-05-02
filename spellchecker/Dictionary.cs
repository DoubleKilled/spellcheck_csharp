﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace spellchecker
{
    public class Dictionary
    {
        private string path = "";
        private List<string> dictionary = new List<string>();

        public bool DictionaryLoaded
        {
            get
            {
                return (path == "") ? false : true;
            }
        }

        public void OpenDictionary()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open dictionary file";
            ofd.Filter = "Text File|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                GetDictionary(path);
            }
        }

        private void GetDictionary(string somePath)
        {
            using (StreamReader reader2 = new StreamReader(File.OpenRead(path)))
            {
                while (!reader2.EndOfStream)
                    dictionary.Add(reader2.ReadLine());
            }
        }

        public bool Parse(string someString)
        {
            return (dictionary.Contains(someString)) ? true : false;
        }
    }
}
