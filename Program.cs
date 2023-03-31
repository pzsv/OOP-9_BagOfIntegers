using System;
using System.Collections.Generic;

namespace OOP9_BagOfIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiate bag
            BagK bag = new BagK();

            //declare user input variables
            int inOption;
            int inElement = 0;

            //exit program when user inputs 7 (exit), till then loop and manipulate bag
            while ((inOption = menu()) != 7)
            {
                //we need to know the integer to manipulate in case of meu options 1, 2 and 3
                if (inOption <= 3)
                    inElement = readElement(inOption);


                switch (inOption)
                {
                    case 1:
                        bag.Add(inElement);
                        displayMessage("A new instance of the integer " + inElement + " has been added to the bag.");
                        //displayMessage("What now?");
                        break;

                    case 2:
                        int newFreq = bag.Remove(inElement);

                        if(newFreq != -1) 
                            displayMessage("One instance of the integer " + inElement + " has been removed from the bag. There is " + newFreq + " of it left.");
                        else
                            displayMessage("There is no " + inElement + " in the bag to remove.");
                        break;

                    case 3:
                        displayMessage("Frequency of the integer " + inElement + " in the bag is: " + bag.GetFrequency(inElement));
                        break;

                    case 6:
                        /*SortedDictionary<int, int> d = bag.GetElements();
                        string printBagMsg = "Current contents of the bag are: " + "\r\n";

                        foreach (var pair in (bag.GetElements()))
                        {
                            printBagMsg += pair.Key + " (occurs " + pair.Value + " times) \r\n";
                        }
                        printBagMsg += "\r\n" + "End of bag";
                        displayMessage(printBagMsg);*/
                        break;

                    case 7:
                        displayMessage("Bye!");
                        break;

                }
            }

        }

        //display menu of options to manipulate the bag
        static public int menu()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("*********************************************************");
            Console.WriteLine();
            Console.WriteLine("         Bag of Ingtegers - by Faruq Hussaini");
            Console.WriteLine();
            Console.WriteLine("*********************************************************");
            Console.WriteLine();
            Console.WriteLine("1. Insert an element into the bag");
            Console.WriteLine("2. Remove an element from the bag");
            Console.WriteLine("3. Display frequency of an element");
            Console.WriteLine("4. Display elements occurring only once");
            Console.WriteLine("5. Display the number of elements occurring only once");
            Console.WriteLine("6. Print bag");
            Console.WriteLine("7. Exit");
            Console.WriteLine();

            Console.Write("Please, select option: ");

            var result = Console.ReadLine();

            return Convert.ToInt32(result);
        }

        static public int readElement(int intFeature)
        { 

            string strFeature = "";

            switch (intFeature)
            {
                case 1:
                    strFeature = "insert";
                    break;
                case 2:
                    strFeature = "remove";
                    break;
                case 3:
                    strFeature = "display frequency of";
                    break;

            }

            //Console.Clear();

            /*Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("*********************************************************");
            Console.WriteLine();
            Console.WriteLine("         Bag of Ingtegers - by Faruq Hussaini");
            Console.WriteLine();
            Console.WriteLine("*********************************************************");*/
            Console.WriteLine();
            Console.Write("Please, specify integer to " + strFeature + ": ");

            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }

        static public void displayMessage(string message)
        {

            /*Console.Clear();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("*********************************************************");
            Console.WriteLine();
            Console.WriteLine("         Bag of Ingtegers - by Faruq Hussaini");
            Console.WriteLine();
            Console.WriteLine("*********************************************************");*/
            Console.WriteLine();
            Console.Write(message + " (Please press Enter)");

            Console.ReadLine();
        }

    }


    class BagK : List<KeyValuePair<int, int>>
    {

        //private SortedDictionary<int, int> elements = new SortedDictionary<int, int>();


        public new bool ContainsKey(int key) {

            bool ret = false;

            foreach (var pair in this)
            {
                if (pair.Key == key)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        public KeyValuePair<int, int> Get(int key)
        {
            KeyValuePair<int, int> ret = new KeyValuePair<int, int>(-1,-1);

            foreach (var pair in this)
            {
                if (pair.Key == key)
                {
                    ret = pair;
                    //return pair;
                    break;
                }
            }
            return ret;
        }

        //override List<>.Add() 
        //AND
        //increase frequency in pair for <key> by 1
        //so that we take care of the base struct and of the requirement, too
        public new int Add(int key)
        {
            int ret = -1;

            if (this.ContainsKey(key))
            {
                // KeyValuePair k = base.Find()
                int freq = this.Get(key).Value;
                freq++;
                base.Remove(this.Get(key));
                base.Add(new KeyValuePair<int, int>(key, freq));
            }
            else
            {
                base.Add(new KeyValuePair<int, int>(key, 1));
            }
        }

        //opposite of Add() overriden
        public new int Remove(int key)
        {
            int ret = -1;

            if (this.ContainsKey(key) && this.Get(key).Value == 1)
            {
                base.Remove(this.Get(key));
                ret = 0;
            }
            else if (this.ContainsKey(key) && this.Get(key).Value > 1)
            {
                int freq = this.Get(key).Value;
                freq--;
                base.Remove(this.Get(key));
                base.Add(new KeyValuePair<int, int>(key, freq));

                ret = freq;
            }
            return ret;
        }

        //get frequency of <key> in elements<key, frequency>
        //i.e. this would be the number of the integer (key) in a set that consists of
        //a simple list of integers wthout knowing the frequency in its pairs
        public int GetFrequency(int key)
        {
            int ret = -1;

            if (this.ContainsKey(key))
            {
                ret = this.Get(key).Value;
            }
            else
            {
                ret = 0;
            }
            return ret;
        }

        /*
        public SortedDictionary<int, int> GetElements()
        {
            return elements;
        }
        */
    }

}



































/*class Bag : List<int> {

        private SortedDictionary<int, int> elements = new SortedDictionary<int, int>();


        //override List<>.Add() 
        //AND
        //increase frequency in pair for <key> by 1
        //so that we take care of the base struct and of the requirement, too
        public new void Add(int key) 
        {

            if (elements.ContainsKey(key))  
            {
                    base.Add(key);
                    elements[key] = elements[key] + 1;
            }
            else
            {
                    base.Add(key);
                    elements.Add(key, 1);
            }
        }
 
        //opposite of Add() overriden
        public new void Remove(int key)
        {
            if (elements.ContainsKey(key))
            {
                base.Remove(key);

                if (elements[key] != 1)
                {
                        elements[key] = elements[key] - 1;
                }
                else
                {
                        elements.Remove(key);
                }
            }
        }

        //get frequency of <key> in elements<key, frequency>
        //i.e. this would be the number of the integer (key) in a set that consists of
        //a simple list of integers wthout knowing the frequency in its pairs
        public int GetFrequency(int key)
        {
            int ret = -1;

            if (!elements.ContainsKey(key))
                ret = 0;
            else
            {
                ret = elements[key];
            }

            return ret;
        }

        public SortedDictionary<int, int> GetElements()
        {
            return elements;
        }

    }*/
