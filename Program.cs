using System;



namespace NumberOfDiscIntersections
{
	class Program
	{
		static void Main(string[] args)
		{


			int[] a = { 1, 5, 2, 1, 4, 0 };



			NumberOfDiscIntersections solution = new NumberOfDiscIntersections();

			Console.WriteLine(solution.solution(a));


			//class Solution 
			//{
			//    public int solution(int[] A)
			//    {
			//        int result = 0;
			//        for (int i = 0; i < A.Length - 1; i++)
			//        {
			//            for (int j = i + 1; j < A.Length; j++)
			//            {

			//                if (result > 10000000) return -1;
			//                int k = j - i;

			//                if ((k <= A[i]) ||
			//                    (k <= A[j]) ||
			//                    ((k) <= (long)A[i] + (long)A[j]))
			//                    result++;
			//            }
			//        }


			//        return result;
			//    }

			//}
		}

		public class NumberOfDiscIntersections
		{

			public int solution(int[] A)
			{

				int[] lefts = new int[A.Length];
				int[] rights = new int[A.Length];

				for (int i = 0; i < A.Length; i++)
				{
					if (i < A[i])
						lefts[0]++;
					else
						lefts[i - A[i]]++;

					long left = (long)i + A[i];

					if (left >= A.Length)
						rights[A.Length - 1]++;
					else
						rights[i + A[i]]++;
				}

				int inCircles = 0;
				int result = 0;

				for (int i = 0; i < A.Length; i++)
				{
					result += inCircles * lefts[i];
					result += (lefts[i] * (lefts[i] - 1)) / 2;
					if (result > 10000000)
						return -1;
					inCircles += lefts[i];
					inCircles -= rights[i];
				}

				return result;
			}
		}
	}
}	
