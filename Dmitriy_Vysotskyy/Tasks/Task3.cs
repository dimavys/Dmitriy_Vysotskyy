using System;
namespace Dmitriy_Vysotskyy.Tasks
{
	public static class Task3
	{
        public static int GetDigitalRoot(int n)
        {
            int root = 0;
            while (n > 0 || root > 9)
            {
                if (n == 0)
                {
                    n = root;
                    root = 0;
                }

                root += n % 10;
                n /= 10;
            }
            return root;
        }
    }
}

