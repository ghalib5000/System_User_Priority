using System;

namespace t5est
{
    class Program
    {

       static bool[] b = { false, true, false, true };
        static void Main(string[] args)
        {
            int[] a = {2,1,8,3 };
            sort(a);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i]+" ");
            }
            Console.WriteLine("");

            sortnew(a);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine("");

        }

        public static void sort(int[] a)
        {
            int[] number = a;
            bool flag = true;
            int temp;
            int numLength = number.Length;
            for (int i = 1; (i <= (numLength - 1)) && flag; i++)
            {
                flag = false;
                for (int j = 0; j < (numLength - 1); j++)
                {
                    if (number[j + 1] > number[j])
                    {
                        temp = number[j];
                        number[j] = number[j + 1];
                        number[j + 1] = temp;
                        flag = true;
                    }
                }
            }
        }
        public static void sortnew(int[] a)
        {
            int[] number = a;
            int temp;
            int numLength = number.Length;
            int[] sys = new int[4];
            int[] user = new int[4];
            int i = 0;
            for (int j = 0; j < (numLength ); j++)
            {
                // if (number[j + 1] < number[j])
                if (!b[j])
                {
                    temp = number[j];
                    number[j] = number[j + 1];
                    number[j + 1] = temp;
                    //j = 0;
                     sys[i] = number[j];
                    i++;
                }
                else
                {
                    user[i+1] = number[j];
                }
            }

            Console.WriteLine("system");
            for (int k = 0; k < sys.Length; k++)
            {
                Console.Write(sys[k] + " ");
            }
            Console.WriteLine(""); 
            Console.WriteLine("user");
            for (int k = 0; k < user.Length; k++)
            {
                Console.Write(user[k] + " ");
            }
            Console.WriteLine("");
        }
       
    }
}
